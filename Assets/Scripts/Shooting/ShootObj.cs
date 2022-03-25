using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShootObj : MonoBehaviour
{
    [SerializeField] float shootSpeed;
    [SerializeField] float lifeTime;
    [SerializeField] ParticleSystem destroyEffect;

    private Vector3 movementDir = Vector3.zero;
    
    private Rigidbody rb;

    private List<string> ignoreObjTags = new List<string>() { "Player" };

    private float bornTime;

    public void SetIgnoreList(List<string> ignoreList)
    {
        ignoreObjTags = ignoreList;
    }

    public void StartMove(Vector3 dir)
    {
        rb = GetComponent<Rigidbody>();
        movementDir = dir.normalized;
        bornTime = Time.time;
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDir * shootSpeed * Time.fixedDeltaTime;

        if (Time.time - bornTime >= lifeTime)
            DestroyShootObj();
    }

    private void DestroyShootObj()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreObjTags.Contains(collision.collider.tag))
            return;

        DestroyShootObj();
    }
}
