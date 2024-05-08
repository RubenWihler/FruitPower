/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FruitSystem
{
    /// <summary>
    /// La classe <see cref="FruitPooler"/> est responsable de la gestion des pools de fruits.
    /// Elle permet de recycler les fruits afin d'eviter les instanciations et destructions inutiles.
    /// </summary>
    public sealed class FruitPooler
    {
        /// <summary>
        /// Dictionnaire qui contient les prefabs des fruits.
        /// </summary>
        private readonly Dictionary<string, GameObject> _fruitsDictionary;
        /// <summary>
        /// Dictionnaire qui contient les pools de fruits organises par identifiant de type.
        /// </summary>
        private readonly Dictionary<string, Queue<Fruit>> _fruitsPools;
        /// <summary>
        /// Fonction de callback appelee lors de l'instanciation d'un fruit. 
        /// Il contient la fonction d'initialisation du fruit.
        /// </summary>
        private readonly Func<Func<ulong, Fruit>, Fruit> _fruitInstantiationCallback;
        /// <summary>
        /// L'objet parent des fruits.
        /// </summary>
        private readonly Transform _parent;

        /// <summary>
        /// Constructeur de la classe <see cref="FruitPooler"/>.
        /// Initialise la factory avec les objets <see cref="FruitPoolData"/> et le parent des fruits.
        /// </summary>
        /// <param name="fruitsEntries">Un tableau d'objets <see cref="FruitPoolData"/> qui contient les donnees necessaires pour initialiser les pools de fruits.</param>
        /// <param name="parent">L'objet parent des fruits.</param>
        /// <param name="fruitInstantiationCallback">Fonction de callback appelee lors de l'instanciation d'un fruit.</param>
        public FruitPooler(FruitPoolData[] fruitsEntries, Transform parent, Func<Func<ulong, Fruit>, Fruit> fruitInstantiationCallback)
        {
            _parent = parent;
            _fruitInstantiationCallback = fruitInstantiationCallback;

            // Initialisation du dictionnaire
            _fruitsDictionary = InitializeDictionary(fruitsEntries.Select(entry => (
                typeId: entry.typeId,
                prefab: entry.prefab
            )));

            // Initialisation des pools
            _fruitsPools = InitializePools(fruitsEntries.Select(entry => (
                typeId: entry.typeId,
                prefab: entry.prefab,
                poolSize: entry.poolSize
            )));

            Debug.Log("[i] FruitFactory initialized.");
        }

        /// <summary>
        /// Instancie un fruit du type specifie a partir du pool.
        /// </summary>
        /// <param name="typeId">L'identifiant du type de fruit.</param>
        /// <returns>le fruit instancie.</returns>
        /// <exception cref="FruitTypeIdDoesNotExistException">Si le type de fruit n'existe pas.</exception>
        /// <exception cref="FruitPoolDoesNotExistException">Si le pool de fruit n'existe pas.</exception>
        public Fruit InstantiateFruit(string typeId)
        {
            // Verifie si le type de fruit existe
            if (!_fruitsDictionary.TryGetValue(typeId, out var prefab))
                throw new FruitTypeIdDoesNotExistException(typeId);

            // Verifie si le pool du type de fruit existe
            if (!_fruitsPools.TryGetValue(typeId, out var pool))
                throw new FruitPoolDoesNotExistException(typeId);

            //si le pool est vide, on en cree un nouveau et on l'ajoute au pool
            if (pool.Count == 0)
                pool.Enqueue(InstantiateFruit(prefab));

            return pool.Dequeue();
        }

        /// <summary>
        /// Remet un fruit dans le pool.
        /// </summary>
        /// <param name="fruit">le fruit a remettre dans le pool.</param>
        /// <exception cref="FruitPoolDoesNotExistException"></exception>
        public void PushFruitToPool(Fruit fruit)
        {
            // Verifie si le pool du type de fruit existe
            if (!_fruitsPools.TryGetValue(fruit.TypeId, out var pool))
                throw new FruitPoolDoesNotExistException(fruit.TypeId);

            pool.Enqueue(fruit);
        }

        #region Initialisation

        /// <summary>
        /// Initialise le dictionnaire des fruits a partir des donnees.
        /// </summary>
        /// <param name="fruitsData">un enumerable de tuples contenant les donnees necessaires pour initialiser le dictionnaire des fruits.</param>
        /// <returns></returns>
        private Dictionary<string, GameObject> InitializeDictionary(IEnumerable<(string typeId, GameObject prefab)> fruitsData)
        {
           return fruitsData.ToDictionary(
               f => f.typeId,
               f => f.prefab
           );
        }
        /// <summary>
        /// Initialise les pools de fruits a partir des donnees.
        /// </summary>
        /// <param name="fruitsData">Un enumerable de tuples contenant les donnees necessaires pour initialiser les pools de fruits.</param>
        /// <returns>l'ensemble des pools de fruits organise par identifiant de type.</returns>
        private Dictionary<string, Queue<Fruit>> InitializePools(IEnumerable<(string typeId, GameObject prefab, ushort poolSize)> fruitsData)
        {
            return fruitsData.ToDictionary(
                f => f.typeId, 
                f => InitializePool(f.prefab, f.poolSize)
            );
        }
        /// <summary>
        /// Initialise un pool de fruit et le remplit avec des fruits instancies.
        /// </summary>
        /// <param name="prefab">la prefab du fruit.</param>
        /// <param name="size">le nombre de fruits a instancier.</param>
        /// <returns></returns>
        private Queue<Fruit> InitializePool(GameObject prefab, ushort size)
        {
            var pool = new Queue<Fruit>(size);

            for (var i = 0; i < size; i++)
                pool.Enqueue(InstantiateFruit(prefab));

            return pool;
        }
        /// <summary>
        /// Instancie un fruit a partir de la prefab.
        /// </summary>
        /// <param name="prefab">La prefab du fruit a instancier.</param>
        /// <returns>le fruit instancie.</returns>
        /// <exception cref="Exception">Une exception est levee si la prefab ne contient pas de component Fruit.</exception>
        private Fruit InstantiateFruit(GameObject prefab)
        {
            //Instanciation de la prefab
            var gameObject = GameObject.Instantiate(prefab, _parent);

            // Verifie si le prefab contient un component Fruit
            if (!gameObject.TryGetComponent<Fruit>(out var fruit))
                throw new Exception();

            //Appel du callback d'instanciation
            return _fruitInstantiationCallback((id) => fruit.Initialize(id, PushFruitToPool));
        }

        #endregion

        #region Exceptions

        /// <summary>
        /// Exception levee lorsque une tentative d'instanciation d'un fruit d'un type inexistant est faite.
        /// </summary>
        public class FruitTypeIdDoesNotExistException : Exception
        { public FruitTypeIdDoesNotExistException(string typeId) : base($"Le type de fruit {typeId} n'existe pas.") { } }
        /// <summary>
        /// Exception levee lorsque une tentative d'instanciation d'un fruit d'un pool inexistant est faite.
        /// </summary>
        public class FruitPoolDoesNotExistException : Exception
        { public FruitPoolDoesNotExistException(string typeId) : base($"Le pool de fruit {typeId} n'existe pas.") { } }
        /// <summary>
        /// Exception levee lorsque la prefab ne contient pas de composant Fruit.
        /// </summary>
        public class PrefabDoesNotContainsPoolableFruitComponent : Exception
        { public PrefabDoesNotContainsPoolableFruitComponent(GameObject go) : base($"le prefab {go.name} ne contient pas de composant Fruit.") { } }

        #endregion
    }
}