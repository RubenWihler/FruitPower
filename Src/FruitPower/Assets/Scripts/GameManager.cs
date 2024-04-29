/*
 TPI - 2024
 FruitPower - Game Manager
 Wihler Ruben
 */

using System;
using System.Collections;
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
    private Coroutine _gameCycleCoroutine;

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
        ResetPoints();
        StartGameCycleCoroutine();
        _isGameRunning = true;
        OnGameStart?.Invoke(gameOption);
    }

    /// <summary>
    /// Termine le jeu.
    /// </summary>
    [ContextMenu("End Game")]
    public void EndGame()
    {
        StopGameCycleCoroutine();
        _isGameRunning = false;
        OnGameEnd?.Invoke();
    }

    #region Score Management

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

    #endregion

    #region Game Cycle

    private void StartGameCycleCoroutine()
    {
        StopGameCycleCoroutine();
        _gameCycleCoroutine = StartCoroutine(GameCycle());
    }
    private void StopGameCycleCoroutine()
    {
        if (_gameCycleCoroutine == null) return;

        StopCoroutine(_gameCycleCoroutine);
        _gameCycleCoroutine = null;
    }
    private IEnumerator GameCycle()
    {
        yield return new WaitForSeconds(gameOption.gameTime * 0.7f);

        //changer la musique pour indiquer le dernier tiers du jeu
        //#todo
        yield return new WaitForSeconds(gameOption.gameTime * 0.3f);

        EndGame();
    }

    #endregion
}