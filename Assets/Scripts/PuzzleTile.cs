using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class PuzzleTile : MonoBehaviour
{
    public LiquidPuzzleManager liquidPuzzleManager;
    public Directions input1, input2;
    public bool occupied;
    public Image pipeImage;
    
    // Start is called before the first frame update
    void Start()
    {
        //if (!occupied)
        //{
        //    pipeImage.color = Color.black;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateSquare()
    {
        this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + 90);
        input1 = TurnedDirection(input1);
        input2 = TurnedDirection(input2);
        liquidPuzzleManager.UpdateBoard();
    }

    public Directions TurnedDirection(Directions dir)
    {
        switch (dir)
        {
            case Directions.Down:
                return Directions.Right;
            case Directions.Left:
                return Directions.Down;
            case Directions.Up:
                return Directions.Left;
            default:
                return Directions.Up;
        }
    }
}
