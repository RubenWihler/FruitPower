/*
 TPI - 2024
 FruitPower - UI
 Wihler Ruben
 */

using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Tooltip("Distance de l'écran par rapport à la tête du joueur [default: 1.2]")]
    private float _screenDistance = 1.2f;

    [SerializeField, Tooltip("Référence vers le transform de la tête du joueur")]
    private Transform _headTransform;

    [Header("UI Elements")]
    [SerializeField, Tooltip("Référence vers le canvas de l'affichage tête haute(HUD)")]
    private Canvas _hud;

    [SerializeField, Tooltip("Référence vers le canvas de fin de partie")]
    private Canvas _endGameUI;

    private void OnEnable()
    {
        GameManager.OnGameStart += OnGameStart;
        GameManager.OnGameEnd += OnGameEnd;
    }
    private void OnDisable()
    {
        GameManager.OnGameStart -= OnGameStart;
        GameManager.OnGameEnd -= OnGameEnd;
    }

    private void Update()
    {
        if (_endGameUI.isActiveAndEnabled) CenterEndGameUI();
        if (_hud.isActiveAndEnabled) CenterHud();
    }

    private void OnGameStart(GameOption options)
    {
        SetActiveEndGameUI(false);
        SetActiveHUD(true);
    }
    private void OnGameEnd()
    {
        SetActiveEndGameUI(true);
        SetActiveHUD(false);
    }
    
    private void CenterEndGameUI()
    {
        _endGameUI.transform.position = _headTransform.position + new Vector3(_headTransform.forward.x, 0, _headTransform.forward.z).normalized * _screenDistance;
        _endGameUI.transform.LookAt(new Vector3(_headTransform.position.x, _endGameUI.transform.position.y, _headTransform.position.z));
        _endGameUI.transform.forward *= -1;
    }
    private void CenterHud()
    {
        _hud.transform.position = _headTransform.position + _headTransform.forward.normalized * _screenDistance;
        _hud.transform.LookAt(_headTransform.position);
        _hud.transform.forward *= -1;
    }

    private void SetActiveHUD(bool value)
    {
        _hud.enabled = value;
    }
    private void SetActiveEndGameUI(bool value)
    {
        _endGameUI.enabled = value;

        //pause le jeu si le menu de fin de partie est actif
        Time.timeScale = value ? 0 : 1;
    }
}
