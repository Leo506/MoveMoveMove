using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] ShootObj shootPrefab;

    Camera mainCamera;

    List<string> ignoreList;

    private void Start()
    {
        ignoreList = new List<string>();
        mainCamera = Camera.main;
    }

    public void Shoot(Vector3 from)
    {
        Vector3 direction;
        if (GetDirectionFromInput(from, out direction))
        {
            CreateShoot(from, direction);
        }
    }

    public void Shoot(Vector3 from, Vector3 target)
    {
        var dir = target - from;
        dir = new Vector3(dir.x, 0, dir.z);
        CreateShoot(from, dir);
    }

    private bool GetDirectionFromInput(Vector3 from, out Vector3 direction)
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            direction = hit.point - from;
            direction = new Vector3(direction.x, 0, direction.z);
            
            return true;
        }

        direction = Vector3.zero;

        return false;
    }

    private void CreateShoot(Vector3 from, Vector3 dir)
    {
        var shoot = Instantiate(shootPrefab);
        shoot.gameObject.transform.position = from;
        if (ignoreList.Count != 0)
            shoot.SetIgnoreList(ignoreList);
        shoot.StartMove(dir);
    }

    public void SetIgnoreList(List<string> ignoreList)
    {
        this.ignoreList = ignoreList;
    }
}
