using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlLoader : MonoBehaviour
{
    public void LoadLvl(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }

}
