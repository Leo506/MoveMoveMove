using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trap : MonoBehaviour
{
    [SerializeField] ParticleSystem workEffect;
    [SerializeField] float stoppingTime;

    public static event Action TrapWasWorked;

    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement movement = other.GetComponent<CharacterMovement>();

        if (movement == null)
            return;

        TrapWasWorked?.Invoke();
        movement.ForceStop(stoppingTime);
        Instantiate(workEffect, other.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
