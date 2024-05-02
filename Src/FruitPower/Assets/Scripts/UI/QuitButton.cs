/*
 TPI - 2024
 FruitPower - UI
 Wihler Ruben
 */

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Bouton permettant de quitter l'application.
/// </summary>
public class QuitButton : Button
{
    /// <summary>
    /// On override la methode Start pour ajouter un listener qui permet de quitter l'application quand le bouton est clique.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        onClick.AddListener(() => Application.Quit());
    }
}
