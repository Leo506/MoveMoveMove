using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] ParticleSystem workEffect;
    [SerializeField] float stoppingTime;

    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement movement = other.GetComponent<CharacterMovement>();

        if (movement == null)
            return;

        movement.ForceStop(stoppingTime);
        Instantiate(workEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
