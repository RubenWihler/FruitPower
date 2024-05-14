/*
 TPI - 2024
 FruitPower - UI
 Wihler Ruben
 */

using UnityEngine;
using TMPro;
using GameManagement;

namespace UI
{
    /// <summary>
    /// Composant responsable de l'affichage du timer de jeu.
    /// Heritant de TextMeshProUGUI, il affiche le temps restant de la partie en secondes avec une precision de 2 decimales.
    /// </summary>
    public sealed class TimerVisualizer : TextMeshProUGUI
    {
        /// <summary>
        /// Indique si le timer est en cours.
        /// </summary>
        private bool _isTimerRunning;
        /// <summary>
        /// Temps restant de la partie.
        /// </summary>
        private float _localTimer;

        /// <summary>
        /// On s'abonne aux evenements de debut et de fin de jeu quand le composant s'active.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            GameManager.OnGameStart += OnGameStart;
            GameManager.OnGameEnd += OnGameStop;
        }
        /// <summary>
        /// On se desabonne aux evenements de debut et de fin de jeu quand le composant se desactive.
        /// </summary>
        protected override void OnDisable()
        {
            base.OnDisable();
            GameManager.OnGameStart -= OnGameStart;
            GameManager.OnGameEnd -= OnGameStop;
        }
        protected void Update()
        {
            // Si le timer n'est pas en cours, on ne fait rien.
            if (!_isTimerRunning) return;

            //On decremente le timer avec le temps ecoule depuis la derniere frame.
            _localTimer -= Time.deltaTime;

            // Si le timer est inferieur ou egal a 0, on l'arrete.
            if (_localTimer <= 0) StopTimer();

            //On met a jour le texte du timer avec le temps restant en secondes avec une precision de 2 decimales.
            text = $"{_localTimer:0.00} s";
        }

        private void OnGameStart(GameOption option) => StartTimer(option.gameDuration);
        private void OnGameStop() => StopTimer();

        private void StartTimer(float duration)
        {
            _localTimer = duration;
            _isTimerRunning = true;
        }
        private void StopTimer()
        {
            _localTimer = 0;
            _isTimerRunning = false;
        }
    }
}