/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameManagement;

namespace FruitSystem
{
    /// <summary>
    /// La classe <see cref="FruitManager"/> est responsable de la gestion des fruits dans la scène.
    /// Etant un singleton, elle permet d'acceder facilement de l'exerieur à la liste des fruits et aux differents managers.
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
                    throw new NullReferenceException("Aucun FruitManager n'a ete trouve dans la scène.");

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
                Debug.LogWarning("[!] Une autre instance de FruitManager a ete trouvee. L'instance actuelle a ete detruite.");
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
        }

        private void OnEnable()
        {
            GameManager.OnGameStart += OnGameStart;
            GameManager.OnGameEnd += OnGameEnd;
        }
        private void OnDisable()
        {
            GameManager.OnGameStart -= OnGameStart;
            GameManager.OnGameEnd -= OnGameEnd;
        }

        private void OnGameStart(GameOption options)
        {
            _fruitSpawnerManager.StartSpawning(options.spawnerRate);
        }
        private void OnGameEnd()
        {
            _fruitSpawnerManager.StopSpawning();
            //despawn tout les fruits actifs
            _fruits.Where(fruit => fruit.State != FruitState.Inactive).ToList().ForEach(fruit => fruit.Despawn());
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