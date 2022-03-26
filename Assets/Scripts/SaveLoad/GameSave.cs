using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSave
{
    bool isFirstGame;
    ProgressState[] progress;

    public GameSave()
    {
        isFirstGame = Progress.IsFirstGame;
        progress = Progress.currentStates;
    }

    public void Load()
    {
        Progress.IsFirstGame = isFirstGame;
        Progress.currentStates = progress;
    }
}
