using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GUIAnimation;

public class GameScene : MonoBehaviour
{
    public GameObject pauseWindow;

    public GUIAnimator topBar;
    public GUIAnimator bottomBar;

    void Start()
    {
        GUIAnimSystem.instance.AnimIn(topBar);
        GUIAnimSystem.instance.AnimIn(bottomBar);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseWindow();
        }
    }

    public void TogglePauseWindow()
    {
        pauseWindow.SetActive(!pauseWindow.activeSelf);

        if (pauseWindow.activeSelf)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
