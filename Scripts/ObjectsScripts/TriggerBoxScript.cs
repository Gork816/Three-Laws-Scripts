using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxScript : MonoBehaviour
{
    public int script;
    public LevelController lc;

    void OnTriggerEnter2D(Collider2D col)
    {
        lc.Script(script);
        Destroy(gameObject);
    }
}
