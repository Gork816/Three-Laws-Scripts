using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public MonitorController mc;
    public WindowController wc;
    public GameObjectController goc;
    public DialogueController dc;
    public ScriptButton dnb;
    public CameraScript cs;
    public Image black_curtain;
    public int level;

    void Start()
    {
        mc = GetComponent<MonitorController>();
        wc = GetComponent<WindowController>();
        goc = GetComponent<GameObjectController>();
        dc = GetComponent<DialogueController>();
        cs = GetComponent<CameraScript>();
        Script(0);
    }

    public void Script(int id)
    {
        switch (level)
        {
            case 1:
                switch (id)
                {
                    case 0:
                        StartCoroutine(Timer(2f, 10));
                        break;
                    case 1:
                        wc.WindowFunction(0, 1);
                        break;
                    case 2:
                        wc.WindowFunction(1, 1);
                        break;
                    case 3:
                        wc.WindowFunction(2, 1);
                        break;
                    case 4:
                        wc.WindowFunction(3, 1);
                        break;
                    case 5:
                        wc.WindowFunction(4, 1);
                        break;
                    case 6:
                        mc.MonitorFunction(1, 1);
                        break;
                    case 7:
                        goc.Disabling(0);
                        goc.Enabling(1);
                        break;
                    case 8:
                        goc.go[2].GetComponent<LaserBarrierScript>().OpenBarrier();
                        cs.HintOff(2);
                        StartCoroutine(dc.StartDialogue(7));
                        dnb.script_id = 17;
                        break;
                    case 9:
                        dc.DialogueOff();
                        cs.HintOn(2);
                        break;
                    case 10:
                        StartCoroutine(dc.StartDialogue(0));
                        dnb.script_id = 11;
                        break;
                    case 11:
                        StartCoroutine(dc.DialogueFunction(1));
                        dnb.script_id = 12;
                        break;
                    case 12:
                        StartCoroutine(dc.DialogueFunction(2));
                        dnb.script_id = 13;
                        break;
                    case 13:
                        StartCoroutine(Curtain(28));
                        dc.DialogueOff();
                        break;
                    case 14:
                        StartCoroutine(dc.DialogueFunction(4));
                        dnb.script_id = 15;
                        break;
                    case 15:
                        StartCoroutine(dc.DialogueFunction(5));
                        dnb.script_id = 16;
                        break;
                    case 16:
                        StartCoroutine(dc.DialogueFunction(6));
                        dnb.script_id = 9;
                        break;
                    case 17:
                        dc.DialogueOff();
                        break;
                    case 18:
                        goc.Disabling(4);
                        goc.Enabling(5);
                        break;
                    case 19:
                        StartCoroutine(dc.StartDialogue(8));
                        dnb.script_id = 20;
                        break;
                    case 20:
                        StartCoroutine(dc.DialogueFunction(9));
                        dnb.script_id = 21;
                        break;
                    case 21:
                        StartCoroutine(dc.DialogueFunction(10));
                        dnb.script_id = 22;
                        break;
                    case 22:
                        StartCoroutine(dc.DialogueFunction(11));
                        dnb.script_id = 23;
                        break;
                    case 23:
                        StartCoroutine(dc.DialogueFunction(12));
                        dnb.script_id = 17;
                        break;
                    case 24:
                        StartCoroutine(dc.StartDialogue(13));
                        dnb.script_id = 25;
                        break;
                    case 25:
                        StartCoroutine(dc.DialogueFunction(14));
                        dnb.script_id = 26;
                        break;
                    case 26:
                        dc.DialogueOff();
                        goc.go[3].GetComponent<LaserBarrierScript>().OpenBarrier();
                        break;
                    case 27:
                        StartCoroutine(dc.StartDialogue(3));
                        dnb.script_id = 14;
                        break;
                    case 28:
                        StartCoroutine(Timer(1f, 27));
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    IEnumerator Timer(float seconds, int id)
    {
        yield return new WaitForSeconds(seconds);
        Script(id);
    }

    IEnumerator Curtain(int id_s)
    {
        yield return new WaitForSeconds(0.0025f);
        black_curtain.color = new Color(black_curtain.color.r, black_curtain.color.g, black_curtain.color.b, black_curtain.color.a - 0.01f);
        if (black_curtain.color.a >= 0)
        {
            StartCoroutine(Curtain(id_s));
        } else
        {
            Script(id_s);
        }
    }
}
