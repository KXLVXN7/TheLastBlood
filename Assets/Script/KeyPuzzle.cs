using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPuzzle : MonoBehaviour
{
    public List<GameObject> puzzlePieces;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckPuzzleStatus()
    {
        foreach (GameObject g in puzzlePieces)
        {
            if (!g.GetComponent<ObjectRotator>().kelar)
            {
                Debug.Log("blum kelar");
                return;
            }
        }
        Debug.Log("kelar");
    }
}
