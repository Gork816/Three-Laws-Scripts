using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public int count_right_pieces = 0;
    public int need_right_pieces;
    public bool puzzle_on = true;
    public int script_id;
    public LevelController lc;
    public GameObject[] pieces = new GameObject[16];
    public int puzzle_index;

    public void PuzzleSolve()
    {
        puzzle_on = false;
        lc.Script(script_id);
        switch (puzzle_index)
        {
            case 3:
                foreach (GameObject piece in pieces)
                {
                    piece.transform.position = piece.GetComponent<LabyrinthPlayerScript>().goal.transform.position;
                }
                break;
            default:
                break;
        }
    }

    public void PuzzleOn()
    {
        puzzle_on = true;
    }

    public void PuzzleOff()
    {
        puzzle_on = false;
    }
}
