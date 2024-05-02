/*
 TPI - 2024
 FruitPower - UI
 Wihler Ruben
 */

using UnityEngine.UI;
using GameManagement;

namespace UI
{
    public class PlayButton : Button
    {
        protected override void Start()
        {
            base.Start();
            onClick.AddListener(() => GameManager.StartGame());
        }
    }
}