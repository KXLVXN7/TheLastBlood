using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPuzzle : MonoBehaviour
{
    public List<GameObject> puzzlePieces;
    public PuzzleManager puzzleManager;

    public void CheckPuzzleStatus()
    {
        foreach (GameObject g in puzzlePieces)
        {
            if (!g.GetComponent<ObjectRotator>().kelar)
            {
                Debug.Log("Belum Selesai");
                return;
            }
        }
            Debug.Log("Selesai");
            puzzleManager.PuzzleHide();
    }
}
