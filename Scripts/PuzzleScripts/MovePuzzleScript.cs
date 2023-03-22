using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuzzleScript : MonoBehaviour
{
    public bool[] piece_place = new bool[16]; //менять вручную
    public int puzzle_size; //длина стороны паззла
    public Sprite[] piece_sprs = new Sprite[16];
    public int[] piece_indexs = new int[16];
    public PuzzleController pc;

    void Start()
    {
        for (int c = 0; c < 16; c++)
        {
            piece_indexs[c] = c;
        }
        PiecesShuffle();
    }

    public void PiecesShuffle()
    {
        for (int i = 0; i < 16; i++)
        {
            pc.count_right_pieces = 0;
            piece_place[i] = false;
            int j = Random.Range(0, 16);
            int a = piece_indexs[i];
            piece_indexs[i] = piece_indexs[j];
            piece_indexs[j] = a;
        }
        foreach (GameObject piece in pc.pieces)
        {
            piece.GetComponent<MovingPuzzlePieceScript>().PieceTransform();
        }
    }
}
