/*
 TPI - 2024
 FruitPower - Game Manager
 Wihler Ruben
 */

using System;
using UnityEngine;

namespace GameManagement
{
    /// <summary>
    /// Classe responsable de la gestion du jeu. C'est ici que l'on demarre et termine le jeu.
    /// Cette classe est un singleton pour permettre un accès facile à partir de n'importe où.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("Aucune instance de GameManager n'a ete trouvee ! Assurez-vous que GameManager est present dans la scene.");

                return _instance;
            }
        }

        #endregion

        [Header("Game Options")]
        [Tooltip("Les options du jeu.")]
        public GameOption gameOption;

        /// <summary>
        /// Evenement appele lorsque le jeu demarre. Les abonnes à cet evenement recevront les options du jeu.
        /// </summary>
        public static event Action<GameOption> OnGameStart;
        /// <summary>
        /// Evenement appele lorsque le jeu se termine.
        /// </summary>
        public static event Action OnGameEnd;
        /// <summary>
        /// Evenement appele lorsque le score change. Les abonnes a cet evenement recevront le nouveau score.
        /// </summary>
        public static event Action<ulong> OnScoreChange;

        /// <summary>
        /// reference vers le score du jeu.
        /// </summary>
        private GameScore _gameScore;
        /// <summary>
        /// reference vers le timer du jeu.
        /// </summary>
        private GameTimer _gameTimer;
        /// <summary>
        /// variable indiquant si le jeu est en cours.
        /// </summary>
        private bool _isGameRunning;

        /// <summary>
        /// Le score actuel du jeu.
        /// </summary>
        public static ulong Score => Instance._gameScore.Score;
        /// <summary>
        /// Indique si le jeu est en cours.
        /// </summary>
        public static bool IsGameRunning => Instance._isGameRunning;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        /// <summary>
        /// Commence le jeu avec les options actuelles.
        /// </summary>
        [ContextMenu("Start Game")]
        public static void StartGame()
        {
            ResetPoints();
            Instance.StartTimer();
            Debug.Log($"[i] GameStarted");
        }

        /// <summary>
        /// Termine le jeu.
        /// </summary>
        [ContextMenu("End Game")]
        public static void EndGame()
        {
            Instance.StopTimer();
            Debug.Log($"[i] GameEnded");
        }

        #region Score Management

        /// <summary>
        /// Ajoute des points au score actuel.
        /// </summary>
        /// <param name="points">Les points à ajouter.</param>
        public static void AddPoints(ulong points)
        {
            // Si le jeu n'est pas en cours, on notifie dans les logs qu'un comportement inattendu a eu lieu et on ne fait rien.
            if (!IsGameRunning)
            {
                Debug.LogWarning("[!] Une tentative d'ajout de points a ete faite alors que le jeu n'est pas en cours.");
                return;
            }

            var newScore = Instance._gameScore.AddPoints(points);
            OnScoreChange?.Invoke(newScore);
        }
        /// <summary>
        /// Remet le score a 0.
        /// </summary>
        public static void ResetPoints()
        {
            Instance._gameScore = new GameScore();
            OnScoreChange?.Invoke(0ul);
        }

        #endregion

        #region Timer Management

        /// <summary>
        /// Start the game timer.
        /// </summary>
        private void StartTimer()
        {
            // Si le jeu est dejà en cours, on ne fait rien.
            if (_isGameRunning) return;

            _gameTimer = new GameTimer(gameOption.gameTime, this,
                //lancement de la partie
                () => {
                    _isGameRunning = true;
                    OnGameStart?.Invoke(gameOption);
                },
                //fin de la partie
                () => {
                    _isGameRunning = false;
                    OnGameEnd?.Invoke();
                },
                //dernieres secondes (20% restant)
                () => {
                    Debug.Log("[i] Last seconds!");
                }
            );
        }

        /// <summary>
        /// Stop the game timer.
        /// </summary>
        private void StopTimer()
        {
            // Si le jeu n'est pas en cours, on ne fait rien.
            if (!_isGameRunning) return;

            _gameTimer.Stop();
            _gameTimer = null;
        }

        #endregion
    }
}