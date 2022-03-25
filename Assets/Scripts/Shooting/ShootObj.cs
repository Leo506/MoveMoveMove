using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShootObj : MonoBehaviour
{
    [SerializeField] float shootSpeed;
    [SerializeField] ParticleSystem destroyEffect;

    Vector3 movementDir = Vector3.zero;
    Rigidbody rb;

    private List<string> ignoreObjTags = new List<string>() { "Player" };

    public void SetIgnoreList(List<string> ignoreList)
    {
        ignoreObjTags = ignoreList;
    }

    public void StartMove(Vector3 dir)
    {
        rb = GetComponent<Rigidbody>();
        movementDir = dir.normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDir * shootSpeed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreObjTags.Contains(collision.collider.tag))
            return;

        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
