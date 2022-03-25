using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] ShootObj shootPrefab;

    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void Shoot(Vector3 from)
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var dir = hit.point - from;
            dir = new Vector3(dir.x, 0, dir.z);

            var shoot = Instantiate(shootPrefab);
            shoot.gameObject.transform.position = from;
            shoot.StartMove(dir);
        }
    }
}
