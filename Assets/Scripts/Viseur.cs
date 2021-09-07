using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Viseur : MonoBehaviour
{
    private Text[] viseurText;
    private int len;

    // Start is called before the first frame update
    void Start()
    {
        len = gameObject.transform.childCount;
        viseurText = new Text[len];

        for (var i = 0; i < len; i++)
        {
            GameObject parent = gameObject.transform.GetChild(i).gameObject;
            viseurText[i] = parent.transform.GetChild(0).gameObject.GetComponent<Text>();
        }
    }

    public void ResetTimer()
    {
        for (var i = 0; i < len; i++)
            viseurText[i].text = "+";
    }

    public void DisplayTime(float time)
    {
        for (var i = 0; i < len; i++)
            viseurText[i].text = Mathf.FloorToInt(time % 60).ToString();
    }

    public void HideTimer()
    {
        for (var i = 0; i < len; i++)
            viseurText[i].enabled = false;
    }

    public void RemoveAnimation()
    {
        for (var i = 0; i < len; i++)
        {
            Animator timerAnimator =  viseurText[i].GetComponent<Animator>();
            timerAnimator.runtimeAnimatorController = null;
        }
    }

    public void FadeIn()
    {
        for (var i = 0; i < len; i++)
        {
            viseurText[i].enabled = true;
            Animator timerAnimator =  viseurText[i].GetComponent<Animator>();
            timerAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimationTransition/ViseursFadeIn");
        }
    }
}