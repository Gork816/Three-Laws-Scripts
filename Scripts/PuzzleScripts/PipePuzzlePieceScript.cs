using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePuzzlePieceScript : MonoBehaviour
{
    public bool on_rotate = false;
    public int target;
    float speed = 90f;
    public int cr = 1;
    public PuzzleController pps;

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        cr = Random.Range(0, 4);
        if (cr == 0)
        {
            pps.count_right_pieces += 1;
        }
        target = -90 * (cr + 1);
        transform.eulerAngles = new Vector3(0, 0, (-90 * cr));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (on_rotate == true)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * speed);
        }
    }

    public void RotClick()
    {
        if ((pps.puzzle_on == true) && (on_rotate == false))
        {
            on_rotate = true;
            if (cr == 0)
            {
                pps.count_right_pieces -= 1;
            }
            StartCoroutine(Rot());
        }
    }

    IEnumerator Rot()
    {
        yield return new WaitForSeconds(1.0f);
        on_rotate = false;
        cr += 1;
        transform.eulerAngles = new Vector3(0, 0, target);
        target -= 90;
        if (target == -450) {
            target = -90;
            cr = 0;
        }
        if (cr == 0)
        {
            pps.count_right_pieces += 1;
            if (pps.count_right_pieces == pps.need_right_pieces) //проверка завершения пазла
            {
                pps.PuzzleSolve();
            }
        }
    }

    void OnMouseDown()
    {
        if (pps.puzzle_on == true)
        {
            RotClick();
        }
    }
}
