using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    public class HandController : MonoBehaviour
    {
        [Header("Input Actions")]
        [SerializeField]
        private InputActionProperty pinchAnimationAction;
        [SerializeField]
        private InputActionProperty gripAnimationAction;

        [Header("Animaiton")]
        [SerializeField]
        private Animator animator;


        void Start()
        {

        }

        void Update()
        {
            var trigger_value = pinchAnimationAction.action.ReadValue<float>();
            animator.SetFloat("Trigger", trigger_value);

            var grip_value = gripAnimationAction.action.ReadValue<float>();
            animator.SetFloat("Grip", grip_value);
        }

    }

}
