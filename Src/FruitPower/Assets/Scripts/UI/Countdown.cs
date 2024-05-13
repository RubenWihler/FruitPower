using System.Collections;
using UnityEngine;
using TMPro;

namespace UI
{
    /// <summary>
    /// Classe responsable de l'affichage du compte a rebours.
    /// </summary>
    public class Countdown : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField, Tooltip("Le text a afficher pour la fin du compte a rebours")]
        private string _endText = "C'est parti";
        [SerializeField, Tooltip("Le temps du fade in des text")]
        private float _fadeInTime = 0.2f;
        [SerializeField, Tooltip("Le temps du fade out des text")]
        private float _fadeOutTime = 0.2f;
        [Header("References")]
        [SerializeField, Tooltip("Le conteneur des texts")]
        private GameObject _container;
        [SerializeField, Tooltip("Le texte qui affiche le compte a rebours")]
        private TextMeshProUGUI _countdownText;
        [Header("Audio")]
        [SerializeField, Tooltip("Le son du compte a rebours")]
        private AudioClip _countdownSound;

        /// <summary>
        /// Coroutine du compte a rebours.
        /// </summary>
        private Coroutine _countdownCoroutine;
        /// <summary>
        /// La duree du compte a rebours.
        /// </summary>
        private uint _duration;

        /// <summary>
        /// Commence le compte a rebours.
        /// </summary>
        /// <param name="duration">La duree du compte a rebours en secondes</param>
        public void StartCountdown(uint duration)
        {
            _duration = duration;
            StartCountdownCoroutine();
        }

        /// <summary>
        /// Commence le compte a rebours. (stop le compte a rebours actuel s'il y en a un)
        /// </summary>
        private void StartCountdownCoroutine()
        {
            StopCountdownCoroutine();
            _countdownCoroutine = StartCoroutine(CountdownCoroutine());
        }
        /// <summary>
        /// Stop le compte a rebours. (n'appelle pas le callback)
        /// </summary>
        private void StopCountdownCoroutine()
        {
            if (_countdownCoroutine != null)
                StopCoroutine(_countdownCoroutine);

            _countdownCoroutine = null;
        }
        /// <summary>
        /// La coroutine du compte a rebours.
        /// </summary>
        /// <returns></returns>
        private IEnumerator CountdownCoroutine()
        {
            //on affiche le conteneur
            _container.SetActive(true);

            //joue le son du compte a rebours
            AudioSource.PlayClipAtPoint(_countdownSound, Camera.main.transform.position);

            //animations du compte a rebours
            for (uint i = _duration; i > 0; i--)
            {
                yield return AnimateText(i.ToString());
            }

            //fin du compte a rebours
            yield return AnimateText(_endText);

            //on cache le conteneur
            _container.SetActive(false);
        }
        /// <summary>
        /// Une coroutine qui affiche un texte pendant un certain temps.
        /// </summary>
        /// <param name="text">le texte a afficher</param>
        /// <returns></returns>
        private IEnumerator AnimateText(string text)
        {
            _countdownText.gameObject.SetActive(true);
            _countdownText.text = text;
            _countdownText.CrossFadeAlpha(1, _fadeInTime, true);
            yield return new WaitForSecondsRealtime(1 - _fadeOutTime);
            _countdownText.CrossFadeAlpha(0, _fadeOutTime, true);
            yield return new WaitForSecondsRealtime(_fadeOutTime);
            _countdownText.gameObject.SetActive(false);
        }
    }
}