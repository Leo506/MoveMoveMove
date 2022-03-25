using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();

        CharacterMovement.StartRunEvent += StartRunAnim;
        CharacterMovement.StopRunEvent += StopRunAnim;
    }

    private void OnDestroy()
    {
        CharacterMovement.StartRunEvent -= StartRunAnim;
        CharacterMovement.StopRunEvent -= StopRunAnim;
    }

    private void StartRunAnim()
    {
        playerAnimator.SetTrigger("Run");
    }

    private void StopRunAnim()
    {
        playerAnimator.SetTrigger("Idle");
    }
}
