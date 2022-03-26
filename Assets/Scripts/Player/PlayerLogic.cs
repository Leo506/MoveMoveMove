using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, IGetDamage
{
    public float currentHP { get; private set; }

    public static event System.Action<float, float> PlayerHPChangedEvent;
    public static event System.Action PlayerDiedEvent;

    private IUsable currentUsableObj;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = PlayerData.Instance.maxHP;
    }

    public void GetDamage(float damage)
    {
        currentHP -= damage;
        PlayerHPChangedEvent?.Invoke(currentHP, PlayerData.Instance.maxHP);

        if (currentHP <= 0) 
            Die();
    }

    public void Die()
    {
        PlayerDiedEvent?.Invoke();
        Destroy(this.gameObject);
    }

    public void UseObj()
    {
        if (currentUsableObj != null)
            currentUsableObj.Use();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentUsableObj = other.GetComponent<IUsable>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IUsable>() != null)
            currentUsableObj = null;
    }
}
