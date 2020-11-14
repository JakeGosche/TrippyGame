using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class LiquidPuzzleManager : MonoBehaviour
{
    public GameManager gameManager;
    public PuzzleTile[] tiles;
    public Image exitImage;
    public DreamManager dreamManager;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPuzzle()
    {
        UpdateBoard();
    }

    public void UpdateBoard()
    {
        foreach (PuzzleTile tile in tiles)
        {
            tile.occupied = false;
            tile.pipeImage.color = Color.black;
        }
        exitImage.color = Color.black;
        bool activeRed = false;
        bool activeWhite = false;
        int tileRed = 20;
        int tileWhite = 0;
        Directions redMoving = Directions.Right;
        Directions whiteMoving = Directions.Down;
        if (IsConnected(tileRed, redMoving))
        {
            activeRed = true;
            tiles[20].occupied = true;
            tiles[20].pipeImage.color = Color.red;
        }

        if (IsConnected(tileWhite, whiteMoving))
        {
            activeWhite = true;
            tiles[0].occupied = true;
            tiles[0].pipeImage.color = Color.white;
        }

        while (activeRed || activeWhite)
        {
            if (activeRed)
            {
                redMoving = (OppositeDirection(redMoving) == tiles[tileRed].input1) ? tiles[tileRed].input2 : tiles[tileRed].input1;
                tileRed = GetNextTile(tileRed, redMoving);
                if(tileRed < 0)
                {
                    if (tileRed == -2)
                    {
                        gameManager.unlockedConvos[4] = true;
                        exitImage.color = Color.red;
                    }
                    activeRed = false;
                }
                else 
                {
                    if(IsConnected(tileRed, redMoving))
                    {
                        tiles[tileRed].pipeImage.color = Color.red;
                        tiles[tileRed].occupied = true;
                    }
                    else
                    {
                        activeRed = false;
                    }
                }
            }

            if (activeWhite)
            {
                whiteMoving = (OppositeDirection(whiteMoving) == tiles[tileWhite].input1) ? tiles[tileWhite].input2 : tiles[tileWhite].input1;
                tileWhite = GetNextTile(tileWhite, whiteMoving);
                if (tileWhite < 0)
                {
                    if (tileWhite == -2)
                    {
                       
                        exitImage.color = Color.white;
                    }
                    activeWhite = false;
                }
                else
                {
                    if (IsConnected(tileWhite, whiteMoving))
                    {
                        tiles[tileWhite].pipeImage.color = Color.white;
                        tiles[tileWhite].occupied = true;
                    }
                    else
                    {
                        activeWhite = false;
                    }
                }
            }
        }

    }

    public int GetNextTile(int squareId, Directions movingTowards)
    {
        switch (movingTowards)
        {
            case Directions.Down:
                if(squareId >= 20)
                {
                    return -1;
                }
                else
                {
                    return squareId + 5;
                }
            case Directions.Left:
                if(squareId == 0 || squareId % 5 == 0)
                {
                    return -1;
                }
                else
                {
                    return squareId - 1;
                }
            case Directions.Up:
                if(squareId <= 4)
                {
                    return -1;
                }
                else
                {
                    return squareId - 5;
                }
            default:
                if (squareId == 14)
                {
                    return -2;
                }
                else
                {

                    if ((squareId + 1) % 5 == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return squareId + 1;
                    }
                }

        }
    }

    public bool IsConnected(int squareID, Directions movingTowards)
    {
        PuzzleTile tile = tiles[squareID];
        if (tile.occupied)
        {
            return false;
        }
        else
        {
            Directions neededDirection = OppositeDirection(movingTowards);
            if(neededDirection == tile.input1 || neededDirection == tile.input2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public Directions OppositeDirection(Directions dir)
    {
        switch (dir)
        {
            case Directions.Down:
                return Directions.Up;
            case Directions.Left:
                return Directions.Right;
            case Directions.Up:
                return Directions.Down;
            default:
                return Directions.Left;
        }
    }
}
