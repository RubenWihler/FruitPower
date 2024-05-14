/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using UnityEngine;
using GameManagement;

namespace FruitSystem
{
    /// <summary>
    /// Composant representant un panier de fruits. Il permet de recuperer les fruits qui entrent dans sa zone de collision trigger.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public sealed class Basket : MonoBehaviour
    {
        [Header("Audio")]
        [SerializeField, Tooltip("Source audio pour les sons de capture de fruits")]
        private AudioSource _audioSource;
        [SerializeField, Tooltip("Sons joues quand un fruit est attrape")]
        private AudioClip[] _catchSounds;

        /// <summary>
        /// Quand un objet entre dans la zone de collision trigger du panier
        /// On regarde si l'objet a un composant Fruit et on l'attrape
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            //si le collider de l'objet qui entre en collision avec le panier a un composant Fruit, on attrape l'attrape
            if (other.attachedRigidbody.TryGetComponent(out Fruit fruit)) CatchFruit(fruit);
        }

        /// <summary>
        /// Ajoute les points du fruit attrape au score et desactive le fruit
        /// </summary>
        /// <param name="fruit">le fruit attrape</param>
        private void CatchFruit(Fruit fruit)
        {
            //si le jeu n'est pas en cours, on ne fait rien
            if (GameManager.IsGameRunning == false) return;

            //ajout des points (si l'ajout des points echoue, on ne fait rien)
            if (!GameManager.AddPoints(fruit.PointsGiven, fruit.TypeId)) return;

            //on joue un son aleatoire de capture
            _catchSounds.PlayRandom(_audioSource);

            //on desactive le fruit
            fruit.Despawn();
        }
    }
}