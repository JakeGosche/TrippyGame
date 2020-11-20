using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class LiquidPuzzleManager : MonoBehaviour
{
    public GameManager gameManager;
    public PuzzleRow[] tiles;
    public List<LiquidPuzzleEnding> endingPoints;
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
        foreach (PuzzleRow row in tiles)
        {
            foreach (PuzzleTile pt in row.rowTiles)
            {
                pt.occupied = false;
                pt.pipeImage.color = Color.black;
            }
        }
        foreach(LiquidPuzzleEnding ending in endingPoints)
        {
            ending.bottomCircle.color = Color.white;
            ending.attachedTube.color = Color.white;
        }
        exitImage.color = Color.black;
        bool activeRed = false;
        bool activeWhite = false;
        int tileColumn = 0;
        int tileRow = 4;
        //int tileWhite = 0;
        Directions redMoving = Directions.Right;
        //Directions whiteMoving = Directions.Down;
        if (IsConnected(tileColumn, tileRow, redMoving))
        {
            activeRed = true;
            tiles[tileRow].rowTiles[tileColumn].occupied = true;
            tiles[tileRow].rowTiles[tileColumn].pipeImage.color = Color.red;
        }

        //if (IsConnected(tileWhite, whiteMoving))
        //{
        //    activeWhite = true;
        //    tiles[0].occupied = true;
        //    tiles[0].pipeImage.color = Color.white;
        //}

        while (activeRed )//|| activeWhite)
        {
            //if (activeRed)
            //{
            int oldColumn = tileColumn;
            int oldRow = tileRow;
                redMoving = (OppositeDirection(redMoving) == tiles[tileRow].rowTiles[tileColumn].input1) ? tiles[tileRow].rowTiles[tileColumn].input2 : tiles[tileRow].rowTiles[tileColumn].input1;
            int result;
            if (redMoving == Directions.Left || redMoving == Directions.Right)
            {
                result = GetNextColumn(tileRow, tileColumn, redMoving);
                tileColumn = result;
            }
            else
            {
                result = GetNextRow(tileRow, tileColumn, redMoving);
                tileRow = result;
            }
                if (result < 0)
                {
                    if (result == -2)
                    {
                        LiquidPuzzleEnding liquidPuzzleEnding = endingPoints.Find(x => x.attachedColumn == oldColumn && x.attachedRow == oldRow);
                        if (liquidPuzzleEnding != null)
                        {
                            gameManager.liquidUnlockedPodId = liquidPuzzleEnding.podId;

                            liquidPuzzleEnding.bottomCircle.color = Color.red;
                            liquidPuzzleEnding.attachedTube.color = Color.red;
                    }
                        else
                        {
                            Debug.Log("Error finding ending column!");
                        }
                    }
                    activeRed = false;
                }
                else 
                {
                    if(IsConnected(tileColumn, tileRow, redMoving))
                    {
                        tiles[tileRow].rowTiles[tileColumn].pipeImage.color = Color.red;
                        tiles[tileRow].rowTiles[tileColumn].occupied = true;
                    }
                    else
                    {
                        activeRed = false;
                    }
                }
            //}

            //if (activeWhite)
            //{
            //    whiteMoving = (OppositeDirection(whiteMoving) == tiles[tileWhite].input1) ? tiles[tileWhite].input2 : tiles[tileWhite].input1;
            //    tileWhite = GetNextTile(tileWhite, whiteMoving);
            //    if (tileWhite < 0)
            //    {
            //        if (tileWhite == -2)
            //        {
                       
            //            exitImage.color = Color.white;
            //        }
            //        activeWhite = false;
            //    }
            //    else
            //    {
            //        if (IsConnected(tileWhite, whiteMoving))
            //        {
            //            tiles[tileWhite].pipeImage.color = Color.white;
            //            tiles[tileWhite].occupied = true;
            //        }
            //        else
            //        {
            //            activeWhite = false;
            //        }
            //    }
            //}
        }

    }

    public int GetNextColumn(int row, int column, Directions movingTowards)
    {
        switch (movingTowards)
        {
            case Directions.Left:
                if (column == 0)
                {
                    return -1;
                }
                else
                {
                    return column - 1;
                }
            default:
                if (column == 8)
                {
                    if (row == 2 || row == 6)
                    {

                        return -2;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return column + 1;
                }

        }
    }

    public int GetNextRow(int row, int column, Directions movingTowards)
    {
        switch (movingTowards)
        {
            case Directions.Down:

                if (row == 8)
                {
                    if (column == 2 || column == 6)
                    {

                        return -2;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return row + 1;
                }
            default:
                if (row == 0)
                {
                    if (column == 2 || column == 6)
                    {

                        return -2;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return row - 1;
                }
        }
    }

    public bool IsConnected(int column, int row, Directions movingTowards)
    {
        PuzzleTile tile = tiles[row].rowTiles[column];
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
