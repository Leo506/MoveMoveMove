using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] DialogController dialog;

    // Start is called before the first frame update
    void Start()
    {
        if (Progress.IsFirstGame)
            dialog.StartDialog(XmlParser.GetTextFromXml(0, 1));
    }

    public void Quit()
    {
        Application.Quit();
    }

}
