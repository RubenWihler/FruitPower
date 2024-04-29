using UnityEngine;
/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

namespace FruitSystem
{
    [RequireComponent(typeof(Collider))]
    public class Basket : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //si le collider de l'objet qui entre en collision avec le panier a un composant Fruit
            if (other.attachedRigidbody.TryGetComponent(out Fruit fruit)) CatchFruit(fruit);
        }

        private void CatchFruit(Fruit fruit)
        {
            //si le jeu n'est pas en cours, on ne fait rien
            if (GameManager.IsGameRunning == false) return;

            //ajout des points
            GameManager.Instance.AddPoints(fruit.Score);
            //on désactive le fruit
            fruit.Despawn();
        }
    }
}