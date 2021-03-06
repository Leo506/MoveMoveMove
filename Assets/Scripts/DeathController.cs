using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] int secBeforeDie;


    // Start is called before the first frame update
    void Start()
    {
        CharacterMovement.StopRunEvent += StartCountDown;
        CharacterMovement.StartRunEvent += StopCountDown;
    }

    private void OnDestroy()
    {
        CharacterMovement.StopRunEvent -= StartCountDown;
        CharacterMovement.StartRunEvent -= StopCountDown;
    }

    private void StartCountDown()
    {
        StartCoroutine(CountDown(secBeforeDie));
    }

    public void StopCountDown()
    {
        StopAllCoroutines();
    }

    IEnumerator CountDown(int sec)
    {
        yield return new WaitForSeconds(sec);

        var player = FindObjectOfType<PlayerLogic>();
        if (player != null)
            player.Die();
    }
}
