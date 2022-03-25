using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Image playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        PlayerLogic.PlayerHPChangedEvent += ShowPlayerHP;
    }

    private void OnDestroy()
    {
        PlayerLogic.PlayerHPChangedEvent -= ShowPlayerHP;
    }

    public void ShowPlayerHP(float current, float max)
    {
        float ratio = current / max;
        playerHealthBar.fillAmount = ratio;
    }
}
