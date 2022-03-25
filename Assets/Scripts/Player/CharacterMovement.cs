using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MovementStates
{ 
    RUN,
    IDLE
}

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private MovementStates currentMovementState = MovementStates.IDLE;
    private bool canMove = true;

    public static event System.Action StartRunEvent;
    public static event System.Action StopRunEvent;

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;

        float vSpeed;
        if (PlayerData.Instance.characterController.isGrounded)
            vSpeed = 0;
        else
            vSpeed = -9.8f;

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), vSpeed, Input.GetAxis("Vertical"));
        if (movement != Vector3.zero)
        {
            if (currentMovementState != MovementStates.RUN)
            {
                currentMovementState = MovementStates.RUN;
                StartRunEvent?.Invoke();
            }

            PlayerData.Instance.characterController.Move(movement * Time.deltaTime * PlayerData.Instance.CharacterSpeed);
            transform.rotation = Quaternion.LookRotation(new Vector3(movement.x, 0,  movement.z));
        }

        else
        {
            if (currentMovementState == MovementStates.RUN)
            {
                currentMovementState = MovementStates.IDLE;
                StopRunEvent?.Invoke();
            }
        }
    }

    public void ForceStop(float duration)
    {
        canMove = false;
        currentMovementState = MovementStates.IDLE;
        StopRunEvent?.Invoke();
        Invoke("RestoreMoveAbility", duration);
    }

    private void RestoreMoveAbility()
    {
        canMove = true;
    }
}
