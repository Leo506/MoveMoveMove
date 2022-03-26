using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlFourController : GameController
{
    [SerializeField] DialogController dialog;
    [SerializeField] StartTextAnim textAnimator;
    [SerializeField] DeathController death;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Prepare());
        PlayerLogic.PlayerDiedEvent += Failed;
        BFG.BFGWasWorked += TalkAboutBFG;
    }

    private void OnDestroy()
    {
        PlayerLogic.PlayerDiedEvent -= Failed;
        BFG.BFGWasWorked -= TalkAboutBFG;
    }

    private void TalkAboutBFG()
    {
        death.StopCountDown();
        Destroy(death.gameObject);
        dialog.StartDialog(XmlParser.GetTextFromXml(4, 1));
        Invoke("Victory", 3);
    }

    IEnumerator Prepare()
    {
        yield return textAnimator.AnimateTexts();
        death.enabled = true;
    }
}
