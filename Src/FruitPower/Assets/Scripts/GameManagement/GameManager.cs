/*
 TPI - 2024
 FruitPower - Game Manager
 Wihler Ruben
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameManagement
{
    /// <summary>
    /// Classe responsable de la gestion du jeu. C'est ici que l'on demarre et termine le jeu.
    /// Cette classe est un singleton pour permettre un accès facile a partir de n'importe où.
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
        [SerializeField, Tooltip("Les options du jeu.")]
        private GameOption _gameOption;

        [Header("Audio")]
        [SerializeField, Tooltip("Le son jouer quand il reste 10 secondes")]
        private AudioClip _lastSecondsSound;

        /// <summary>
        /// Evenement appele lorsque le jeu demarre. Les abonnes a cet evenement recevront les options du jeu.
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
        /// Evenement appele lorsque le compte a rebours commence. Un callback est passe en parametre pour lancer la partie.
        /// </summary>
        public static event Action<uint> OnCountdownStart;

        /// <summary>
        /// reference vers le score du jeu.
        /// </summary>
        private GameScore _gameScore;
        /// <summary>
        /// reference vers le timer du jeu.
        /// </summary>
        private GameTimer _gameTimer;
        /// <summary>
        /// reference vers les statistiques du jeu.
        /// </summary>
        private GameStats _gameStats;
        /// <summary>
        /// variable indiquant si le jeu est en cours.
        /// </summary>
        private bool _isGameRunning;

        /// <summary>
        /// Le score actuel du jeu.
        /// </summary>
        public static ulong Score => Instance._gameScore.Score;
        /// <summary>
        /// Les fruits attrapes durant la partie.
        /// </summary>
        public static Dictionary<string, uint> FruitsCaught => Instance._gameStats.FruitsCaught;
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
        private async void Start()
        {
            await Task.Delay(2000);
            StartGame();
        }

        /// <summary>
        /// Commence le jeu avec les options actuelles.
        /// </summary>
        [ContextMenu("Start Game")]
        public static void StartGame()
        {
            Debug.Log($"[i] Starting game...");
            Instance.StartCoroutine(Instance.StartingCoroutine());
        }

        /// <summary>
        /// Termine le jeu.
        /// </summary>
        [ContextMenu("End Game")]
        public static void EndGame()
        {
            // Si le jeu n'est pas en cours, on ne fait rien.
            if (!IsGameRunning) return;

            //On met le temps en pause
            Time.timeScale = 0;
            //On arrete le timer
            Instance.StopTimer();
            Debug.Log($"[i] GameEnded");
        }

        /// <summary>
        /// Coroutine de demarrage du jeu.
        /// </summary>
        /// <returns></returns>
        private IEnumerator StartingCoroutine()
        {
            // Si le jeu est deja en cours, on ne fait rien.
            if (IsGameRunning) yield break;

            //On remet le temps a la normale
            Time.timeScale = 1;
            //On remet le score a 0
            ResetPoints();
            ResetStats();

            //On appelle l'evenement de debut de compte a rebours et on attend sa fin
            var countdownDuration = _gameOption.countdownDuration;
            OnCountdownStart?.Invoke(countdownDuration);
            yield return new WaitForSeconds(countdownDuration + 1);//+1 pour attendre le message de fin de compte a rebours

            StartTimer();
        }

        #region Score Management

        /// <summary>
        /// Ajoute des points au score actuel.
        /// </summary>
        /// <param name="points">Les points a ajouter.</param>
        public static bool AddPoints(ulong points, string fruitTypeId = "")
        {
            // Si le fruitTypeId n'est pas vide, on ajoute le fruit aux statistiques.
            if (!string.IsNullOrEmpty(fruitTypeId))
                Instance._gameStats.AddFruit(fruitTypeId);

            // Si le jeu n'est pas en cours, on notifie dans les logs qu'un comportement inattendu a eu lieu et on ne fait rien.
            if (!IsGameRunning)
            {
                Debug.LogWarning("[!] Une tentative d'ajout de points a ete faite alors que le jeu n'est pas en cours.");
                return false;
            }

            var newScore = Instance._gameScore.AddPoints(points);
            OnScoreChange?.Invoke(newScore);
            return true;
        }
        /// <summary>
        /// Remet le score a 0.
        /// </summary>
        public static void ResetPoints()
        {
            Instance._gameScore = new GameScore();
            OnScoreChange?.Invoke(0ul);
        }
        /// <summary>
        /// Remet les statistiques a 0.
        /// </summary>
        public static void ResetStats()
        {
            Instance._gameStats = new GameStats();
        }

        #endregion

        #region Timer Management

        /// <summary>
        /// Start the game timer.
        /// </summary>
        private void StartTimer()
        {
            // Si le jeu est deja en cours, on ne fait rien.
            if (_isGameRunning) return;

            // On cree un nouveau timer avec les options actuelles.
            _gameTimer = new GameTimer(_gameOption.gameDuration, this,
                //lancement de la partie
                () => {
                    _isGameRunning = true;
                    OnGameStart?.Invoke(_gameOption);
                },
                //fin de la partie
                () => {
                    _isGameRunning = false;
                    OnGameEnd?.Invoke();
                },
                //dernieres secondes (10 secondes restantes)
                () => {
                    AudioSource.PlayClipAtPoint(_lastSecondsSound, Camera.main.transform.position);
                }
            );

            // On demarre le timer.
            _gameTimer.Start();
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