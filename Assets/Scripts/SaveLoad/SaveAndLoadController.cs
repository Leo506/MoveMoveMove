using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadController : MonoBehaviour
{
    private static SaveAndLoadController instance;

    private void Awake()
    {
        if (instance != this && instance != null)
            Destroy(this.gameObject);
        
        instance = this;

        SaveLoad.LoadGame();

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnApplicationQuit()
    {
        SaveLoad.SaveGame();
    }
}
