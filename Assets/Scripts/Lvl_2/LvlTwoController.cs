using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlTwoController : GameController
{
    [SerializeField] DialogController dialog;


    // Start is called before the first frame update
    void Start()
    {
        dialog.StartDialog(XmlParser.GetTextFromXml(2, 1));
        PlayerLogic.PlayerDiedEvent += Failed;
        LvlTarget.TargetWasAchieveEvent += Victory;
    }

    private void OnDestroy()
    {
        PlayerLogic.PlayerDiedEvent -= Failed;
        LvlTarget.TargetWasAchieveEvent -= Victory;
    }
}
