using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMovingScript : MonoBehaviour
{
    bool moving = false;
    Vector3 delta;
    Vector3 mouse_pos;
    public GameObject window;

    void OnMouseDown()
    {
        moving = true;
        mouse_pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        delta = new Vector3(window.transform.position.x - mouse_pos.x, window.transform.position.y - mouse_pos.y, 0);
    }

    void OnMouseUp()
    {
        moving = false;
    }

    void Update()
    {
        if (moving == true)
        {
            mouse_pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            window.transform.position = new Vector3(mouse_pos.x + delta.x, mouse_pos.y + delta.y, window.transform.position.z);
        }
    }
}
