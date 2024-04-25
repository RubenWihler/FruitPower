/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FruitSystem
{
    [RequireComponent(typeof(XRGrabInteractable), typeof(Rigidbody))]
    public class Fruit : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Identifiant du type de fruit.")]
        private string _typeId;
        [SerializeField]
        [Tooltip("Score que le joueur gagne en ramassant le fruit.")]
        private ushort _score;
        [SerializeField]
        [Tooltip("La durée de vie du fruit en secondes.")]
        private float _lifetime;

        private ulong _id;
        private FruitState _state;
        private Coroutine _lifetimeCoroutine;
        private XRGrabInteractable _grabInteractable;
        private Rigidbody _rigidbody;
        private Action<Fruit> _onDespawn;
        
        private event Action OnEnterAttached;
        public event Action OnExitAttached;

        public ulong Id => _id;
        public string TypeId => _typeId;
        public ushort Score => _score;

        private void Awake()
        {
            _grabInteractable = GetComponent<XRGrabInteractable>();
            _grabInteractable.selectEntered.AddListener(OnGrab);
            _grabInteractable.selectExited.AddListener(OnDrop);

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        /// <summary>
        /// Initialise le fruit avec un identifiant unique.
        /// Cette méthode est appelée par le <see cref="FruitFactory"/> lors de l'instanciation d'un fruit.
        /// </summary>
        /// <param name="id">l'identifiant unique du fruit.</param>
        /// <returns>se retourne soi-meme.</returns>
        public Fruit Initialize(ulong id, Action<Fruit> onDespawn)
        {
            this._state = FruitState.Inactive;
            gameObject.SetActive(false);
            this._id = id;
            this._onDespawn = onDespawn;

            this.OnEnterAttached += OnEnterAttachedState;
            this.OnExitAttached += OnExitAttachedState;

            return this;
        }

        /// <summary>
        /// Fait apparaitre le fruit, l'attache a un FruitSpawner et démarre le coroutine de durée de vie.
        /// </summary>
        /// <returns></returns>
        public Fruit Spawn()
        {
            gameObject.SetActive(true);
            StartLifetimeCoroutine();
            return this;
        }
        public Fruit Despawn()
        {
            SetState(FruitState.Inactive);
            gameObject.SetActive(false);
            _onDespawn.Invoke(this);
            return this;
        }

        public Fruit Attach(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
            SetState(FruitState.Attached);
            return this;
        }

        #region XR Interaction

        private void OnGrab(SelectEnterEventArgs args)
        {
            if (_state == FruitState.Inactive) return;

            //si le fruit est attaché, le mettre en état "grabbed"
            SetState(FruitState.Grabbed);

            //arrêter la coroutine de durée de vie
            StopLifetimeCoroutine();
        }
        private void OnDrop(SelectExitEventArgs args)
        {
            if (_state == FruitState.Inactive) return;

            //mettre le fruit en état "neutral" lorsqu'il est lâché
            SetState(FruitState.Neutral);

            //relancer la coroutine de durée de vie
            StartLifetimeCoroutine();
        }

        #endregion

        #region State Management

        private void SetState(FruitState state)
        {
            //si l'état est le même, ne rien faire
            if (_state == state) return;

            //quitter l'état actuel
            switch (_state)
            {
                case FruitState.Attached:
                    OnExitAttached?.Invoke();
                    break;

                default:
                    break;
            }

            //entrer dans le nouvel état
            switch (state)
            {
                case FruitState.Attached:
                    OnEnterAttached?.Invoke();
                    break;

                default:
                    break;
            }

            _state = state;
        }

        private void OnEnterAttachedState()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        private void OnExitAttachedState()
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
        }

        #endregion

        #region Lifecycle Management

        private void StartLifetimeCoroutine()
        {
            StopLifetimeCoroutine();
            _lifetimeCoroutine = StartCoroutine(LifetimeCoroutine());
        }
        private void StopLifetimeCoroutine()
        {
            if (_lifetimeCoroutine != null)
                StopCoroutine(_lifetimeCoroutine);
        }
        private IEnumerator LifetimeCoroutine()
        {
            yield return new WaitForSeconds(_lifetime);
            Despawn();
            Debug.Log($"[i] Fruit despawned: {Id}");
        }

        #endregion
    }
}