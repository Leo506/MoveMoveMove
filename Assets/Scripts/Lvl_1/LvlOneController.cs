using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlOneController : GameController
{
    [SerializeField] DialogController dialog;
    [SerializeField] GameObject secondPartOfLevel;
    [SerializeField] int countOfEnemies;
    int phraseId = 1;


    // Start is called before the first frame update
    void Start()
    {
        dialog.StartDialog(XmlParser.GetTextFromXml(1, phraseId));
        Doll.DollWasDestroyed += SecondPart;
        Enemy.EnemyDiedEvent += CheckEnemiesCount;
        PlayerLogic.PlayerDiedEvent += Failed;
    }

    private void OnDestroy()
    {
        Doll.DollWasDestroyed -= SecondPart;
        Enemy.EnemyDiedEvent -= CheckEnemiesCount;
        PlayerLogic.PlayerDiedEvent -= Failed;
    }

    private void SecondPart()
    {
        secondPartOfLevel.SetActive(true);
        phraseId++;
        dialog.StartDialog(XmlParser.GetTextFromXml(1, phraseId));
    }

    private void CheckEnemiesCount()
    {
        countOfEnemies--;
        if (countOfEnemies <= 0)
        {
            phraseId++;
            dialog.StartDialog(XmlParser.GetTextFromXml(1, phraseId));
        }
        Invoke("Victory", 3);
    }
}
