using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonitorScript : MonoBehaviour
{
    public int id;
    public bool screen_on;
    public bool signal_on;
    public int monitor_type;
    Animator an;

    void Start()
    {
        an = GetComponent<Animator>();
        if (screen_on == true)
        {
            an.SetBool("power_on", true);
        }
        if (signal_on == true)
        {
            an.SetBool("signal_on", true);
        }
        switch(monitor_type)
        {
            case 1:
                GlowLine();
                break;
            default:
                break;
        }
    }

    public void On_Screen()
    {
        screen_on = true;
        an.SetBool("power_on", true);
    }

    public void On_Signal()
    {
        signal_on = true;
        an.SetBool("signal_on", true);
    }

    void GlowLine()
    {
        an.SetTrigger("glowing_line");
        StartCoroutine(GlowTimer());
    }

    IEnumerator GlowTimer()
    {
        yield return new WaitForSeconds(5f);
        GlowLine();
    }
}
