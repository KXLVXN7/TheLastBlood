using UnityEngine;
using System;

public class PuzzleManager : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public SceneManagers gantiScene;
    public Interactable interacble;
    void Start()
    {
        puzzleCanvas.SetActive(false);
    }
    public void ShowPuzzle()
    {
        puzzleCanvas.SetActive(true);
    }
    public void HidePuzzle()
    {
        puzzleCanvas.SetActive(false);
    }
    public void PuzzleHide()
    {
        puzzleCanvas.SetActive(false);
        interacble.PlayerFinishInteract();
        gantiScene.ChangeToScene("FightLv1");
    }
}
