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
    /// Classe representant un fruit. Un fruit est un objet interactif qui peut etre ramasse par un joueur pour gagner des points.
    /// Il peut etre dans plusieurs etats: <see cref="FruitState.Inactive"/>, <see cref="FruitState.Attached"/>, <see cref="FruitState.Grabbed"/> et <see cref="FruitState.Neutral"/>.
    /// Les fruit sont geres par un <see cref="FruitPooler"/> qui permet de recycler les fruits.
    /// </summary>
    [RequireComponent(typeof(XRGrabInteractable), typeof(Rigidbody))]
    public sealed class Fruit : MonoBehaviour
    {
        [Header("Fruit Settings")]
        [SerializeField, Tooltip("Identifiant du type de fruit.")]
        private string _typeId;
        [Header("Model et materials")]
        [SerializeField, Tooltip("MeshRenderer du fruit.")]
        private MeshRenderer _meshRenderer;
        [SerializeField, Tooltip("Materials par defaut du fruit.")]
        private Material[] _defaultMaterials;
        [SerializeField, Tooltip("Materials lorsque le fruit est attrapable ou attrape par le joueur.")]
        private Material[] _hoverMaterials;
        [Header("Audio")]
        [SerializeField, Tooltip("AudioSource pour les sons du fruit.")]
        private AudioSource _audioSource;
        [SerializeField, Tooltip("AudioClips qui se joue lorsque le fruit est attrape.")]
        private AudioClip[] _fruitGrabAudioClips;
        [SerializeField, Tooltip("AudioClips qui se joue lorsque le fruit entre en collision avec de l'herbe.")]
        private AudioClip[] _fruitGrassCollisionAudioClips;
        [SerializeField, Tooltip("AudioClips qui se joue lorsque le fruit entre en collision avec de la pierre.")]
        private AudioClip[] _fruitRockCollisionAudioClips;

        /// <summary>
        /// Identifiant unique du fruit.
        /// </summary>
        private ulong _id;
        /// <summary>
        /// Le nombre de points que le joueur gagne en ramassant le fruit.
        /// </summary>
        private ushort _pointGiven;
        /// <summary>
        /// Le temps de vie du fruit.
        /// </summary>
        private float _lifetime;
        /// <summary>
        /// L'etat actuel du fruit.
        /// </summary>
        private FruitState _state;
        /// <summary>
        /// La coroutine de duree de vie du fruit.
        /// </summary>
        private Coroutine _lifetimeCoroutine;
        /// <summary>
        /// Le composant XRGrabInteractable du fruit.
        /// </summary>
        private XRGrabInteractable _grabInteractable;
        /// <summary>
        /// Le composant Rigidbody du fruit.
        /// </summary>
        private Rigidbody _rigidbody;
        /// <summary>
        /// L'action appelee lors du despawn du fruit.
        /// </summary>
        private Action<Fruit> _onDespawn;
        
        /// <summary>
        /// Evenement appele lorsque le fruit entre dans l'etat "attache".
        /// </summary>
        private event Action OnEnterAttached;
        /// <summary>
        /// Evenement appele lorsque le fruit quitte l'etat "attache".
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
        /// Le nombre de points que le joueur gagne en ramassant le fruit.
        /// </summary>
        public ushort PointsGiven { get => _pointGiven; set => _pointGiven = value; }
        /// <summary>
        /// Retourne l'etat actuel du fruit.
        /// </summary>
        public FruitState State { get => _state; set => _state = value; }

        /// <summary>
        /// Prend les composants XRGrabInteractable et Rigidbody du fruit et initialise les evenements de l'interactable.
        /// </summary>
        private void Awake()
        {
            _grabInteractable = GetComponent<XRGrabInteractable>();
            _grabInteractable.selectEntered.AddListener(OnGrab);
            _grabInteractable.selectExited.AddListener(OnDrop);
            _grabInteractable.hoverEntered.AddListener(OnEnterHover);
            _grabInteractable.hoverExited.AddListener(OnExitHover);

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        /// <summary>
        /// Initialise le fruit avec un identifiant unique.
        /// Cette methode est appelee par le <see cref="FruitPooler"/> lors de l'initialisation d'un fruit (appelee qu'une seule fois).
        /// </summary>
        /// <param name="id">l'identifiant unique du fruit.</param>
        /// <returns>se retourne soi-meme.</returns>
        public Fruit Initialize(ulong id, Action<Fruit> onDespawn)
        {
            var fruitTypeData = FruitManager.GetFruitTypeData(_typeId);
            _pointGiven = fruitTypeData.pointsGiven;
            _lifetime = fruitTypeData.lifeTime;
            _id = id;

            _state = FruitState.Inactive;
            gameObject.SetActive(false);
            _onDespawn = onDespawn;

            OnEnterAttached += OnEnterAttachedState;
            OnExitAttached += OnExitAttachedState;

            return this;
        }

        /// <summary>
        /// Fait apparaitre le fruit, l'attache a un FruitSpawner et demarre le coroutine de duree de vie.
        /// </summary>
        /// <returns></returns>
        public Fruit Spawn()
        {
            gameObject.SetActive(true);
            StartLifetimeCoroutine();
            return this;
        }
        /// <summary>
        /// Fait disparaitre le fruit et le met en etat "inactive".
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
        /// Attache le fruit a une position et une rotation specifiee ainsi que le met en etat "attache".
        /// Cette methode est appelee par un <see cref="FruitSpawner"/> lorsqu'un fruit y est attache.
        /// </summary>
        /// <param name="position">la position a laquelle attacher le fruit.</param>
        /// <param name="rotation">la rotation a laquelle attacher le fruit.</param>
        /// <returns>se retourne soi-meme.</returns>
        public Fruit Attach(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
            SetState(FruitState.Attached);
            return this;
        }

        #region XR Interaction

        /// <summary>
        /// Appele lorsqu'un joueur attrape le fruit.
        /// Lorsque le fruit est attrape, il est mis en etat "grabbed" et la coroutine de duree de vie est arretee.
        /// </summary>
        /// <param name="args"></param>
        private void OnGrab(SelectEnterEventArgs args)
        {
            if (_state == FruitState.Inactive) return;

            //si le fruit est attache, le mettre en etat "grabbed"
            SetState(FruitState.Grabbed);

            //arreter la coroutine de duree de vie
            StopLifetimeCoroutine();

            //jouer un son aleatoire de fruit attrape
            _fruitGrabAudioClips.PlayRandom(_audioSource);
        }
        /// <summary>
        /// Appele lorsqu'un joueur lache le fruit.
        /// Lorsque le fruit est lache, il est mis en etat "neutral" et la coroutine de duree de vie est relancee.
        /// </summary>
        /// <param name="args"></param>
        private void OnDrop(SelectExitEventArgs args)
        {
            if (_state == FruitState.Inactive) return;

            //mettre le fruit en etat "neutral" lorsqu'il est lache
            SetState(FruitState.Neutral);

            //relancer la coroutine de duree de vie
            StartLifetimeCoroutine();
        }

        /// <summary>
        /// Appele lorsque le fruit entre dans la zone de survol d'un joueur.
        /// </summary>
        /// <param name="args"></param>
        private void OnEnterHover(HoverEnterEventArgs args)
        {
            if (_state == FruitState.Inactive) return;

            _meshRenderer.materials = _hoverMaterials;
        }
        /// <summary>
        /// Appele lorsque le fruit quitte la zone de survol d'un joueur.
        /// </summary>
        /// <param name="args"></param>
        private void OnExitHover(HoverExitEventArgs args)
        {
            _meshRenderer.materials = _defaultMaterials;
        }

        #endregion

        #region State Management

        /// <summary>
        /// Definit l'etat du fruit.
        /// </summary>
        /// <param name="state">Le nouvel etat du fruit.</param>
        private void SetState(FruitState state)
        {
            //si l'etat est le meme, ne rien faire
            if (_state == state) return;

            //quitter l'etat actuel et appeler les evenements de sortie
            switch (_state)
            {
                case FruitState.Attached:
                    OnExitAttached?.Invoke();
                    break;

                default:
                    break;
            }

            //entrer dans le nouvel etat et appeler les evenements d'entree
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
        /// Appele lorsqu'un fruit entre dans l'etat "attache".
        /// </summary>
        private void OnEnterAttachedState()
        {
            //bloquer le rigidbody et le mettre en mode de detection de collision discret
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
        }
        /// <summary>
        /// Appele lorsqu'un fruit quitte l'etat "attache".
        /// </summary>
        private void OnExitAttachedState()
        {
            //debloquer le rigidbody et le mettre en mode de detection de collision continu (pour eviter les traversees de murs)
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        #endregion

        #region Lifecycle Management

        /// <summary>
        /// Commence la coroutine de duree de vie du fruit.
        /// </summary>
        private void StartLifetimeCoroutine()
        {
            StopLifetimeCoroutine();
            _lifetimeCoroutine = StartCoroutine(LifetimeCoroutine());
        }
        /// <summary>
        /// Force l'arret de la coroutine de duree de vie du fruit.
        /// </summary>
        private void StopLifetimeCoroutine()
        {
            if (_lifetimeCoroutine != null)
                StopCoroutine(_lifetimeCoroutine);
        }
        /// <summary>
        /// Coroutine de duree de vie du fruit.
        /// Une fois le temps ecoule, le fruit est desactive.
        /// </summary>
        /// <returns></returns>
        private IEnumerator LifetimeCoroutine()
        {
            yield return new WaitForSeconds(_lifetime);
            Despawn();
        }

        #endregion

        #region Collision Management

        /// <summary>
        /// Joue un son aleatoire de collision en fonction du tag de la matiere qui entre en collision avec le fruit.
        /// </summary>
        /// <param name="collision">la colliison.</param>
        private void OnCollisionEnter(Collision collision)
        {
            if (_state == FruitState.Inactive) return;

            var other = collision.gameObject;

            //jouer un son aleatoire de collision en fonction du tag de la matiere
            if (other.CompareTag("Grass"))
                _fruitGrassCollisionAudioClips.PlayRandom(_audioSource);
            else if (other.CompareTag("Rock"))
                _fruitRockCollisionAudioClips.PlayRandom(_audioSource);
        }

        #endregion
    }
}