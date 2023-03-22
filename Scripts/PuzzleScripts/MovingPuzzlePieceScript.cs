using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPuzzlePieceScript : MonoBehaviour
{
    bool moving = false;
    Vector3 delta;
    Vector3 mouse_pos;
    Vector3 start_pos;
    public int need_piece_index;
    public int current_piece_index;
    public PuzzleController pc;
    public MovePuzzleScript mps;
    public SpriteRenderer sr;
    int size;

    void Start()
    {
        start_pos = transform.localPosition;
        size = mps.puzzle_size;
    }

    void OnMouseDown()
    {
        if (pc.puzzle_on == true)
        {
            if (current_piece_index != -1)
            {
                mps.piece_place[current_piece_index] = false;
            }
            if (current_piece_index == need_piece_index)
            {
                pc.count_right_pieces -= 1;
            }
            moving = true;
            mouse_pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            delta = new Vector3(transform.localPosition.x - mouse_pos.x, transform.localPosition.y - mouse_pos.y, -1);
        }
    }

    void OnMouseUp()
    {
        if (pc.puzzle_on == true)
        {
            moving = false;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            int x1 = Mathf.RoundToInt(transform.localPosition.x / 0.64f);
            int y1 = Mathf.RoundToInt(transform.localPosition.y / 0.64f);
            if (((x1 >= 0) && (x1 <= (size - 1))) && ((y1 <= 0) && (y1 >= (-1 * size + 1))))
            {
                Anchoring(x1, y1);
            }
            else
            {
                ReturnToStart();
            }
        }
    }

    void Update()
    {
        if (moving == true)
        {
            mouse_pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            transform.localPosition = new Vector3(mouse_pos.x + delta.x, mouse_pos.y + delta.y, transform.localPosition.z);
        }
    }

    public void ReturnToStart()
    {
        transform.localPosition = start_pos;
        current_piece_index = -1;
    }

    void Anchoring(int x, int y)
    {
        current_piece_index = y * -1 * (size) + x;
        if (mps.piece_place[current_piece_index] == true)
        {
            ReturnToStart();
        } else
        {
            if (current_piece_index == need_piece_index)
            {
                pc.count_right_pieces += 1;
                if (pc.count_right_pieces == pc.need_right_pieces)
                {
                    pc.PuzzleSolve();
                }
            }
            transform.localPosition = new Vector3(0.64f * x, 0.64f * y, transform.localPosition.z);
            mps.piece_place[current_piece_index] = true;
        }
    }

    public void PieceTransform()
    {
        need_piece_index = mps.piece_indexs[need_piece_index];
        sr.sprite = mps.piece_sprs[need_piece_index];
    }
}
