using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveLoad
{
    public static void SaveGame()
    {
        GameSave game = new GameSave();

        using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, "gameSave.mmm")))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, game);
        }
    }


    public static void LoadGame()
    {
        if (!File.Exists(Path.Combine(Application.persistentDataPath, "gameSave.mmm")))
            return;

        using (FileStream fs = File.Open(Path.Combine(Application.persistentDataPath, "gameSave.mmm"), FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            GameSave game = bf.Deserialize(fs) as GameSave;
            game.Load();
        }
    }
}
