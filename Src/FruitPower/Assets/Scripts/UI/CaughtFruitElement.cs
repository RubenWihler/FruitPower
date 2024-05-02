/*
 TPI - 2024
 FruitPower - CaughtFruitElement
 Wihler Ruben
 */

using UnityEngine;
using TMPro;

namespace UI.Stats
{
    public class CaughtFruitElement : MonoBehaviour
    {
        [SerializeField, Tooltip("Texte affichant le nom du fruit.")]
        private TextMeshProUGUI _fruitName;

        [SerializeField, Tooltip("Texte affichant la quantité de fruit attrapé.")]
        private TextMeshProUGUI _fruitQuantity;

        /// <summary>
        /// Change le texte affichant le nom du fruit et la quantité de fruit attrape.
        /// </summary>
        /// <param name="fruitName">le nom du fruit</param>
        /// <param name="quantity">la quantité de fruit attrapé</param>
        public void Display(string fruitName, uint quantity)
        {
            _fruitName.text = $"- {fruitName} :";
            _fruitQuantity.text = quantity.ToString();
        }
    }
}