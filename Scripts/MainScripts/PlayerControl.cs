using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    int ox;
    int oy;
    Rigidbody2D rb;
    public int cur_mon_id = 0;
    MonitorScript mon_scr;
    public CameraScript cam;
    bool in_screen = false;
    public bool in_dialogue = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((in_screen == false) && (in_dialogue == false))
        {
            if (Input.GetKey(KeyCode.W))
                oy = 1;
            if (Input.GetKey(KeyCode.A))
                ox = -1;
            if (Input.GetKey(KeyCode.S))
                oy = -1; ;
            if (Input.GetKey(KeyCode.D))
                ox = 1;
        }

        rb.velocity = new Vector2(ox, oy) * speed;
        ox = 0;
        oy = 0;

        if ((Input.GetKeyDown(KeyCode.E)) && (cur_mon_id > 0))
        {
            in_screen = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            in_screen = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Monitor")
        {
            mon_scr = col.gameObject.GetComponent<MonitorScript>();
            if ((mon_scr.screen_on == true) && (mon_scr.signal_on == true))
            {
                cur_mon_id = mon_scr.id;
                cam.HintOn(0);
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Monitor")
        {
            cur_mon_id = 0;
            cam.HintOff(0);
        }
    }
}
