/*
 TPI - 2024
 FruitPower - CaughtFruitElement
 Wihler Ruben
 */

using UnityEngine;
using TMPro;
using FruitSystem;
using System.Collections;
using DG.Tweening;

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
        /// <param name="fruitTypeData">le nom du fruit</param>
        /// <param name="quantity">la quantité de fruit attrapé</param>
        public IEnumerator Display(FruitTypeData fruitTypeData, uint quantity)
        {
            //on affiche le nom du fruit
            _fruitName.text = $"- {fruitTypeData.fruitName} :";
            _fruitName.transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutBack).Play();

            //on affiche la quantité de fruit attrapé
            _fruitQuantity.text = quantity.ToString();
            _fruitQuantity.transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutBack).Play();

            yield return new WaitForSeconds(0.5f);
        }
    }
}