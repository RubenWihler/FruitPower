/*
 TPI - 2024
 FruitPower - Stats Visualizer
 Wihler Ruben
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Stats
{
    /// <summary>
    /// Classe permettant d'afficher les fruits attrapes dans le menu de fin de partie.
    /// Utilise des <see cref="CaughtFruitElement"/> pour afficher les fruits attrapes."/>
    /// </summary>
    public sealed class StatsVisualizer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Tooltip("Temps d'attente entre l'affichage de chaque fruit attrape.")]
        private float _timeBetweenFruits = 0.1f;

        [Header("References")]
        [SerializeField, Tooltip("Prefab de l'element representant un fruit attrape.")]
        private GameObject _caughtFruitElementPrefab;

        [SerializeField, Tooltip("Parent des elements representant les fruits attrapes.")]
        private Transform _caughtFruitsParent;

        /// <summary>
        /// Liste des elements representant les fruits attrapes.
        /// </summary>
        private List<CaughtFruitElement> _caughtFruitElements = new();

        /// <summary>
        /// Affiche les fruits attrapes et leur quantite.
        /// </summary>
        /// <param name="fruitsCatched">les fruits attrapes et leur quantite.</param>
        public void Display(Dictionary<string, uint> fruitsCatched)
        {
            Clear();
            StartCoroutine(AnimateDisplay(fruitsCatched));
        }

        /// <summary>
        /// Efface les elements representant les fruits attrapes.
        /// </summary>
        private void Clear()
        {
            // On detruit les elements representant les fruits attrapes precedemment.
            foreach (var caughtFruitElement in _caughtFruitElements)
            {
                Destroy(caughtFruitElement.gameObject);
            }
            _caughtFruitElements.Clear();
        }

        /// <summary>
        /// Affiche les fruits attrapes un par un.
        /// </summary>
        /// <param name="fruitsCatched"></param>
        /// <returns></returns>
        private IEnumerator AnimateDisplay(Dictionary<string, uint> fruitsCatched)
        {
            // On cree les elements representant les fruits attrapes.
            foreach (var fruit in fruitsCatched)
            {
                // On anime l'element representant le fruit attrape.
                yield return AnimateElement((fruit.Key, fruit.Value));
                
                // On attend un certain temps avant d'afficher le prochain fruit attrape.
                yield return new WaitForSeconds(_timeBetweenFruits);
            }
        }
        /// <summary>
        /// Anime l'element representant un fruit attrape.
        /// </summary>
        /// <param name="fruitCatched"></param>
        /// <returns></returns>
        private IEnumerator AnimateElement((string typeId, uint quantity) fruitCatched)
        {
            // On instancie un element representant un fruit attrape.
            var caughtFruitElement = Instantiate(_caughtFruitElementPrefab, _caughtFruitsParent).GetComponent<CaughtFruitElement>();
            var fruitData = FruitSystem.FruitManager.GetFruitTypeData(fruitCatched.typeId);

            _caughtFruitElements.Add(caughtFruitElement);
            yield return caughtFruitElement.Display(fruitData, fruitCatched.quantity);
        }
    }
}