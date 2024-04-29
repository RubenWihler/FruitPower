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
    /// <summary>
    /// Classe représentant un fruit. Un fruit est un objet interactif qui peut être ramassé par un joueur pour gagner des points.
    /// Il peut etre dans plusieurs états: <see cref="FruitState.Inactive"/>, <see cref="FruitState.Attached"/>, <see cref="FruitState.Grabbed"/> et <see cref="FruitState.Neutral"/>.
    /// Les fruit sont gérés par un <see cref="FruitPooler"/> qui permet de recycler les fruits.
    /// </summary>
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
        
        /// <summary>
        /// Evénement appelé lorsque le fruit entre dans l'état "attaché".
        /// </summary>
        private event Action OnEnterAttached;
        /// <summary>
        /// Evénement appelé lorsque le fruit quitte l'état "attaché".
        /// </summary>
        public event Action OnExitAttached;

        /// <summary>
        /// L'identifiant unique du fruit (Ne change jamais meme apres un cycle de pool).
        /// </summary>
        public ulong Id { get => _id; set => _id = value; }
        /// <summary>
        /// L'identifiant du type de fruit.
        /// </summary>
        public string TypeId { get => _typeId; set => _typeId = value;}
        /// <summary>
        /// Le score que le joueur gagne en ramassant le fruit.
        /// </summary>
        public ushort Score { get => _score; set => _score = value; }
        /// <summary>
        /// Retourne l'état actuel du fruit.
        /// </summary>
        public FruitState State { get => _state; set => _state = value; }

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
        /// Cette méthode est appelée par le <see cref="FruitPooler"/> lors de l'initialisation d'un fruit (appelee qu'une seule fois).
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
        /// <summary>
        /// Fait disparaitre le fruit et le met en état "inactive".
        /// </summary>
        /// <returns>se retourne soi-meme.</returns>
        public Fruit Despawn()
        {
            SetState(FruitState.Inactive);
            gameObject.SetActive(false);
            _onDespawn.Invoke(this);
            return this;
        }

        /// <summary>
        /// Attache le fruit à une position et une rotation spécifiée ainsi que le met en état "attaché".
        /// Cette méthode est appelée par un <see cref="FruitSpawner"/> lorsqu'un fruit y est attaché.
        /// </summary>
        /// <param name="position">la position à laquelle attacher le fruit.</param>
        /// <param name="rotation">la rotation à laquelle attacher le fruit.</param>
        /// <returns>se retourne soi-meme.</returns>
        public Fruit Attach(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
            SetState(FruitState.Attached);
            return this;
        }

        #region XR Interaction

        /// <summary>
        /// Appelé lorsqu'un joueur attrape le fruit.
        /// Lorsque le fruit est attrapé, il est mis en état "grabbed" et la coroutine de durée de vie est arrêtée.
        /// </summary>
        /// <param name="args"></param>
        private void OnGrab(SelectEnterEventArgs args)
        {
            if (_state == FruitState.Inactive) return;

            //si le fruit est attaché, le mettre en état "grabbed"
            SetState(FruitState.Grabbed);

            //arrêter la coroutine de durée de vie
            StopLifetimeCoroutine();
        }
        /// <summary>
        /// Appelé lorsqu'un joueur lâche le fruit.
        /// Lorsque le fruit est lâché, il est mis en état "neutral" et la coroutine de durée de vie est relancée.
        /// </summary>
        /// <param name="args"></param>
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

        /// <summary>
        /// Définit l'état du fruit.
        /// </summary>
        /// <param name="state">Le nouvel état du fruit.</param>
        private void SetState(FruitState state)
        {
            //si l'état est le même, ne rien faire
            if (_state == state) return;

            //quitter l'état actuel et appeler les événements de sortie
            switch (_state)
            {
                case FruitState.Attached:
                    OnExitAttached?.Invoke();
                    break;

                default:
                    break;
            }

            //entrer dans le nouvel état et appeler les événements d'entrée
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

        /// <summary>
        /// Appelé lorsqu'un fruit entre dans l'état "attache".
        /// </summary>
        private void OnEnterAttachedState()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        /// <summary>
        /// Appelé lorsqu'un fruit quitte l'état "attache".
        /// </summary>
        private void OnExitAttachedState()
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
        }

        #endregion

        #region Lifecycle Management

        /// <summary>
        /// Commence la coroutine de durée de vie du fruit.
        /// </summary>
        private void StartLifetimeCoroutine()
        {
            StopLifetimeCoroutine();
            _lifetimeCoroutine = StartCoroutine(LifetimeCoroutine());
        }
        /// <summary>
        /// Force l'arret de la coroutine de durée de vie du fruit.
        /// </summary>
        private void StopLifetimeCoroutine()
        {
            if (_lifetimeCoroutine != null)
                StopCoroutine(_lifetimeCoroutine);
        }
        /// <summary>
        /// Coroutine de durée de vie du fruit.
        /// Une fois le temps écoulé, le fruit est désactivé.
        /// </summary>
        /// <returns></returns>
        private IEnumerator LifetimeCoroutine()
        {
            yield return new WaitForSeconds(_lifetime);
            Despawn();
            Debug.Log($"[i] Fruit despawned: {Id}");
        }

        #endregion
    }
}