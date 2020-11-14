using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject puzzleBackground;
    public GameObject[] puzzleObjects;
    public PlayerController player;
    public int puzzleActive = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleActive >= 0 && Input.GetKey(KeyCode.Escape))
        {
            puzzleBackground.gameObject.SetActive(false);
            puzzleObjects[puzzleActive].SetActive(false);
            puzzleActive = -1;
            player.canMove = true;
        }
    }

    public void StartPuzzle(int puzzleId)
    {
        puzzleBackground.gameObject.SetActive(true);
        puzzleObjects[puzzleId].SetActive(true);
        switch (puzzleId)
        {
            case 0:
               
                LiquidPuzzleManager liquidPuzzleManager = puzzleObjects[0].GetComponent<LiquidPuzzleManager>();
                liquidPuzzleManager.OpenPuzzle();
                break;

        }

        puzzleActive = puzzleId;
    }
}
