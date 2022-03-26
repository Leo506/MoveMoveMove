using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFG : MonoBehaviour, IUsable
{
    [SerializeField] Canvas useCanvas;

    public static event System.Action BFGWasWorked;

    public void Use()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
            enemy.GetDamage(100000);
        
        BFGWasWorked?.Invoke();
        useCanvas.enabled = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerLogic>() != null)
            useCanvas.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerLogic>() != null)
            useCanvas.enabled = false;
    }
}
