using UnityEngine;
using System;

public class PuzzleManager : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public Interactable interacble;
    void Start()
    {
        puzzleCanvas.SetActive(false);
    }
    public void ShowPuzzle()
    {
        puzzleCanvas.SetActive(true);
    }
    public void PuzzleHide()
    {
        puzzleCanvas.SetActive(false);
        interacble.UnInteractPlayer();
        
    }
}
