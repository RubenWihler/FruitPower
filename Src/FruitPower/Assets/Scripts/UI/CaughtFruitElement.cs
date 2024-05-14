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
    /// <summary>
    /// Composant representant un element affichant le nom et la quantite d'un fruit attrape.
    /// </summary>
    public sealed class CaughtFruitElement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField, Tooltip("Texte affichant le nom du fruit.")]
        private TextMeshProUGUI _fruitName;
        [SerializeField, Tooltip("Texte affichant la quantite de fruit attrape.")]
        private TextMeshProUGUI _fruitQuantity;

        [Header("Settings")]
        [SerializeField, Tooltip("Le facteur d'echelle du texte pendant l'animation.")]
        private float _textScale = 1.2f;
        [SerializeField, Tooltip("Duree de l'animation d'entree.")]
        private float _inDuration = 0.2f;
        [SerializeField, Tooltip("Duree de l'animation de sortie.")]
        private float _outDuration = 0.2f;

        /// <summary>
        /// Change le texte affichant le nom du fruit et la quantite de fruit attrape.
        /// </summary>
        /// <param name="fruitTypeData">le nom du fruit</param>
        /// <param name="quantity">la quantite de fruit attrape</param>
        public IEnumerator Display(FruitTypeData fruitTypeData, uint quantity)
        {
            //on affiche le nom du fruit et la quantite de fruit attrape
            _fruitName.text = $"- {fruitTypeData.fruitName} :";
            _fruitQuantity.text = quantity.ToString();

            //on cree une sequence d'animation pour animer l'affichage du fruit attrape
            yield return DOTween.Sequence()
                .Append(_fruitName.transform.DOScale(_textScale, _inDuration).SetEase(Ease.OutBack).Play())
                .Join(_fruitQuantity.transform.DOScale(_textScale, _inDuration).SetEase(Ease.OutBack).Play())
                .AppendInterval(_inDuration)
                .Append(_fruitName.transform.DOScale(1f, _outDuration).SetEase(Ease.OutCubic))
                .Join(_fruitQuantity.transform.DOScale(1f, _outDuration).SetEase(Ease.OutCubic))
                .AppendInterval(_outDuration)
                .Play()
                .WaitForCompletion();
        }
    }
}