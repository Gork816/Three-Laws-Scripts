using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitScript : MonoBehaviour
{
    public Sprite spr1;
    Image sr;
    float timer;

    void Start()
    {
        sr = GetComponent<Image>();
        timer = Random.Range(0.3f, 0.5f);
        StartCoroutine(ChangeTimer());
    }

    void ChangeSpr()
    {
        (sr.sprite, spr1) = (spr1, sr.sprite);
        StartCoroutine(ChangeTimer());
    }

    IEnumerator ChangeTimer()
    {
        yield return new WaitForSeconds(timer);
        ChangeSpr();
    }
}
