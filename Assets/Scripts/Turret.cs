using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float delayTime;
    ShootComponent shootComponent;

    private void Awake()
    {
        shootComponent = GetComponent<ShootComponent>();
        shootComponent.SetIgnoreList(new List<string>() { });
    }

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            shootComponent.ShootByDirection(transform.position, transform.forward);

            yield return new WaitForSeconds(delayTime);
        }
    }
}
