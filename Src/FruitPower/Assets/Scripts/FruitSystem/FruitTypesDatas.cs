/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using UnityEngine;

namespace FruitSystem
{
    /// <summary>
    /// Scriptable object contenant les donnees des differents types de fruits.
    /// </summary>
    [CreateAssetMenu(fileName = "FruitsDatas", menuName = "FruitSystem/FruitsDatas")]
    public sealed class FruitTypesDatas : ScriptableObject
    {
        [Tooltip("Les donnees des differents types de fruits.")]
        public FruitTypeData[] datas;
    }
}