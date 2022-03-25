using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas victoryCanvas;
    [SerializeField] Canvas failedCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameController.PauseEvent += Pause;
        GameController.UnpauseEvent += Unpause;
        GameController.VictoryEvent += Victory;
        GameController.FailedEvent += Failed;
    }

    private void OnDestroy()
    {
        GameController.PauseEvent -= Pause;
        GameController.UnpauseEvent -= Unpause;
        GameController.VictoryEvent -= Victory;
        GameController.FailedEvent -= Failed;
    }

    private void Pause()
    {
        pauseCanvas.enabled = true;
    }

    private void Unpause()
    {
        pauseCanvas.enabled = false;
    }

    private void Victory()
    {
        victoryCanvas.enabled = true;
    }

    private void Failed()
    {
        failedCanvas.enabled = true;
    }

}
