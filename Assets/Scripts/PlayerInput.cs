using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] ShootObj shootPrefab;

    CharacterController characterController;
    Vector3 correctCharacterCenter;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var dir = hit.point - CalculateCharacterCenter();
                dir = new Vector3(dir.x, 0, dir.z);
                var shoot = Instantiate(shootPrefab);
                shoot.gameObject.transform.position = CalculateCharacterCenter();
                shoot.StartMove(dir);
            }
        }
    }

    Vector3 CalculateCharacterCenter()
    {
        return transform.position + characterController.center;
    }
}
