/*
 TPI - 2024
 FruitPower - Stats Visualizer
 Wihler Ruben
 */

using System.Collections.Generic;
using UnityEngine;

namespace UI.Stats
{
    public class StatsVisualizer : MonoBehaviour
    {
        [SerializeField, Tooltip("Prefab de l'element representant un fruit attrape.")]
        private GameObject _caughtFruitElementPrefab;

        [SerializeField, Tooltip("Parent des elements representant les fruits attrapes.")]
        private Transform _caughtFruitsParent;

        private List<CaughtFruitElement> _caughtFruitElements = new();

        /// <summary>
        /// Affiche les fruits attrapes et leur quantite.
        /// </summary>
        /// <param name="fruitsCatched">les fruits attrapes et leur quantite.</param>
        public void Display(Dictionary<string, uint> fruitsCatched)
        {
            // On detruit les elements representant les fruits attrapes precedemment.
            foreach (var caughtFruitElement in _caughtFruitElements)
            {
                Destroy(caughtFruitElement.gameObject);
            }
            _caughtFruitElements.Clear();

            // On cree les elements representant les fruits attrapes.
            foreach (var fruit in fruitsCatched)
            {
                var caughtFruitElement = Instantiate(_caughtFruitElementPrefab, _caughtFruitsParent).GetComponent<CaughtFruitElement>();
                caughtFruitElement.Display(GetFruitName(fruit.Key), fruit.Value);
                _caughtFruitElements.Add(caughtFruitElement);
            }
        }

        /// <summary>
        /// Donne le nom du fruit en fonction de son identifiant.
        /// </summary>
        /// <param name="fruitTypeId">l'identifiant du fruit.</param>
        /// <returns>le nom du fruit.</returns>
        private string GetFruitName(string fruitTypeId)
        {
            return fruitTypeId.ToLower().Replace("_", " ");
        }
    }
}