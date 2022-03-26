using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlFiveController : GameController
{
    [SerializeField] DialogController dialog;
    [SerializeField] StartTextAnim textAnim;
    [SerializeField] DeathController death;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Prepare());
        PlayerLogic.PlayerDiedEvent += Failed;
        LvlTarget.TargetWasAchieveEvent += Victory;
    }

    private void OnDestroy()
    {
        PlayerLogic.PlayerDiedEvent -= Failed;
        LvlTarget.TargetWasAchieveEvent -= Victory;
    }

    IEnumerator Prepare()
    {
        yield return textAnim.AnimateTexts();

        dialog.StartDialog(XmlParser.GetTextFromXml(5, 1));

        death.enabled = true;
    }
}
