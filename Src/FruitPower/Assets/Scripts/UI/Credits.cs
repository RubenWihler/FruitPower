/*
 TPI - 2024
 FruitPower - Credits
 Wihler Ruben
 */

using UnityEngine;

namespace UI
{
    /// <summary>
    /// Responsable de gerer l'affichage des credits.
    /// </summary>
    public sealed class Credits : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference vers le gameobject des credits")]
        private GameObject _credit;
        [SerializeField, Tooltip("Reference vers le gameobject parent du reste de l'interface")]
        private GameObject _other;

        /// <summary>
        /// Affiche les credits et cache le reste de l'interface.
        /// </summary>
        public void Show()
        {
            _credit.SetActive(true);
            _other.SetActive(false);
        }
        /// <summary>
        /// Cache les credits et affiche le reste de l'interface.
        /// </summary>
        public void Hide()
        {
            _credit.SetActive(false);
            _other.SetActive(true);
        }
    }
}