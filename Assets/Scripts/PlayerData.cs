using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public CharacterController characterController { get; private set; }
    public ShootComponent shootComponent { get; private set; }
    public Vector3 CorrectPlayerPosition
    {
        get
        {
            return transform.position + characterController.center;
        }
    }

    public float CharacterSpeed;

    public static PlayerData Instance;

    void Awake()
    {
        if (Instance != this && Instance != null)
            Destroy(Instance.gameObject);

        Instance = this;

        characterController = GetComponent<CharacterController>();
        shootComponent = GetComponent<ShootComponent>();
    }

}
