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
    public class FruitSpawnManager
    {
        private readonly MonoBehaviour _coroutineOwner;
        private readonly Dictionary<string, List<FruitSpawner>> _fruitsSpawners;
        private readonly Dictionary<string, ushort> _fruitTypeSpawnCount; //dictionnaire de cache pour optimiser les performances
        private readonly Func<string, Fruit> _instantiateFruit;
        private readonly Func<List<Fruit>> _getAllFruits;

        private Coroutine _spawnCoroutine;
        private bool _isSpawning;
        private ushort _spawnerRate;

        public FruitSpawnManager(Func<string, Fruit> instantiateFruit, Func<List<Fruit>> getAllFruits, MonoBehaviour coroutineOwner, FruitSpawner[] fruitSpawners)
        {
            _coroutineOwner = coroutineOwner;
            _instantiateFruit = instantiateFruit;
            _getAllFruits = getAllFruits;
            _fruitsSpawners = InitializeFruitSpawners(fruitSpawners);
            _fruitTypeSpawnCount = new Dictionary<string, ushort>();
        }

        public void StartSpawning(ushort spawnerRate)
        {
            this._spawnerRate = spawnerRate;
            _isSpawning = true;
            StartSpawnCoroutine();
        }
        public void StopSpawning()
        {
            _isSpawning = false;
            StopSpawnCoroutine();
        }

        
        private void StartSpawnCoroutine()
        {
            StopSpawnCoroutine();
            Debug.Log(_coroutineOwner);
            _spawnCoroutine = _coroutineOwner.StartCoroutine(SpawnCoroutine());
        }
        private void StopSpawnCoroutine()
        {
            if (_spawnCoroutine != null)
            {
                _coroutineOwner.StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }
        private IEnumerator SpawnCoroutine()
        {
            SpawnFruits();
            yield return new WaitForSeconds(1);

            //recucrsion si on est toujours en train de spawner
            if (_isSpawning) StartSpawnCoroutine();
        }

        private void SpawnFruits()
        {
            //on spawn (spawnRate/nombre de points) fruits pour chaque type de fruit
            foreach (var fruitTypeId in _fruitsSpawners.Keys)
            {
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
        private int GetCachedFruitSpawnCount(string typeId)
        {
            if (!_fruitTypeSpawnCount.ContainsKey(typeId))
            {
                var score = _getAllFruits().Find(f => f.TypeId == typeId).Score;
                var spawnCount = CalculateSpawnCount(_spawnerRate, score);
                _fruitTypeSpawnCount.Add(typeId, spawnCount);
            }

            return _spawnerRate / _fruitTypeSpawnCount[typeId];
        }
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

            foreach (var spawner in spawners)
            {
                if (!dictionary.ContainsKey(spawner.FruitType))
                    dictionary.Add(spawner.FruitType, new List<FruitSpawner>());

                dictionary[spawner.FruitType].Add(spawner);
            }

            return dictionary;
        }

    }
}