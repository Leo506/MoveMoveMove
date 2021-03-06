using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public static event Action PauseEvent;
    public static event Action UnpauseEvent;

    public static event Action VictoryEvent;
    public static event Action FailedEvent;

    public void Pause()
    {
        PauseEvent?.Invoke();
    }

    public void Unpause()
    {
        UnpauseEvent?.Invoke();
    }

    public void Victory()
    {
        int lvlNumber = int.Parse(SceneManager.GetActiveScene().name.Substring(4));
        Progress.CompleteLvl(lvlNumber);
        VictoryEvent?.Invoke();
        var player = FindObjectOfType<PlayerLogic>();
        if (player != null)
            Destroy(player.gameObject);
    }

    public void Failed()
    {
        FailedEvent?.Invoke();
    }

    public void Repeat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
