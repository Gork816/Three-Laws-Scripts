using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public GameObject[] windows = new GameObject[20];
    public GameObject[] buttons = new GameObject[20];
    WindowVars wv;
    ScalingButtonScript scbc;

    public void WindowFunction(int w_id, int op_id)
    {
        switch (op_id)
        {
            case 1:   //������ ����, ����������� ��� ������� ������
                scbc = buttons[w_id].GetComponent<ScalingButtonScript>(); //������ ������, ���� ������� ��������
                wv = windows[w_id].GetComponent<WindowVars>(); //����, �� ������� ��������
                scbc.window = windows[w_id];
                scbc.sbc = wv.exit_button.GetComponent<ScalingButtonScript>();
                scbc.final_scale = wv.scale;
                scbc.speed = wv.speed;
                break;
        }
    }
}
