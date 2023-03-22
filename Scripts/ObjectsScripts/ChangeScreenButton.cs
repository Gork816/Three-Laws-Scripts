using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreenButton : MonoBehaviour
{
    public ChangeScreenButton csb; //парная кнопка
    public GameObject screen;
    public int monid; //id монитора, на котором находится экран
    public CameraScript cs;
    public bool ce;

    void OnMouseDown()
    {
        if (enabled == true)
        {
            cs.screens[monid] = screen;
            cs.ChangeScreen(monid);
            csb.ce = true;
            ce = false;
        }
    }
}
