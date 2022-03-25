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

    Animator animator;

    bool canShoot = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        target = PlayerData.Instance.gameObject.transform;
        
        shootComponent = GetComponent<ShootComponent>();
        shootComponent.SetIgnoreList(new List<string>() { "Enemy" });

        enemyCollider = GetComponent<CapsuleCollider>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        transform.LookAt(target);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetTrigger("Idle");

            if (canShoot)
            {
                shootComponent.Shoot(agent.transform.position + enemyCollider.center, target.position);
                canShoot = false;
                Invoke("Reload", delayTime);
            }
        }
        else
            animator.SetTrigger("Run");
    }

    private void Reload()
    {
        canShoot = true;
    }

}
