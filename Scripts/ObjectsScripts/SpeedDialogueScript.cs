using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDialogueScript : MonoBehaviour
{
    public DialogueController dc;

    void OnMouseDown()
    {
        dc.timer = 0.02f;
    }
}
