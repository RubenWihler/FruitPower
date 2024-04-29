/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using System;
using UnityEngine;

/// <summary>
/// Classe responsable de la gestion du jeu. C'est ici que l'on démarre et termine le jeu.
/// Cette classe est un singleton pour permettre un accès facile à partir de n'importe où.
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    #endregion

    [Header("Game Options")]
    [Tooltip("Les options du jeu.")]
    public GameOption gameOption;

    /// <summary>
    /// Evénement appelé lorsque le jeu démarre. Les abonnés à cet événement recevront les options du jeu.
    /// </summary>
    public static event Action<GameOption> OnGameStart;
    /// <summary>
    /// Evénement appelé lorsque le jeu se termine.
    /// </summary>
    public static event Action OnGameEnd;

    public static event Action<int> OnScoreChange;

    private ulong _score;
    private bool _isGameRunning;

    public static ulong Score => Instance._score;
    public static bool IsGameRunning => Instance._isGameRunning;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Commence le jeu avec les options actuelles.
    /// </summary>
    [ContextMenu("Start Game")]
    public void StartGame()
    {
        _isGameRunning = true;
        OnGameStart?.Invoke(gameOption);
    }

    /// <summary>
    /// Termine le jeu.
    /// </summary>
    [ContextMenu("End Game")]
    public void EndGame()
    {
        _isGameRunning = false;
        OnGameEnd?.Invoke();
    }


    public void AddPoints(ulong point)
    {
        // Vérifie si le score est trop élevé pour être ajouté.
        if (_score + point > ulong.MaxValue)
        {
            Debug.LogWarning("[!] Le score est trop élevé pour être ajouté.");
            _score = ulong.MaxValue;
        }
        else
        {
            _score += point;
        }

        OnScoreChange?.Invoke((int)_score);
    }
    public void ResetPoints()
    {
        this._score = 0;
        OnScoreChange?.Invoke((int)_score);
    }


}
