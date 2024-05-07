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
        [SerializeField, Tooltip("Reference vers le meshRenderer dde la radio")]
        private MeshRenderer _meshRenderer;
        [SerializeField, Tooltip("Reference vers le boutton on/off")]
        private XRSimpleInteractable _onOffInteractor;
        [SerializeField, Tooltip("Reference vers le boutton: changer de music")]
        private XRSimpleInteractable _nextMusicInteractor;

        [Header("Materials")]
        [SerializeField, Tooltip("Materials de la radio par defaut")]
        private Material[] _defaultMaterials;
        [SerializeField, Tooltip("Materials de la radio quand le joueur survole le boutton on/off")]
        private Material[] _onOffHoverMaterials;
        [SerializeField, Tooltip("Materials de la radio quand le joueur survole le boutton: changer de music")]
        private Material[] _nextMusicHoverMaterials;

        /// <summary>
        /// On active les listeners lors de l'activation de l'objet
        /// </summary>
        private void OnEnable()
        {
            //materials par defaut
            OnHoverExit(null);

            // On ajoute les listeners pour les bouttons
            _onOffInteractor.activated.AddListener(OnOnOff);
            _nextMusicInteractor.activated.AddListener(OnNextMusic);

            // On ajoute les listeners pour les hover
            _onOffInteractor.hoverEntered.AddListener(OnOnOffHover);
            _nextMusicInteractor.hoverEntered.AddListener(OnNextMusicHover);
            _onOffInteractor.hoverExited.AddListener(OnHoverExit);
            _nextMusicInteractor.hoverExited.AddListener(OnHoverExit);
        }
        /// <summary>
        /// On desactive les listeners lors de la desactivation de l'objet
        /// </summary>
        private void OnDisable()
        {
            // On enleve les listeners pour les bouttons
            _onOffInteractor.activated.RemoveListener(OnOnOff);
            _nextMusicInteractor.activated.RemoveListener(OnNextMusic);

            // On enleve les listeners pour les hover
            _onOffInteractor.hoverEntered.RemoveListener(OnOnOffHover);
            _nextMusicInteractor.hoverEntered.RemoveListener(OnNextMusicHover);
            _onOffInteractor.hoverExited.RemoveListener(OnHoverExit);
            _nextMusicInteractor.hoverExited.RemoveListener(OnHoverExit);
        }

        /// <summary>
        /// Joue ou arrete la musique en fonction de l'etat actuel
        /// </summary>
        /// <param name="args"></param>
        private void OnOnOff(ActivateEventArgs args)
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
        private void OnNextMusic(ActivateEventArgs args)
        {
            MusicManager.Instance.NextMusic();
        }

        /// <summary>
        /// Mettre en surbrillance le boutton on/off quand le joueur le survole
        /// </summary>
        /// <param name="args"></param>
        private void OnOnOffHover(HoverEnterEventArgs args)
        {
            // Change les materials de la radio
            _meshRenderer.materials = _onOffHoverMaterials;
        }
        /// <summary>
        /// Mettre en surbrillance le boutton: changer de music quand le joueur le survole
        /// </summary>
        /// <param name="args"></param>
        private void OnNextMusicHover(HoverEnterEventArgs args)
        {
            // Change les materials de la radio
            _meshRenderer.materials = _nextMusicHoverMaterials;
        }
        /// <summary>
        /// Mettre les materials par defaut quand le joueur ne survole plus les bouttons
        /// </summary>
        /// <param name="args"></param>
        private void OnHoverExit(HoverExitEventArgs args)
        {
            // Rehover le boutton on/off si on est dessus
            if (_onOffInteractor.isHovered)
            {
                OnOnOffHover(null);
                return;
            }

            // Rehover le boutton changer de music si on est dessus
            if (_nextMusicInteractor.isHovered)
            {
                OnNextMusicHover(null);
                return;
            }

            // Change les materials de la radio
            _meshRenderer.materials = _defaultMaterials;
        }
    }
}