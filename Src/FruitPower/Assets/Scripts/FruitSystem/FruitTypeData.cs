/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using UnityEngine;

namespace FruitSystem
{
    /// <summary>
    /// Objet de donnees representant un type de fruit.
    /// </summary>
    [System.Serializable]
    public struct FruitTypeData
    {
        [Tooltip("Identifiant du fruit.")]
        public string fruitId;
        [Tooltip("Nom du fruit.")]
        public string fruitName;
        [Tooltip("Nombre de points donnes par le fruit.")]
        public ushort pointsGiven;
        [Tooltip("Duree de vie du fruit.")]
        public float lifeTime;
    }
}