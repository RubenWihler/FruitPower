using UnityEngine;
using UnityEngine.UI;

public class QuitButton : Button
{
    protected override void Start()
    {
        base.Start();
        Debug.Log("QuitButton Start");
        onClick.AddListener(() => Application.Quit());
    }
}
