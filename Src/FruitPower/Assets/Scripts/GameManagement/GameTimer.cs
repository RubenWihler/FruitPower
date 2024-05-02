/*
 TPI - 2024
 FruitPower - GameTimer
 Wihler Ruben
 */

using System;
using System.Collections;
using UnityEngine;

namespace GameManagement
{
    /// <summary>
    /// Classe responsable de la gestion du temps de jeu.
    /// </summary>
    public class GameTimer
    {
        /// <summary>
        /// temps de la partie en secondes.
        /// </summary>
        private readonly float _gameDuration;
        /// <summary>
        /// reference vers le MonoBehaviour qui possede le coroutine.
        /// </summary>
        private readonly MonoBehaviour _coroutineOwner;
        /// <summary>
        /// delegate appele lorsque le jeu demarre.
        /// </summary>
        private readonly Action _onGameStart;
        /// <summary>
        /// delegate appele lorsque le jeu se termine.
        /// </summary>
        private readonly Action _onGameEnd;
        /// <summary>
        /// delegate appele lorsque le jeu est sur le point de se terminer.
        /// </summary>
        private readonly Action _onGameLastSeconds;
        /// <summary>
        /// Reference vers la coroutine du timer.
        /// </summary>
        private Coroutine _gameTimerCoroutine;

        /// <summary>
        /// Constructeur de la classe GameTimer.
        /// </summary>
        /// <param name="duration">La duree de la partie en secondes.</param>
        /// <param name="coroutineOwner">Le MonoBehaviour qui possede le coroutine.</param>
        /// <param name="onGameStart">Le delegate appele lorsque le jeu demarre.</param>
        /// <param name="onGameEnd">Le delegate appele lorsque le jeu se termine.</param>
        /// <param name="onGameLastSecondes">Le delegate appele lorsque le jeu est sur le point de se terminer.</param>
        public GameTimer(float duration, MonoBehaviour coroutineOwner, Action onGameStart, Action onGameEnd, Action onGameLastSecondes)
        {
            this._gameDuration = duration;
            this._coroutineOwner = coroutineOwner;
            this._onGameStart = onGameStart;
            this._onGameEnd = onGameEnd;
            this._onGameLastSeconds = onGameLastSecondes;
        }

        /// <summary>
        /// Commence le timer du jeu.
        /// </summary>
        public void Start() => StartGameTimerCoroutine();
        /// <summary>
        /// Force l'arret du timer du jeu.
        /// </summary>
        public void Stop() => StopGameTimerCoroutine();

        /// <summary>
        /// Commence la coroutine du timer du jeu.
        /// </summary>
        private void StartGameTimerCoroutine()
        {
            StopGameTimerCoroutine();
            _gameTimerCoroutine = _coroutineOwner.StartCoroutine(GameTimerCoroutine());
        }
        /// <summary>
        /// Arrete la coroutine du timer du jeu.
        /// </summary>
        private void StopGameTimerCoroutine()
        {
            if (_gameTimerCoroutine == null) return;

            _coroutineOwner.StopCoroutine(_gameTimerCoroutine);
            _gameTimerCoroutine = null;
            _onGameEnd.Invoke();
        }
        /// <summary>
        /// Coroutine du timer du jeu.
        /// </summary>
        /// <returns></returns>
        private IEnumerator GameTimerCoroutine()
        {
            //On appelle le delegate lorsque le jeu demarre.
            _onGameStart.Invoke();

            //on attend que le jeu soit a 80% de sa duree pour appeler le delegate des dernieres secondes.
            yield return new WaitForSeconds(_gameDuration * 0.8f);
            _onGameLastSeconds.Invoke();

            //On attend que le jeu soit termine pour appeler le delegate de fin de jeu.
            yield return new WaitForSeconds(_gameDuration * 0.2f);
            _onGameEnd.Invoke();
        }
    }
}