/*
 TPI - 2024
 FruitPower - GameTimer
 Wihler Ruben
 */

using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    /// <summary>
    /// Classe responsable de la gestion du score du jeu.
    /// </summary>
    public sealed class GameScore
    {
        /// <summary>
        /// Score du jeu.
        /// </summary>
        private int _score;

        /// <summary>
        /// Propriete permettant d'acceder au score du jeu.
        /// </summary>
        public int Score => _score;

        /// <summary>
        /// Constructeur de la classe GameScore.
        /// </summary>
        /// <param name="score">le score initial du jeu. (default: 0)</param>
        public GameScore(int score = 0)
        {
            this._score = score;
        }

        /// <summary>
        /// Methode permettant d'ajouter des points au score du jeu.
        /// </summary>
        /// <param name="points">Le nombre de points a ajouter.</param>
        /// <returns>le nouveau score du jeu.</returns>
        public int AddPoints(int points)
        {
            // Verifie si le score est trop eleve pour etre ajoute.
            if (_score + points > int.MaxValue)
            {
                Debug.LogWarning($"[!] Le score est trop eleve pour etre ajoute. (max: {int.MaxValue})");
                _score = int.MaxValue;
            }
            else
            {
                _score += points;
            }

            return _score;
        }
    }
}