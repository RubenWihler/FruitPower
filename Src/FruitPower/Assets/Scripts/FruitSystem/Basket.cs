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
    public class Basket : MonoBehaviour
    {
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

            //ajout des points
            GameManager.AddPoints(fruit.Score, fruit.TypeId);
            //on desactive le fruit
            fruit.Despawn();
        }
    }
}