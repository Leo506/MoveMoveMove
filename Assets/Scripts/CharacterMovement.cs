using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movement != Vector3.zero)
        {
            PlayerData.Instance.characterController.Move(movement * Time.deltaTime * PlayerData.Instance.CharacterSpeed);
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
