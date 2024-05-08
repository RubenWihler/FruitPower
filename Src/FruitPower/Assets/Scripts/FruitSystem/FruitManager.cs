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
    /// Etant un singleton, elle permet d'acceder facilement de l'exerieur a la liste des fruits et aux differents managers.
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
        [SerializeField, Tooltip("Les donnees des differents types de fruits.")]
        private FruitTypesDatas fruitTypesDatas;

        /// <summary>
        /// reference vers le manager de spawn de fruits.
        /// </summary>
        private FruitSpawnManager _fruitSpawnerManager;
        /// <summary>
        /// reference vers le pooler de fruits.
        /// </summary>
        private FruitPooler _fruitPooler;
        /// <summary>
        /// Liste de tous les fruits (actifs et inactifs).
        /// </summary>
        private List<Fruit> _fruits;
        /// <summary>
        /// Compteur d'identifiant pour les fruits.
        /// </summary>
        private ulong _idCounter;
        
        /// <summary>
        /// Donne le fruitTypeData en fonction de l'identifiant du fruit.
        /// </summary>
        /// <param name="fruitId">L'identifiant du fruit.</param>
        /// <returns>L'objet FruitTypeData correspondant a l'identifiant du fruit.</returns>
        public static FruitTypeData GetFruitTypeData(string fruitId)
        {
            return Instance.fruitTypesDatas.datas.FirstOrDefault(data => data.fruitId == fruitId);
        }

        /// <summary>
        /// Mise en place du singleton et initialisation de la liste de fruits.
        /// </summary>
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
        /// <summary>
        /// Initialisation du pooler et du manager de spawn de fruits.
        /// </summary>
        private void Start()
        {
            //Initialisation de la factory et du manager de spawn
            (_fruitPooler, _fruitSpawnerManager) = Initialize();
        }

        /// <summary>
        /// On s'abonne aux evenements de debut et de fin de jeu.
        /// </summary>
        private void OnEnable()
        {
            GameManager.OnGameStart += OnGameStart;
            GameManager.OnGameEnd += OnGameEnd;
        }
        /// <summary>
        /// On se desabonne aux evenements de debut et de fin de jeu pour eviter.
        /// </summary>
        private void OnDisable()
        {
            GameManager.OnGameStart -= OnGameStart;
            GameManager.OnGameEnd -= OnGameEnd;
        }

        /// <summary>
        /// On dit au manager de spawn de fruits de commencer a spawn des fruits.
        /// </summary>
        /// <param name="options">Les options de la partie donnees</param>
        private void OnGameStart(GameOption options)
        {
            _fruitSpawnerManager.StartSpawning(options.spawnerRate);
        }
        /// <summary>
        /// On dit au manager de spawn de fruits d'arreter de spawn des fruits et on despawn tout les fruits actifs.
        /// </summary>
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
            //Initialisation du pooler de fruits
            var fruitPooler = new FruitPooler(fruitsEntries, transform, (instantiate) =>
            {
                var fruit = instantiate(_idCounter++);
                _fruits.Add(fruit);
                return fruit;
            });

            //Initialisation du manager de spawn de fruits
            var fruitSpawners = fruitSpawnersParent.GetComponentsInChildren<FruitSpawner>();
            var fruitSpawnManager = new FruitSpawnManager(fruitPooler.InstantiateFruit, () => _fruits, this, fruitSpawners);

            return (fruitPooler, fruitSpawnManager);
        }
    }
}