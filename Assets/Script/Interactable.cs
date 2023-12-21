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
                    UnInteract();
                }
                else
                {
                    Interact();
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

    void Interact()
    {
        puzzleManager.ShowPuzzle();
        playerMovement.SetCanMove(false);
        playerMovement.Freze();
        isInteracting= true;

        // Subscribe to the puzzle completion event
        puzzleManager.OnPuzzleCompleted += HandlePuzzleCompleted;
    }
    void UnInteract()
    {
        playerMovement.SetCanMove(true);
        playerMovement.Unfreeze();
        isInteracting= false;
    }

    void HandlePuzzleCompleted()
    {
        puzzleManager.HidePuzzle();
        playerMovement.SetCanMove(true);
        // Unsubscribe from the event to avoid memory leaks
        puzzleManager.OnPuzzleCompleted -= HandlePuzzleCompleted;

        // Ensure that the player can move again

    }
}


