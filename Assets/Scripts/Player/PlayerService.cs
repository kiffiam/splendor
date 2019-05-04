using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    bool isOnTurn = false;
    CameraMovement cameraMovement;

    List<ChipStashService> chipStashes;

    public int points = 0;

    public int chipsToTake = 3;

    public List<string> chipsTaken;

    public int whiteChips = 0;
    public int blueChips = 0;
    public int greenChips = 0;
    public int redChips = 0;
    public int blackChips = 0;
    public int goldChips = 0;

    public int whiteCardNumber;
    public int blueCardNumber;
    public int greenCardNumber;
    public int redCardNumber;
    public int blackCardNumber;

    public bool pickingChips = false;

    private void Awake()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();

        whiteChips = 4; //for testing
        blueChips = 4;
        greenChips = 4;
        redChips = 4;
        blackChips = 4;
        goldChips = 0;

        chipsToTake = 3;

        chipsTaken = new List<string>();

        chipStashes = new List<ChipStashService>((ChipStashService[])FindObjectsOfType(typeof(ChipStashService)));
            
    }

    public void AddPoint(int point)
    {
        points = points + point;
    }

    public void EndTurn()
    {
        chipsToTake = 3;
        chipsTaken.Clear();
        isOnTurn = false;
        pickingChips = false;
        cameraMovement.MoveToNextPlayer();
    }

    private void AddCardGem(string cardColor)
    {
        switch (cardColor)
        {
            case "WHI":
                whiteCardNumber++;
                break;
            case "BLU":
                blueCardNumber++;
                break;
            case "GRE":
                greenCardNumber++;
                break;
            case "RED":
                redCardNumber++;
                break;
            case "BLA":
                blackCardNumber++;
                break;
            default:
                break;
        }
    }

    public void GetCard(CardStats card)
    {
        whiteChips = whiteChips - card.whiteChipsValue;
        blueChips = blueChips - card.blueChipsValue;
        greenChips = greenChips - card.greenChipsValue;
        redChips = redChips - card.redChipsValue;
        blackChips = blackChips - card.blackChipsValue;

        PayChips(card);

        AddPoint(card.pointValue);

        AddCardGem(card.color);

        EndTurn();
    }

    public void GetTwoChips(string chipStashColor)
    {
        if (chipsToTake == 3 && chipStashColor!= "GOL" )
        {
            GetChip(chipStashColor);
            GetChip(chipStashColor);
            EndTurn();
        }
        else
        {
            print("Cannot do that!");
        }
    }

    public void PayChips(CardStats card)
    {
        foreach (var stash in chipStashes)
        {
            switch (stash.stashColor)
            {
                case "WHI":
                    stash.IncreaseStashNumber(card.whiteChipsValue);
                    break;
                case "BLU":
                    stash.IncreaseStashNumber(card.blueChipsValue);
                    break;
                case "GRE":
                    stash.IncreaseStashNumber(card.greenChipsValue);
                    break;
                case "RED":
                    stash.IncreaseStashNumber(card.redChipsValue);
                    break;
                case "BLA":
                    stash.IncreaseStashNumber(card.blackChipsValue);
                    break;
                case "GOL":
                    //stash.IncreaseStashNumber(1);
                    break;
                default:
                    break;
            }
        }
    }

    public void GetChip(string chipStashColor)
    {
        
        switch (chipStashColor)
        {
            case "WHI":
                whiteChips++;
                break;
            case "BLU":
                blueChips++;
                break;
            case "GRE":
                greenChips++;
                break;
            case "RED":
                redChips++;
                break;
            case "BLA":
                blackChips++;
                break;
            case "GOL":
                if (chipsTaken.Count == 0)
                {
                    goldChips++;
                    EndTurn();
                }
                else
                {
                    print("Can't get colored and gold chips in the same turn!");
                    return;
                }
                break;
            default:
                break;
        }

        chipsTaken.Add(chipStashColor);

        chipsToTake--;

        pickingChips = true;

        if (chipsToTake == 0)
        {
            EndTurn();
        }

    }

    public void BookCard()
    {
        goldChips--;

        //ez nem kell ide mert a kártyára megy majd vétel után kerul a stashbe
        //chipStashes.Find(s => s.stashColor == "GOL").IncreaseStashNumber(1);
    }
}
