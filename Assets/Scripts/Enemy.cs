using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float delayTime;

    NavMeshAgent agent;
    Transform target;
    ShootComponent shootComponent;
    CapsuleCollider enemyCollider;

    bool canShoot = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        target = PlayerData.Instance.gameObject.transform;
        
        shootComponent = GetComponent<ShootComponent>();
        shootComponent.SetIgnoreList(new List<string>() { "Enemy" });

        enemyCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        agent.SetDestination(target.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (canShoot)
            {
                shootComponent.Shoot(agent.transform.position + enemyCollider.center, target.position);
                canShoot = false;
                Invoke("Reload", delayTime);
            }
        }
    }

    private void Reload()
    {
        canShoot = true;
    }

}
