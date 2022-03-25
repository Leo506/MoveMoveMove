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
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var dir = hit.point - from;
            dir = new Vector3(dir.x, 0, dir.z);

            var shoot = Instantiate(shootPrefab);
            shoot.gameObject.transform.position = from;
            if (ignoreList.Count != 0)
                shoot.SetIgnoreList(ignoreList);
            shoot.StartMove(dir);
        }
    }

    public void Shoot(Vector3 from, Vector3 target)
    {
        var dir = target - from;
        dir = new Vector3(dir.x, 0, dir.z);
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
