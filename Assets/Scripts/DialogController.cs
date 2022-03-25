using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogController : MonoBehaviour
{
    [SerializeField] Canvas dialogCanvas;
    [SerializeField] Text dialogText;

    public void StartDialog(string text)
    {
        dialogCanvas.enabled = true;
        StartCoroutine(ShowText(text));
    }

    IEnumerator ShowText(string text)
    {
        string tmp = "";
        foreach (var c in text)
        {
            tmp += c;
            dialogText.text = tmp;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(3);
        dialogCanvas.enabled = false;
    }
}
