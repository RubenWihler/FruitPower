/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    #endregion
    
    public GameOption gameOption;

    public static event Action<GameOption> OnGameStart;
    public static event Action OnGameEnd;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        OnGameStart?.Invoke(gameOption);
    }

    [ContextMenu("End Game")]
    public void EndGame()
    {
        OnGameEnd?.Invoke();
    }

}
