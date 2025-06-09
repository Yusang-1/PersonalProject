using UnityEngine;
using TMPro;
using System.Collections;

public class FirstUI : MonoBehaviour
{
    TextMeshProUGUI text;

    public void Start()
    {
        text = UIManager.Instance.UIDictionary[UIState.firstUI].GetComponentInChildren<TextMeshProUGUI>();
        IEnumerator textFlicker = TextFlicker();
        StartCoroutine(textFlicker);
    }

    public void Update()
    {
        if(PressAnyKey() == true)
        {
            UIManager.Instance.StateMachine.SetState(UIState.mainUI);
        }
    }

    bool PressAnyKey()
    {
        if (Input.anyKeyDown)
        {
            return true;
        }
        return false;
    }

    IEnumerator TextFlicker()
    {
        float minAlpha = 0.55f;

        while (true)
        {
            for (float a = 1; a > minAlpha; a -= 0.002f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, a);
                yield return null;
            }

            yield return new WaitForSeconds(0.08f);

            for (float a = minAlpha; a < 1; a += 0.002f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, a);
                yield return null;
            }

            yield return new WaitForSeconds(0.08f);
        }
    }
}
