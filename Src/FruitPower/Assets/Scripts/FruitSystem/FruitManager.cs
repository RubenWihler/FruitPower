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
    /// <summary>
    /// La classe <see cref="FruitManager"/> est responsable de la gestion des fruits dans la scène.
    /// Etant un singleton, elle permet d'accéder facilement de l'exérieur à la liste des fruits et aux différents managers.
    /// </summary>
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

        private FruitSpawnManager _fruitSpawnerManager;
        private FruitPooler _fruitPooler;
        
        private List<Fruit> _fruits;
        private ulong _idCounter;
        

        private void Awake()
        {
            //Singleton
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                Debug.LogWarning("[!] Une autre instance de FruitManager a été trouvée. L'instance actuelle a été détruite.");
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this);

            //Initialisation de la liste de fruits et du compteur d'identifiant
            _fruits = new List<Fruit>();
            _idCounter = 0;
        }

        private void Start()
        {
            //Initialisation de la factory et du manager de spawn
            (_fruitPooler, _fruitSpawnerManager) = Initialize();

            //Ecoute des evenements de debut et de fin de partie
            GameManager.OnGameStart += (gameOption) => _fruitSpawnerManager.StartSpawning(gameOption.spawnerRate);
            GameManager.OnGameEnd += () => _fruitSpawnerManager.StopSpawning();
        }

        /// <summary>
        /// Initialise le pooler et le manager de spawn de fruits.
        /// </summary>
        /// <returns>Un tuple contenant le pooler et le manager de spawn.</returns>
        private (FruitPooler, FruitSpawnManager) Initialize()
        {
            var fruitPooler = new FruitPooler(fruitsEntries, transform, (instantiate) =>
            {
                var fruit = instantiate(_idCounter++);
                _fruits.Add(fruit);
                return fruit;
            });

            var fruitSpawners = fruitSpawnersParent.GetComponentsInChildren<FruitSpawner>();
            var fruitSpawnManager = new FruitSpawnManager(fruitPooler.InstantiateFruit, () => _fruits, this, fruitSpawners);

            return (fruitPooler, fruitSpawnManager);
        }
        
    }
}