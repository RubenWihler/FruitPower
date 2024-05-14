/*
 TPI - 2024
 FruitPower - GameEndText
 Wihler Ruben
 */

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System;

namespace UI
{
    /// <summary>
    /// Classe responsable de l'affichage du texte de fin de partie.
    /// </summary>
    public sealed class GameEndText : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField, Tooltip("Le texte a afficher pour la fin de la partie")]
        private string _endText;

        [Header("Animation")]
        [SerializeField, Tooltip("Duree pendant laquelle le texte reste afficher(hors animaion d'entree et sortie)")]
        private float _neutralDuration = 1f;
        [SerializeField, Tooltip("Duree du deplacement vers la droite")]
        private float _rightSlideDuration = 1f;
        [SerializeField, Tooltip("Duree du deplacement vers la gauche")]
        private float _leftSlideDuration = 1f;
        [SerializeField, Tooltip("Valeur initial du deplacement vers la droit")]
        private int _rightSlideStart = 3272;
        [SerializeField, Tooltip("Valeur final du deplacement vers la gauche")]
        private int _leftSlideEnd = 3272;

        [Header("References")]
        [SerializeField, Tooltip("Le conteneur des texts")]
        private GameObject _container;
        [SerializeField, Tooltip("Le texte qui affiche le texte de fin de partie")]
        private TextMeshProUGUI _endTextComponent;
        [SerializeField, Tooltip("Le vertical layout group utilise pour l'animation")]
        private VerticalLayoutGroup _layoutGroup;

        /// <summary>
        /// Coroutine de l'animation.
        /// </summary>
        private Coroutine _animationCoroutine;
        /// <summary>
        /// Callback appele a la fin de l'animation.
        /// </summary>
        private Action _callback;

        /// <summary>
        /// Affiche le texte de fin de partie.
        /// </summary>
        /// <param name="callback"></param>
        public void Show(Action callback)
        {
            _callback = callback;
            StartAnimation();
        }

        private void StartAnimation()
        {
            StopAnimation();
            _animationCoroutine = StartCoroutine(Animate());
        }
        private void StopAnimation()
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);

            _animationCoroutine = null;
        }
        private IEnumerator Animate()
        {
            Debug.Log("Started animation");
            _container.SetActive(true);

            // Animation d'entree
            _layoutGroup.padding.right = _rightSlideStart;
            DOTween.To(() => _layoutGroup.padding.right, (x) => {
                _layoutGroup.padding.right = x;
                LayoutRebuilder.MarkLayoutForRebuild((RectTransform)_layoutGroup.transform);
            }, 0, _rightSlideDuration).Play();
            yield return new WaitForSecondsRealtime(_rightSlideDuration);
            
            // Animation de neutral
            yield return new WaitForSecondsRealtime(_neutralDuration);

            // Animation de sortie
            _layoutGroup.padding.left = 0;
            DOTween.To(() => _layoutGroup.padding.left, (x) =>
            {
                _layoutGroup.padding.left = x;
                LayoutRebuilder.MarkLayoutForRebuild((RectTransform)_layoutGroup.transform);
            }, _leftSlideEnd, _leftSlideDuration).Play();
            yield return new WaitForSecondsRealtime(_leftSlideDuration);

            // Fin de l'animation
            _container.SetActive(false);
            _layoutGroup.padding.left = 0;
            _layoutGroup.padding.right = 0;

            //Appel du callback
            _callback?.Invoke();
        }
    }
}