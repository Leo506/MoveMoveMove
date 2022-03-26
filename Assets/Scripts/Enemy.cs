using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IGetDamage
{
    [SerializeField] float delayTime;
    [SerializeField] bool isStatic = false;

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

    private void OnPlayerFailed()
    {
        canShoot = false;
    }

    private void Update()
    {
        if (target == null)
            return;

        transform.LookAt(target);

        // Если враг статичен, то он не может двигаться
        if (isStatic)
        {
            if (canShoot)
                Attack();
        }
        else
        {
            agent.SetDestination(target.position);


            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.SetTrigger("Idle");

                if (canShoot)
                    Attack();
            }
            else
                animator.SetTrigger("Run");
        }
    }

    private void Attack()
    {
        shootComponent.Shoot(agent.transform.position + enemyCollider.center, target.position);
        canShoot = false;
        Invoke("Reload", delayTime);
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

 
}
