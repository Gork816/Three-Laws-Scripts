using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorController : MonoBehaviour
{
    public GameObject[] monitors = new GameObject[20];
    public MonitorScript ms;

    public void MonitorFunction(int m_id, int op_id)
    {
        ms = monitors[m_id].GetComponent<MonitorScript>();
        switch (op_id)
        {
            case 1:
                ms.On_Screen();
                break;
        }
    }
}
