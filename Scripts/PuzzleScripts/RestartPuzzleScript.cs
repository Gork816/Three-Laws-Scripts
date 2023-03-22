using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPuzzleScript : MonoBehaviour
{
    int pi;
    public GameObject puz_c;
    PuzzleController puz_con;

    void Start()
    {
        puz_con = puz_c.GetComponent<PuzzleController>();
        pi = puz_con.puzzle_index;
    }

    public void OnMouseDown()
    {
        if (puz_con.puzzle_on == true)
        {
            switch (pi)
            {
                case 1:
                    puz_con.count_right_pieces = 0;
                    foreach (GameObject piece in puz_con.pieces)
                    {
                        piece.GetComponent<PipePuzzlePieceScript>().Refresh();
                    }
                    break;
                case 2:
                    puz_c.GetComponent<MovePuzzleScript>().PiecesShuffle();
                    foreach (GameObject piece in puz_con.pieces)
                    {
                        piece.GetComponent<MovingPuzzlePieceScript>().ReturnToStart();
                    }
                    break;
                case 3:
                    puz_con.count_right_pieces = 0;
                    foreach (GameObject piece in puz_con.pieces)
                    {
                        piece.GetComponent<LabyrinthPlayerScript>().ReturnToStart();
                    }
                    break;
            }
        }
    }
}
