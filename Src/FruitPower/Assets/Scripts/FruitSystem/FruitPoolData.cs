/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using UnityEngine;

namespace FruitSystem
{
    /// <summary>
    /// Structure qui contient les donnees d'un pool de fruits.
    /// </summary>
    [System.Serializable]
    public struct FruitPoolData
    {
        [Tooltip("Identifiant du type de fruit. (Le meme que dans le component Fruit)")]
        public string typeId;

        [Tooltip("Prefab qui contient le fruit.")]
        public GameObject prefab;
        
        [Tooltip("Nombre de fruits dans le pool. [default: 5]")]
        public ushort poolSize;
    }
}