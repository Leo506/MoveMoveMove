using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour, IGetDamage
{
    [SerializeField] ParticleSystem destroyEffect;
    float hp = 100;

    public static event System.Action DollWasDestroyed;
    public void GetDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            DollWasDestroyed?.Invoke();
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
