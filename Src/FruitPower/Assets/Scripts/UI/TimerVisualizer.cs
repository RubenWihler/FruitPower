/*
 TPI - 2024
 FruitPower - UI
 Wihler Ruben
 */

using UnityEngine;
using TMPro;

namespace UI
{
    public class TimerVisualizer : MonoBehaviour
    {
        [SerializeField, Tooltip("Text affichant le temps restant")]
        private TextMeshProUGUI timerText;

        private bool _isTimerRunning;
        private float _localTimer;

        private void OnEnable()
        {
            GameManager.OnGameStart += OnGameStart;
            GameManager.OnGameEnd += OnGameStop;
        }
        private void OnDisable()
        {
            GameManager.OnGameStart -= OnGameStart;
            GameManager.OnGameEnd -= OnGameStop;
        }

        private void OnGameStart(GameOption option) => StartTimer(option.gameTime);
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

        private void Update()
        {
            if (!_isTimerRunning) return;

            _localTimer -= Time.deltaTime;

            if (_localTimer <= 0) _localTimer = 0;

            timerText.text = $"{_localTimer:0.00} s";
        }
    }
}