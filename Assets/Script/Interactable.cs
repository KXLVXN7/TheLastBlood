using UnityEngine;

public class Interactable : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public PlayerMovement playerMovement;
    public float interactionDistance = 2f;
    private bool isInteracting = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsPlayerNearby())
            {
                if (isInteracting)
                {
                    UnInteractPlayer();
                }
                else
                {
                    InteractWithObject();
                }
            }
        }
    }

    bool IsPlayerNearby()
    {
        Vector3 playerPosition = playerMovement.transform.position;
        Vector3 objectPosition = transform.position;
        float distance = Vector3.Distance(playerPosition, objectPosition);
        return distance <= interactionDistance;
    }

    void InteractWithObject()
    {
        puzzleManager.ShowPuzzle();
        playerMovement.SetCanMove(false);
        playerMovement.Freze();
        isInteracting= true;

    }
    public void UnInteractPlayer()
    {
        playerMovement.SetCanMove(true);
        playerMovement.Unfreeze();
        isInteracting = false;
    }
    public void PlayerFinishInteract()
    {
        playerMovement.SetCanMove(true);
        playerMovement.Unfreeze();
        isInteracting = false;
        Debug.Log("Interaksi Puzzle Selesai");
    }
}


