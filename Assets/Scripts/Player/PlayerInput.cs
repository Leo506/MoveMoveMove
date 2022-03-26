using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float delayTime;
    bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot)
            {
                PlayerData.Instance.shootComponent.Shoot(PlayerData.Instance.CorrectPlayerPosition);
                canShoot = false;
                Invoke("Reload", delayTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
            PlayerData.Instance.playerLogic.UseObj();
    }

    private void Reload()
    {
        canShoot = true;
    }
}
