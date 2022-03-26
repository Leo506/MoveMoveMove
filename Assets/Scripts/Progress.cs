using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ProgressState
{
    COMPLETE,
    NOT_COMPLETE,
    NO_ACCESS
}

public class Progress : MonoBehaviour
{
    private static ProgressState[] currentStates = new ProgressState[]
    {
        ProgressState.NOT_COMPLETE,
        ProgressState.NO_ACCESS,
        ProgressState.NO_ACCESS,
        ProgressState.NO_ACCESS,
        ProgressState.NO_ACCESS
    };

    static bool isFirstGame = true;
    public static bool IsFirstGame
    {
        get => isFirstGame;
    }

    [SerializeField] Button[] lvlButtons;

    private void Start()
    {
        SetEnableButtons();
    }

    private void SetEnableButtons()
    {
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (currentStates[i] != ProgressState.NO_ACCESS)
                lvlButtons[i].enabled = true;
        }
    }

    public static void CompleteLvl(int lvl)
    {
        if (IsFirstGame)
            isFirstGame = false;

        currentStates[lvl - 1] = ProgressState.COMPLETE;
        if (lvl < currentStates.Length)
            currentStates[lvl] = ProgressState.NOT_COMPLETE;
    }

    public static void SetProgressState(ProgressState[] progress)
    {
        currentStates = progress;
    }
}
