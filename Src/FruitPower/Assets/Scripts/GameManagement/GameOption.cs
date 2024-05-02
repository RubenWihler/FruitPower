/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using UnityEngine;

/// <summary>
/// Structure qui contient les options du jeu.
/// </summary>
[System.Serializable]
public struct GameOption
{
    [Header("Game Options")]
    [Tooltip("Le temps de jeu en secondes.")]
    public float gameTime;
    [Tooltip("Le nombre d'apparition de fruits par seconde.")]
    public ushort spawnerRate;

    


}
