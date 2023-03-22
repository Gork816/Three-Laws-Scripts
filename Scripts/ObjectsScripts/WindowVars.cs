using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowVars : MonoBehaviour
{
    public GameObject exit_button;
    public int scale;
    public float speed;

    void Awake()
    {
        speed = 0.08f * scale;
    }
}
