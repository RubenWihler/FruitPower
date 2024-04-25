/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using System;
using System.Collections.Generic;
using UnityEngine;

namespace FruitSystem
{
    public class FruitManager : MonoBehaviour
    {
        #region Singleton
        
        private static FruitManager _instance;
        public static FruitManager Instance
        {
            get
            {
                if (_instance is null) 
                    throw new NullReferenceException("Aucun FruitManager n'a été trouvé dans la scène.");

                return _instance;
            }
        }

        #endregion

        [Header("References")]
        [SerializeField, Tooltip("Tout les fruits disponibles.")]
        private FruitPoolData[] fruitsEntries;
        [SerializeField, Tooltip("Le parent qui contient les spawners de fruits.")]
        private Transform fruitSpawnersParent;

        private FruitSpawnManager _fruitSpawnerManagement;
        private FruitFactory _fruitFactory;
        
        private List<Fruit> _fruits;
        private ulong _idCounter;
        

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                Debug.LogWarning("[!] Une autre instance de FruitManager a été trouvée. L'instance actuelle a été détruite.");
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this);

            _fruits = new List<Fruit>();
            _idCounter = 0;
        }

        private void Start()
        {
            //Initialisation de la factory et du manager de spawn
            (_fruitFactory, _fruitSpawnerManagement) = Initialize();

            //Ecoute des evenements de debut et de fin de partie
            GameManager.OnGameStart += (gameOption) => _fruitSpawnerManagement.StartSpawning(gameOption.spawnerRate);
            GameManager.OnGameEnd += () => _fruitSpawnerManagement.StopSpawning();
        }

        private (FruitFactory, FruitSpawnManager) Initialize()
        {
            var fruitFactory = new FruitFactory(fruitsEntries, transform, (instantiate) =>
            {
                var fruit = instantiate(_idCounter++);
                _fruits.Add(fruit);
                return fruit;
            });

            var fruitSpawners = fruitSpawnersParent.GetComponentsInChildren<FruitSpawner>();
            var fruitSpawnManager = new FruitSpawnManager(fruitFactory.InstantiateFruit, () => _fruits, this, fruitSpawners);

            return (fruitFactory, fruitSpawnManager);
        }

        
        #region Spawn des fruits

        
        #endregion
    }
}