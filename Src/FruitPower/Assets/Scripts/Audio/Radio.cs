/*
 TPI - 2024
 FruitPower - Radio
 Wihler Ruben
 */

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Audio
{
    /// <summary>
    /// Classe responsable de la gestion de la radio
    /// </summary>
    public class Radio : MonoBehaviour
    {
        [Header("References")]
        [SerializeField, Tooltip("Reference vers le boutton on/off")]
        private XRSimpleInteractable _onOffInteractor;
        [SerializeField, Tooltip("Reference vers le boutton: changer de music")]
        private XRSimpleInteractable _nextMusicInteractor;

        /// <summary>
        /// On active les listeners lors de l'activation de l'objet
        /// </summary>
        private void OnEnable()
        {
            _onOffInteractor.selectEntered.AddListener(OnOnOff);
            _nextMusicInteractor.selectEntered.AddListener(OnNextMusic);
        }
        /// <summary>
        /// On desactive les listeners lors de la desactivation de l'objet
        /// </summary>
        private void OnDisable()
        {
            _onOffInteractor.selectEntered.RemoveListener(OnOnOff);
            _nextMusicInteractor.selectEntered.RemoveListener(OnNextMusic);
        }

        /// <summary>
        /// Joue ou arrete la musique en fonction de l'etat actuel
        /// </summary>
        /// <param name="args"></param>
        private void OnOnOff(SelectEnterEventArgs args)
        {
            // Si la musique est en train de jouer, on l'arrete
            if (MusicManager.Instance.IsPlaying) MusicManager.Instance.Stop();
            // Sinon on la joue
            else MusicManager.Instance.Play();
        }
        /// <summary>
        /// Passe a la musique suivante
        /// </summary>
        /// <param name="args"></param>
        private void OnNextMusic(SelectEnterEventArgs args)
        {
            MusicManager.Instance.NextMusic();
        }
    }
}