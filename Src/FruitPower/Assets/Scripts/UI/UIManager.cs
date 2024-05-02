/*
 TPI - 2024
 FruitPower - UI Manager
 Wihler Ruben
 */

using UnityEngine;
using GameManagement;
using UI.Stats;

namespace UI
{

    /// <summary>
    /// Composant responsable de la gestion de l'interface utilisateur.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Tooltip("Distance de l'ecran par rapport à la tete du joueur [default: 1.2]")]
        private float _screenDistance = 1.2f;
        [SerializeField, Tooltip("Reference vers le transform de la tete du joueur")]
        private Transform _headTransform;

        [Header("Canvas references")]
        [SerializeField, Tooltip("Reference vers le canvas de l'affichage tete haute(HUD)")]
        private Canvas _hud;
        [SerializeField, Tooltip("Reference vers le canvas de fin de partie")]
        private Canvas _endGameUI;

        [Header("References")]
        [SerializeField, Tooltip("Reference vers le composant de l'affichage des statistiques")]
        private StatsVisualizer _statsVisualizer;
        [SerializeField, Tooltip("Reference vers le composant de l'affichage des credits")]
        private Credits _credits;

        /// <summary>
        /// On s'abonne aux evenements de debut et de fin de jeu quand le composant s'active.
        /// </summary>
        private void OnEnable()
        {
            GameManager.OnGameStart += OnGameStart;
            GameManager.OnGameEnd += OnGameEnd;
        }
        /// <summary>
        /// On se desabonne aux evenements de debut et de fin de jeu quand le composant se desactive.
        /// </summary>
        private void OnDisable()
        {
            GameManager.OnGameStart -= OnGameStart;
            GameManager.OnGameEnd -= OnGameEnd;
        }

        /// <summary>
        /// On met a jour la position des canvas de l'interface utilisateur a chaque frame.
        /// </summary>
        private void Update()
        {
            if (_endGameUI.isActiveAndEnabled) CenterEndGameUI();
            if (_hud.isActiveAndEnabled) CenterHud();
        }

        /// <summary>
        /// On desactive le canvas de fin de partie et on active le canvas de l'interface utilisateur au lancement de la partie.
        /// </summary>
        /// <param name="options"></param>
        private void OnGameStart(GameOption options)
        {
            SetActiveEndGameUI(false);
            SetActiveHUD(true);
        }
        /// <summary>
        /// On active le canvas de fin de partie et on desactive le canvas de l'HUD a la fin de la partie.
        /// </summary>
        private void OnGameEnd()
        {
            SetActiveEndGameUI(true);
            SetActiveHUD(false);

            _statsVisualizer.Display(GameManager.FruitsCaught);
        }

        /// <summary>
        /// On centre le canvas de fin de partie par rapport à la tete du joueur.
        /// </summary>
        private void CenterEndGameUI()
        {
            _endGameUI.transform.position = _headTransform.position + new Vector3(_headTransform.forward.x, 0, _headTransform.forward.z).normalized * _screenDistance;
            _endGameUI.transform.LookAt(new Vector3(_headTransform.position.x, _endGameUI.transform.position.y, _headTransform.position.z));
            _endGameUI.transform.forward *= -1;
        }
        /// <summary>
        /// On centre le canvas de l'HUD par rapport à la tete du joueur pour qu'il suivent l'orientation de la tete.
        /// </summary>
        private void CenterHud()
        {
            _hud.transform.position = _headTransform.position + _headTransform.forward.normalized * _screenDistance;
            _hud.transform.LookAt(_headTransform.position);
            _hud.transform.forward *= -1;
        }

        /// <summary>
        /// Active ou desactive le canvas de l'HUD.
        /// </summary>
        /// <param name="value"></param>
        private void SetActiveHUD(bool value)
        {
            _hud.enabled = value;
        }
        /// <summary>
        /// Active ou desactive le canvas de fin de partie.
        /// </summary>
        /// <param name="value"></param>
        private void SetActiveEndGameUI(bool value)
        {
            _endGameUI.enabled = value;
        }
    }
}