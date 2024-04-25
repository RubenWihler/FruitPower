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
    /// La classe <see cref="FruitFactory"/> est responsable de la gestion des pools de fruits.
    /// Elle permet de recycler les fruits afin d'eviter les instanciations et destructions inutiles.
    /// </summary>
    public sealed class FruitFactory
    {
        private readonly Dictionary<string, GameObject> _fruitsDictionary;
        private readonly Dictionary<string, Queue<Fruit>> _fruitsPools;
        private readonly Func<Func<ulong, Fruit>, Fruit> _fruitInstantiationCallback;
        private readonly Transform _parent;

        /// <summary>
        /// Constructeur de la classe <see cref="FruitFactory"/>.
        /// Initialise la factory avec les objets <see cref="FruitPoolData"/> et le parent des fruits.
        /// </summary>
        /// <param name="fruitsEntries">Un tableau d'objets <see cref="FruitPoolData"/> qui contient les données nécessaires pour initialiser les pools de fruits.</param>
        /// <param name="parent">L'objet parent des fruits.</param>
        /// <param name="fruitInstantiationCallback">Fonction de callback appelée lors de l'instanciation d'un fruit.</param>
        public FruitFactory(FruitPoolData[] fruitsEntries, Transform parent, Func<Func<ulong, Fruit>, Fruit> fruitInstantiationCallback)
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
        /// Instancie un fruit du type spécifié a partir du pool.
        /// </summary>
        /// <param name="typeId">L'identifiant du type de fruit.</param>
        /// <returns>le fruit instancié.</returns>
        /// <exception cref="FruitTypeIdDoesNotExistException">Si le type de fruit n'existe pas.</exception>
        /// <exception cref="FruitPoolDoesNotExistException">Si le pool de fruit n'existe pas.</exception>
        public Fruit InstantiateFruit(string typeId)
        {
            if (!_fruitsDictionary.TryGetValue(typeId, out var prefab))
                throw new FruitTypeIdDoesNotExistException(typeId);

            if (!_fruitsPools.TryGetValue(typeId, out var pool))
                throw new FruitPoolDoesNotExistException(typeId);

            //si le pool est vide, on en crée un nouveau et on l'ajoute au pool
            if (pool.Count == 0)
                pool.Enqueue(InstantiateFruit(prefab));

            return pool.Dequeue();
        }

        /// <summary>
        /// Remet un fruit dans le pool.
        /// </summary>
        /// <param name="fruit">le fruit à remettre dans le pool.</param>
        /// <exception cref="FruitPoolDoesNotExistException"></exception>
        public void PushFruitToPool(Fruit fruit)
        {
            if (!_fruitsPools.TryGetValue(fruit.TypeId, out var pool))
                throw new FruitPoolDoesNotExistException(fruit.TypeId);

            pool.Enqueue(fruit);
        }

        #region Initialisation

        private Dictionary<string, GameObject> InitializeDictionary(IEnumerable<(string typeId, GameObject prefab)> fruitsData)
        {
           return fruitsData.ToDictionary(
               f => f.typeId,
               f => f.prefab
           );
        }
        private Dictionary<string, Queue<Fruit>> InitializePools(IEnumerable<(string typeId, GameObject prefab, ushort poolSize)> fruitsData)
        {
            return fruitsData.ToDictionary(
                f => f.typeId, 
                f => InitializePool(f.prefab, f.poolSize)
            );
        }
        private Queue<Fruit> InitializePool(GameObject prefab, ushort size)
        {
            var pool = new Queue<Fruit>(size);

            for (var i = 0; i < size; i++)
                pool.Enqueue(InstantiateFruit(prefab));

            return pool;
        }
        private Fruit InstantiateFruit(GameObject prefab)
        {
            var gameObject = GameObject.Instantiate(prefab, _parent);

            // Verifie si le prefab contient un component Fruit
            if (!gameObject.TryGetComponent<Fruit>(out var fruit))
                throw new Exception($"Prefab {gameObject.name} ne contient pas de component Fruit.");

            return _fruitInstantiationCallback((id) => fruit.Initialize(id, PushFruitToPool));
        }

        #endregion

        #region Exceptions

        public class FruitTypeIdDoesNotExistException : Exception
        { public FruitTypeIdDoesNotExistException(string typeId) : base($"Le type de fruit {typeId} n'existe pas.") { } }

        public class FruitPoolDoesNotExistException : Exception
        { public FruitPoolDoesNotExistException(string typeId) : base($"Le pool de fruit {typeId} n'existe pas.") { } }

        #endregion
    }
}