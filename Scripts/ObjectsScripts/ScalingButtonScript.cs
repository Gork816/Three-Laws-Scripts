using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingButtonScript : MonoBehaviour
{
    public GameObject window;
    public bool reverse = false;
    bool scaling = false;
    public float speed;
    public float final_scale;
    public float timer;
    public bool se;
    public ScalingButtonScript sbc;
    WindowVars wv;

    void Start()
    {
        wv = window.GetComponent<WindowVars>();
        speed = wv.speed;
        final_scale = wv.scale;
        if (reverse == true)
        {
            speed *= -1;
            final_scale = 0;
        }
    }

    void FixedUpdate()
    {
        if (scaling == true)
        {
            window.transform.localScale = new Vector3(window.transform.localScale.x + speed, window.transform.localScale.y + speed, 1);
        }
    }

    void OnMouseDown()
    {
        if ((scaling == false) && (se == true))
        {
            scaling = true;
            StartCoroutine(ScaleTimer());
            se = false;
        }
    }

    IEnumerator ScaleTimer()
    {
        yield return new WaitForSeconds(timer);
        scaling = false;
        window.transform.localScale = new Vector3(final_scale, final_scale, 1);
        sbc.se = true;
    }
}
