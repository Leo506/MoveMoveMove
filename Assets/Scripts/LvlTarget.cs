using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LvlTarget : MonoBehaviour
{
    public static event Action TargetWasAchieveEvent;

    private void OnTriggerEnter(Collider other)
    {
        PlayerLogic player = other.GetComponent<PlayerLogic>();
        if (player != null)
            TargetWasAchieveEvent?.Invoke();
    }
}
