/*
 TPI - 2024
 FruitPower - UI
 Wihler Ruben
 */

using UnityEngine.UI;
using GameManagement;

namespace UI
{
    /// <summary>
    /// Composant responsable du bouton de demarrage du jeu.
    /// </summary>
    public class PlayButton : Button
    {
        /// <summary>
        /// On override la methode Start pour ajouter un listener au bouton.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            //On ajoute un listener pour demarrer le jeu lorsque le bouton est clique.
            onClick.AddListener(() => GameManager.StartGame());
        }
    }
}