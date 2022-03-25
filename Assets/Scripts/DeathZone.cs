using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        PlayerLogic player = collider.GetComponent<PlayerLogic>();
        if (player != null)
            player.Die();
    }
}
