using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBarrierScript : MonoBehaviour
{
    public bool is_open = false;
    public Sprite open_sr;
    public Sprite close_sr;
    Collider2D col;
    SpriteRenderer sr;

    void Start()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        if (is_open == true)
        {
            OpenBarrier();
        }
    }

    public void OpenBarrier()
    {
        is_open = true;
        col.enabled = false;
        sr.sprite = open_sr;
    }

    public void CloseBarrier()
    {
        is_open = false;
        col.enabled = true;
        sr.sprite = close_sr;
    }
}
