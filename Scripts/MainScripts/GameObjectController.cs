using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    public GameObject[] go = new GameObject[0];

    public void Enabling(int id)
    {
        go[id].SetActive(true);
    }

    public void Disabling(int id)
    {
        go[id].SetActive(false);
    }
}
