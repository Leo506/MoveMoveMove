using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlThreeController : GameController
{
    [SerializeField] DialogController dialog;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] StartTextAnim textAnimator;
    [SerializeField] DeathController death;

    private void Start()
    {
        StartCoroutine(Prepare());
        PlayerLogic.PlayerDiedEvent += Failed;
        Trap.TrapWasWorked += TalkAboutTrap;
        Enemy.EnemyDiedEvent += CheckEnemyCount;
    }

    private void OnDestroy()
    {
        PlayerLogic.PlayerDiedEvent -= Failed;
        Enemy.EnemyDiedEvent -= CheckEnemyCount;
    }

    IEnumerator Prepare()
    {
        yield return textAnimator.AnimateTexts();

        foreach (var enemy in enemies)
            enemy.gameObject.SetActive(true);

        death.enabled = true;
    }

    private void TalkAboutTrap()
    {
        dialog.StartDialog(XmlParser.GetTextFromXml(3, 1));
        Trap.TrapWasWorked -= TalkAboutTrap;
    }


    private void CheckEnemyCount()
    {
        enemies.RemoveAt(0);
        if (enemies.Count == 0)
            Victory();
    }
}
