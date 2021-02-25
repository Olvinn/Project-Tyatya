using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public SceneController sc;
    public Widget playUI, pauseMenu, winWindown;

    void Start()
    {
        sc = GameObject.Find("SceneController").GetComponent<SceneController>();
        sc.playerWin.AddListener(() => OnWin());
    }

    void OnWin()
    {
        pauseMenu.Hide();
        playUI.Hide();
        winWindown.Show();
    }
}
