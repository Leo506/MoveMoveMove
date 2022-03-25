using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EduPanel : MonoBehaviour
{
    [SerializeField] Image eduPanel;
    [SerializeField] Text[] eduTexts;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3);

        for (int i = 100; i >= 0; i--)
        {
            Color newColor = new Color(1, 1, 1, (float)i / 100);

            eduPanel.color = newColor;

            foreach (var text in eduTexts)
                text.color = newColor;

            yield return new WaitForSeconds(0.01f);
        }
    }
}
