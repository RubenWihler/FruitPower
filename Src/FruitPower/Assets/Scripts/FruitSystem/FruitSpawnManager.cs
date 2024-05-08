/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FruitSystem
{
    /// <summary>
    /// Classe responsable de la gestion des spawners de fruits. Elle permet de gerer le spawn de fruits.
    /// </summary>
    public class FruitSpawnManager
    {
        /// <summary>
        /// Etant donne que cette classe n'est pas un MonoBehaviour, on doit passer un MonoBehaviour pour pouvoir lancer des coroutines.
        /// </summary>
        private readonly MonoBehaviour _coroutineOwner;
        /// <summary>
        /// Dictionnaire contenant les spawners de fruits classes par type de fruit.
        /// </summary>
        private readonly Dictionary<string, List<FruitSpawner>> _fruitsSpawners;
        /// <summary>
        /// Dictionnaire de cache pour optimiser les performances. Il contient le nombre de fruits a spawn pour chaque type de fruit.
        /// </summary>
        private readonly Dictionary<string, ushort> _fruitTypeSpawnCount;
        /// <summary>
        /// La fonction qui instancie un fruit a partir de son type. (Utilisee lors du spawn de fruit)
        /// </summary>
        private readonly Func<string, Fruit> _instantiateFruit;
        /// <summary>
        /// La fonction qui retourne tous les fruits.
        /// </summary>
        private readonly Func<List<Fruit>> _getAllFruits;

        private Coroutine _spawnCoroutine;
        private bool _isSpawning;
        private ushort _spawnerRate;

        /// <summary>
        /// Constructeur de la classe <see cref="FruitSpawnManager"/>.
        /// </summary>
        /// <param name="instantiateFruit">Fonction qui instancie un fruit a partir de son type (Utilisee lors du spawn de fruit).</param>
        /// <param name="getAllFruits">Fonction qui retourne tous les fruits.</param>
        /// <param name="coroutineOwner">Le MonoBehaviour qui va lancer les coroutines.</param>
        /// <param name="fruitSpawners">Une liste de tous les spawners de fruits.</param>
        public FruitSpawnManager(Func<string, Fruit> instantiateFruit, Func<List<Fruit>> getAllFruits, MonoBehaviour coroutineOwner, FruitSpawner[] fruitSpawners)
        {
            _coroutineOwner = coroutineOwner;
            _instantiateFruit = instantiateFruit;
            _getAllFruits = getAllFruits;
            _fruitsSpawners = InitializeFruitSpawners(fruitSpawners);
            _fruitTypeSpawnCount = new Dictionary<string, ushort>();
        }

        /// <summary>
        /// Commence a faire apparaitre les fruits.
        /// </summary>
        /// <param name="spawnerRate"></param>
        public void StartSpawning(ushort spawnerRate)
        {
            this._spawnerRate = spawnerRate;
            _isSpawning = true;
            StartSpawnCoroutine();
        }
        /// <summary>
        /// Arrete de faire apparaitre les fruits.
        /// </summary>
        public void StopSpawning()
        {
            _isSpawning = false;
            StopSpawnCoroutine();
        }

        /// <summary>
        /// Commence la coroutine responsable du spawn des fruits.
        /// </summary>
        private void StartSpawnCoroutine()
        {
            StopSpawnCoroutine();
            _spawnCoroutine = _coroutineOwner.StartCoroutine(SpawnCoroutine());
        }
        /// <summary>
        /// Arrete la coroutine responsable du spawn des fruits.
        /// </summary>
        private void StopSpawnCoroutine()
        {
            if (_spawnCoroutine != null)
            {
                _coroutineOwner.StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }
        /// <summary>
        /// Coroutine responsable du spawn des fruits.
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnCoroutine()
        {
            SpawnFruits();
            yield return new WaitForSeconds(1);

            //recucrsion si on est toujours en train de spawner
            if (_isSpawning) StartSpawnCoroutine();
        }

        /// <summary>
        /// Fait apparaitre les fruits pour chaque type de fruit.
        /// Le nombre de fruits a apparaitre est calcule avec <see cref="CalculateSpawnCount(ushort, ushort)"/>.
        /// </summary>
        private void SpawnFruits()
        {
            //on spawn (spawnRate/nombre de points) fruits pour chaque type de fruit
            foreach (var fruitTypeId in _fruitsSpawners.Keys)
            {
                //recuperer les spawners qui ne sont pas pleins
                var spawners = _fruitsSpawners[fruitTypeId].Where((s) => !s.IsFull).ToList();
                var spawnCount = GetCachedFruitSpawnCount(fruitTypeId);

                for (int i = 0; i < spawnCount; i++)
                {
                    if (spawners.Count == 0) break;//si il n'y a plus de spawner, on arrete

                    //prendre un spawner au hasard
                    var spawner = spawners[UnityEngine.Random.Range(0, spawners.Count)];
                    spawners.Remove(spawner);//on enleve le spawner de la liste pour eviter de le reprendre
                    spawner.SpawnFruit(_instantiateFruit(fruitTypeId));//_fruitFactory.InstantiateFruit()
                }
            }
        }
        /// <summary>
        /// Retourne le nombre de fruits a apparaitre pour un type de fruit donne. 
        /// Utilise <see cref="_fruitTypeSpawnCount"/> pour eviter de recalculer le nombre de fruits a apparaitre a chaque fois.
        /// </summary>
        /// <param name="typeId">L'identifiant du type de fruit.</param>
        /// <returns></returns>
        private int GetCachedFruitSpawnCount(string typeId)
        {
            //si le type de fruit n'existe pas encore dans le dictionnaire, on le calcule et on l'ajoute
            if (!_fruitTypeSpawnCount.ContainsKey(typeId))
            {
                var score = _getAllFruits().Find(f => f.TypeId == typeId).PointsGiven;
                var spawnCount = CalculateSpawnCount(_spawnerRate, score);
                _fruitTypeSpawnCount.Add(typeId, spawnCount);
            }

            return _fruitTypeSpawnCount[typeId];
        }
        /// <summary>
        /// Calcule le nombre de fruits a apparaitre en fonction du score du fruit et du taux de spawn.
        /// </summary>
        /// <param name="spawnerRate">Le taux de spawn (global pour tous les fruits).</param>
        /// <param name="score">le nombre de points que le joueur gagne en ramassant le fruit.</param>
        /// <returns></returns>
        private ushort CalculateSpawnCount(ushort spawnerRate, ushort score)
        {
            return (ushort)(spawnerRate / score);
        }

        /// <summary>
        /// cree un dictionnaire qui contiendra les spawners de fruits classes par type de fruit
        /// </summary>
        /// <returns>le dictionnaire des spawners de fruits</returns>
        private Dictionary<string, List<FruitSpawner>> InitializeFruitSpawners(FruitSpawner[] spawners)
        {
            var dictionary = new Dictionary<string, List<FruitSpawner>>();

            //Ajouter chaque spawner dans le dictionnaire
            foreach (var spawner in spawners)
            {
                //Si le type de fruit n'existe pas encore dans le dictionnaire, on le cree
                if (!dictionary.ContainsKey(spawner.FruitType))
                    dictionary.Add(spawner.FruitType, new List<FruitSpawner>());

                //Ajouter le spawner dans la liste correspondante
                dictionary[spawner.FruitType].Add(spawner);
            }

            return dictionary;
        }

    }
}