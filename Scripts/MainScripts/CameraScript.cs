using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject[] screens = new GameObject[2];
    int monitor_id = 0;
    GameObject current_screen;
    public GameObject player;
    public Animator[] hints = new Animator[2];
    PlayerControl ps;
    void Start()
    {
        current_screen = screens[monitor_id];
        ps = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (ps.in_dialogue == false))
        {
            monitor_id = ps.cur_mon_id;
            if (monitor_id != 0)
            {
                HintOff(0);
                HintOn(1);
            }
            ChangeScreen(monitor_id);
        }

        if ((Input.GetKeyDown(KeyCode.K)) && (ps.in_dialogue == false))
        {
            monitor_id = 0;
            if (ps.cur_mon_id != 0)
            {
                HintOff(1);
                HintOn(0);
            }
            ChangeScreen(monitor_id);
        }
        transform.position = new Vector3(current_screen.transform.position.x, current_screen.transform.position.y, -10);
    }

    public void ChangeScreen(int id)
    {
        current_screen = screens[id];
    }

    public void HintOn(int hint_id)
    {
        hints[hint_id].SetTrigger("hint_on");
    }

    public void HintOff(int hint_id)
    {
        hints[hint_id].SetTrigger("hint_off");
    }
}
