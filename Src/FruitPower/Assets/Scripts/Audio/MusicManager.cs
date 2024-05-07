/*
 TPI - 2024
 FruitPower - Music Manager
 Wihler Ruben
 */

using UnityEngine;
using DG.Tweening;
using GameManagement;
using UnityEngine.Audio;

namespace Audio
{
    /// <summary>
    /// Classe reponsable de la gestion de la musique
    /// </summary>
    public sealed class MusicManager : MonoBehaviour
    {
        #region Singleton

        private static MusicManager _instance;
        public static MusicManager Instance
        {
            get
            {
                if (_instance == null)
                    throw new System.Exception("Aucune instance de MusicManager n'a ete trouvee ! Assurez-vous qu'un MusicManager est present dans la scene.");

                return _instance;
            }
        }

        #endregion

        [Header("Settings")]
        [SerializeField, Tooltip("Volume de la musique dans le menu (quand aucune partie n'est lance)")]
        private float _menuVolume = 0.5f;
        [SerializeField, Tooltip("Volume de la musique en jeu")]
        private float _inGameVolume = 0.5f;
        [SerializeField, Tooltip("Duree de la transition du changement de volume")]
        private float _volumeTransitionDuration = 1f;
        [SerializeField, Tooltip("Nom du parametre de volume de la musique dans l'audio mixer")]
        private string _volumeParameterName = "MusicVolume";

        [Header("Musics")]
        [SerializeField, Tooltip("Liste des musiques disponibles")]
        private AudioClip[] _musics;

        [Header("References")]
        [SerializeField, Tooltip("Reference vers l'audio source de la musique")]
        private AudioSource _audioSource;
        [SerializeField, Tooltip("Reference vers l'audio mixer de la musique")]
        private AudioMixer _audioMixer;

        /// <summary>
        /// Le tween du volume de la musique
        /// </summary>
        private Tween _volumeTween;
        /// <summary>
        /// Si la musique est en train de jouer
        /// </summary>
        private bool _isPlaying = false;
        /// <summary>
        /// Index de la musique actuelle
        /// </summary>
        private uint _currentMusicIndex = 0;
        /// <summary>
        /// Temps actuel de la musique
        /// </summary>
        private float _currentMusicTime = 0;

        /// <summary>
        /// Indique si la musique est en train de jouer
        /// </summary>
        public bool IsPlaying => _isPlaying;

        /// <summary>
        /// Commence a jouer la musique ou la relance si elle est en pause
        /// </summary>
        public void Play()
        {
            _isPlaying = true;

            if (_audioSource.clip == null)
            {
                NextMusic();
                return;
            }

            _audioSource.Play();
        }
        /// <summary>
        /// Mets en pause la musique
        /// </summary>
        public void Stop()
        {
            _isPlaying = false;
            _audioSource.Pause();
        }
        /// <summary>
        /// Passe a la musique suivante
        /// </summary>
        public void NextMusic()
        {
            if (_currentMusicIndex + 1 >= _musics.Length) _currentMusicIndex = 0;
            else _currentMusicIndex++;

            _audioSource.clip = _musics[_currentMusicIndex];
            _audioSource.Play();
            _currentMusicTime = 0;
        }

        /// <summary>
        /// Setup du singleton
        /// </summary>
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            _instance = this;
        }
        /// <summary>
        /// Commence a jouer la musique
        /// </summary>
        private void Start()
        {
            Play();
        }
        /// <summary>
        /// Actualise le temps de la musique et passe a la suivante si elle est terminee
        /// </summary>
        private void Update()
        {
            if (!_isPlaying) return;

            // On incremente le temps de la musique
            _currentMusicTime += Time.deltaTime;

            // Si la musique est terminee, on passe a la suivante
            if (_currentMusicTime >= _audioSource.clip.length) NextMusic();
        }
        /// <summary>
        /// Abonne aux evenements de debut et de fin de jeu
        /// </summary>
        private void OnEnable()
        {
            GameManager.OnGameStart += OnGameStart;
            GameManager.OnGameEnd += OnGameEnd;
        }
        /// <summary>
        /// Abonne aux evenements de debut et de fin de jeu
        /// </summary>
        private void OnDisable()
        {
            GameManager.OnGameStart -= OnGameStart;
            GameManager.OnGameEnd -= OnGameEnd;
        }

        /// <summary>
        /// Met a jour le volume de la musique quand la partie commence
        /// </summary>
        /// <param name="options"></param>
        private void OnGameStart(GameOption options)
        {
            SetVolume(_inGameVolume);
        }
        /// <summary>
        /// Met a jour le volume de la musique quand la partie se termine
        /// </summary>
        private void OnGameEnd()
        {
            SetVolume(_menuVolume);
        }
        /// <summary>
        /// Fait un tween pour changer le volume de la musique
        /// </summary>
        /// <param name="volume"></param>
        private void SetVolume(float volume)
        {
            // Si un tween est en cours, on le stop
            if (_volumeTween != null && !_volumeTween.IsComplete()) _volumeTween.Kill();

            // On cree un nouveau tween pour changer le volume
            _volumeTween = DOTween.To(() =>
            {
                _audioMixer.GetFloat(_volumeParameterName, out var x);
                return x;
            }, x => _audioMixer.SetFloat(_volumeParameterName, x), volume, _volumeTransitionDuration);
            _volumeTween.Play();
        }
    }
}