/*
 TPI - 2024
 FruitPower - GameTimer
 Wihler Ruben
 */

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
        private ulong _score;

        /// <summary>
        /// Constructeur de la classe GameScore.
        /// </summary>
        /// <param name="score">le score initial du jeu. (default: 0)</param>
        public GameScore(ulong score = 0)
        {
            this._score = score;
        }

        /// <summary>
        /// Propriete permettant d'acceder au score du jeu.
        /// </summary>
        public ulong Score => _score;

        /// <summary>
        /// Methode permettant d'ajouter des points au score du jeu.
        /// </summary>
        /// <param name="points">Le nombre de points à ajouter.</param>
        /// <returns>le nouveau score du jeu.</returns>
        public ulong AddPoints(ulong points)
        {
            // Verifie si le score est trop eleve pour etre ajoute.
            if (_score + points > ulong.MaxValue)
            {
                Debug.LogWarning($"[!] Le score est trop eleve pour etre ajoute. (max: {ulong.MaxValue})");
                _score = ulong.MaxValue;
            }
            else
            {
                _score += points;
            }

            return _score;
        }
    }
}