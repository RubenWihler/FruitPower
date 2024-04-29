/*
 TPI - 2024
 FruitPower - UI
 Wihler Ruben
 */

using UnityEngine;
using TMPro;

namespace UI
{
    public class ScoreVisualizer : MonoBehaviour
    {
        [SerializeField, Tooltip("Text affichant le score")]
        private TextMeshProUGUI _scoreText;

        [SerializeField, Tooltip("Format du texte du score [score = $]")]
        private string _scoreTextFormat = "$ points";

        private void OnEnable()
        {
            GameManager.OnScoreChange += SetScore;
        }
        private void OnDisable()
        {
            GameManager.OnScoreChange -= SetScore;
        }


        private void SetScore(int score)
        {
            _scoreText.text = _scoreTextFormat.Replace("$", score.ToString());
        }
    }
}