using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public string[] dialogues = new string[10];
    public int[] sizes = new int[10];
    public Animator box_anim;
    public GameObject nb;
    public PlayerControl pc;
    public GameObject curtain;
    public Text text_box;
    public float timer = 0.05f;

    public IEnumerator StartDialogue(int id)
    {
        DialogueOn();
        yield return new WaitForSeconds(2f);
        box_anim.SetTrigger("dialogue_on");
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(DialogueFunction(id));
    }
    
    public IEnumerator DialogueFunction(int id)
    {
        timer = 0.05f;
        text_box.fontSize = sizes[id];
        text_box.text = "";
        foreach(char chr in dialogues[id].ToCharArray())
        {
            text_box.text += chr;
            yield return new WaitForSeconds(timer);
        }
        yield return new WaitForSeconds(0.5f);
        nb.SetActive(true);
    }

    public void DialogueOn()
    {
        curtain.SetActive(true);
        pc.in_dialogue = true;
    }

    public void DialogueOff()
    {
        curtain.SetActive(false);
        pc.in_dialogue = false;
        box_anim.SetTrigger("dialogue_off");
        text_box.text = "";
    }
}
