using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTextAnim : MonoBehaviour
{
    [SerializeField] Text[] startTexts;

    public IEnumerator AnimateTexts()
    {
        foreach (var text in startTexts)
        {
            text.gameObject.SetActive(true);
            for (int i = 0; i < 100; i++)
            {
                text.transform.localScale = new Vector3((float)i / 100, (float)i / 100, 1);
                yield return new WaitForSeconds(0.005f);
            }
            text.gameObject.SetActive(false);
        }
    }
}
