using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    public Image ls;
    public Text lt;

    void OnMouseDown()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.01f);
        ls.color = new Color(ls.color.r, ls.color.g, ls.color.b, ls.color.a + 0.01f);
        lt.color = new Color(lt.color.r, lt.color.g, lt.color.b, lt.color.a + 0.01f);
        if (ls.color.a >= 1)
        {
            SceneManager.LoadScene("Lab");
        } else
        {
            StartCoroutine(Loading());
        }
    }
}
