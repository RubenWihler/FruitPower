/*
 TPI - 2024
 FruitPower - ScoreVisualizer
 Wihler Ruben
 */

using UnityEngine;
using TMPro;
using GameManagement;

namespace UI
{
    public sealed class ScoreVisualizer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Tooltip("Format du texte du score [score = $]")]
        private string _scoreTextFormat = "$ points";

        [Header("References")]
        [SerializeField, Tooltip("Text affichant le score")]
        private TextMeshProUGUI _scoreText;
        
        /// <summary>
        /// Abonne la methode SetScore a l'evenement OnScoreChange quand le script est active
        /// </summary>
        private void OnEnable() => GameManager.OnScoreChange += SetScore;
        /// <summary>
        /// Desabonne la methode SetScore a l'evenement OnScoreChange quand le script est desactive
        /// </summary>
        private void OnDisable() => GameManager.OnScoreChange -= SetScore;

        /// <summary>
        /// Met a jour le score affiche a l'ecran
        /// </summary>
        /// <param name="score"></param>
        private void SetScore(int score)
        {
            //on met a jour le score affiche a l'ecran
            _scoreText.text = _scoreTextFormat.Replace("$", score.ToString());
        }
    }
}