using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IGetDamage
{
    [SerializeField] float delayTime;

    NavMeshAgent agent;
    Transform target;
    ShootComponent shootComponent;
    CapsuleCollider enemyCollider;

    Animator animator;

    bool canShoot = true;

    private float hp = 100;

    public static event System.Action EnemyDiedEvent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        target = PlayerData.Instance.gameObject.transform;
        
        shootComponent = GetComponent<ShootComponent>();
        shootComponent.SetIgnoreList(new List<string>() { "Enemy" });

        enemyCollider = GetComponent<CapsuleCollider>();

        animator = GetComponent<Animator>();

        GameController.FailedEvent += OnPlayerFailed;
    }

    private void OnDestroy()
    {
        GameController.FailedEvent -= OnPlayerFailed;
    }

    private void Update()
    {
        if (target == null)
            return;

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

    public void GetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            EnemyDiedEvent?.Invoke();
            Destroy(this.gameObject);
        }
    }

    private void OnPlayerFailed()
    {
        canShoot = false;
    }
}
