/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameOption
{
    [Header("Game Options")]
    [Tooltip("Le temps de jeu en secondes.")]
    public float gameTime;
    [Tooltip("Le nombre d'apparition de fruits par seconde.")]
    public ushort spawnerRate;

    


}
