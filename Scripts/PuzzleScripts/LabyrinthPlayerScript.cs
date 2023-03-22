using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthPlayerScript : MonoBehaviour
{
    public GameObject goal;
    public PuzzleController pc;
    bool on_move = false;
    public ChangeScreenButton eb;
    public float speed;
    Vector3 start_pos;
    Vector3 last_pos;
    int ox = 0;
    int oy = 0;
    Rigidbody2D rb;
    public RestartPuzzleScript rps;

    void Start()
    {
        start_pos = transform.localPosition;
        last_pos = transform.localPosition;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((eb.ce == true) && (on_move == false) && (pc.puzzle_on == true)) {
            if (Input.GetKeyDown(KeyCode.W))
            {
                on_move = true;
                oy = 1;
                StartCoroutine(Moving());
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                on_move = true;
                oy = -1;
                StartCoroutine(Moving());
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                on_move = true;
                ox = -1;
                StartCoroutine(Moving());
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                on_move = true;
                ox = 1;
                StartCoroutine(Moving());
            }
        }
        rb.velocity = new Vector3(ox * speed, oy * speed, 0);
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(0.2f);
        StopMove(0);
        if (pc.count_right_pieces >= pc.need_right_pieces)
        {
            transform.position = goal.transform.position;
        }
    }

    void StopMove(int id)
    {
        switch (id)
        {
            case 0:
                last_pos = new Vector3(last_pos.x + 0.64f*ox, last_pos.y + 0.64f*oy, transform.localPosition.z);
                on_move = false;
                break;
            case 1:
                last_pos = start_pos;
                break;
            default:
                break;
        }
        ox = 0;
        oy = 0;
        transform.localPosition = last_pos;
        if (pc.count_right_pieces == pc.need_right_pieces)
        {
            pc.count_right_pieces += 1;
            pc.PuzzleSolve();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LabyrinthPlayer")
        {
            rps.OnMouseDown();
        } else
        {
            StopMove(-1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == goal)
        {
            pc.count_right_pieces += 1;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ((col.gameObject == goal) && (on_move == true))
        {
            pc.count_right_pieces -= 1;
        }
    }

    public void ReturnToStart()
    {
        StopMove(1);
    }
}
