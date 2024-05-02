/*
 TPI - 2024
 FruitPower - Hand Controller
 Wihler Ruben
 */

using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    /// <summary>
    /// Classe permettant de faire le lien entre les inputs de l'utilisateur et l'animator de la main
    /// Cette classe vient de cette video : https://youtu.be/8PCNNro7Rt0?si=0TrR1SMeXGJ-hGe
    /// </summary>
    public sealed class HandController : MonoBehaviour
    {
        [Header("Input Actions")]
        [SerializeField, Tooltip("Reference vers l'input action de pinch")]
        private InputActionProperty pinchAction;
        [SerializeField, Tooltip("Reference vers l'input action de grip")]
        private InputActionProperty gripAction;

        [Header("Animaiton")]
        [SerializeField, Tooltip("Reference vers l'animator de la main")]
        private Animator animator;

        /// <summary>
        /// Recupere les valeurs des inputs et les envoies a l'animator
        /// </summary>
        private void Update()
        {
            //pinch
            var trigger_value = pinchAction.action.ReadValue<float>();
            animator.SetFloat("Trigger", trigger_value);

            //grip
            var grip_value = gripAction.action.ReadValue<float>();
            animator.SetFloat("Grip", grip_value);
        }
    }
}