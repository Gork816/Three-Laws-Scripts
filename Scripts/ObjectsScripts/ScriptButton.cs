using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptButton : MonoBehaviour
{
    public int script_id;
    public LevelController lc;

    void OnMouseDown()
    {
        lc.Script(script_id);
        gameObject.SetActive(false);
    }
}
