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
    public sealed class GameTimer
    {
        /// <summary>
        /// temps de la partie en secondes.
        /// </summary>
        private readonly float _duration;
        /// <summary>
        /// reference vers le MonoBehaviour qui possede le coroutine.
        /// </summary>
        private readonly MonoBehaviour _coroutineOwner;
        /// <summary>
        /// delegate appele lorsque le jeu demarre.
        /// </summary>
        private readonly Action _onStart;
        /// <summary>
        /// delegate appele lorsque le jeu se termine.
        /// </summary>
        private readonly Action _onEnd;
        /// <summary>
        /// delegate appele lorsque le jeu est sur le point de se terminer.
        /// </summary>
        private readonly Action _onEndSoon;
        /// <summary>
        /// Reference vers la coroutine du timer.
        /// </summary>
        private Coroutine _timerCoroutine;

        /// <summary>
        /// Constructeur de la classe GameTimer.
        /// </summary>
        /// <param name="duration">La duree de la partie en secondes.</param>
        /// <param name="coroutineOwner">Le MonoBehaviour qui possede le coroutine.</param>
        /// <param name="onStart">Le delegate appele lorsque le jeu demarre.</param>
        /// <param name="onEnd">Le delegate appele lorsque le jeu se termine.</param>
        /// <param name="onEndSoon">Le delegate appele lorsque le jeu est sur le point de se terminer.</param>
        public GameTimer(float duration, MonoBehaviour coroutineOwner, Action onStart, Action onEnd, Action onEndSoon)
        {
            this._duration = duration;
            this._coroutineOwner = coroutineOwner;
            this._onStart = onStart;
            this._onEnd = onEnd;
            this._onEndSoon = onEndSoon;
        }

        /// <summary>
        /// Commence le timer du jeu.
        /// </summary>
        public void Start() => StartTimerCoroutine();
        /// <summary>
        /// Force l'arret du timer du jeu.
        /// </summary>
        public void Stop() => StopTimerCoroutine();

        /// <summary>
        /// Commence la coroutine du timer du jeu.
        /// </summary>
        private void StartTimerCoroutine()
        {
            StopTimerCoroutine();
            _timerCoroutine = _coroutineOwner.StartCoroutine(TimerCoroutine());
        }
        /// <summary>
        /// Arrete la coroutine du timer du jeu.
        /// </summary>
        private void StopTimerCoroutine()
        {
            if (_timerCoroutine == null) return;

            _coroutineOwner.StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
            _onEnd.Invoke();
        }
        /// <summary>
        /// Coroutine du timer du jeu.
        /// </summary>
        /// <returns></returns>
        private IEnumerator TimerCoroutine()
        {
            //On appelle le delegate lorsque le jeu demarre.
            _onStart.Invoke();

            //si la duree de la partie est inferieure a 10 secondes, on passe directement aux dernieres secondes
            var timeBeforeLastSeconds = _duration < 10 ? 0 : _duration - 10;

            //si la duree de la partie est < a 10 secondes, on attend seulement la duree de la partie
            var lastSeconds = _duration < 10 ? _duration : 10;

            //on attend qu'il reste 10 secondes avant la fin de la partie
            yield return new WaitForSeconds(timeBeforeLastSeconds);
            _onEndSoon.Invoke();

            //On attend que le jeu soit termine pour appeler le delegate de fin de jeu.
            yield return new WaitForSeconds(lastSeconds);
            _onEnd.Invoke();
        }
    }
}