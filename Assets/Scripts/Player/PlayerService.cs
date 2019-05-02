using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    bool isOnTurn = false;
    CameraMovement cameraMovement;

    public int points = 0;

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

    private void Awake()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
        whiteChips = 4;
        blueChips = 4;
        greenChips = 4;
        redChips = 4;
        blackChips = 4;
        goldChips = 0;
    }

    public void AddPoint(int point)
    {
        points = points + point;
    }

    public void EndTurn()
    {
        cameraMovement.MoveToNextPlayer();
        isOnTurn = false;
    }

    private void AddCardPoint(CardStats card)
    {
        switch (card.color)
        {
            case "WHI":
                whiteCardNumber++;
                print(whiteCardNumber);
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

        AddPoint(card.pointValue);
        AddCardPoint(card);

        //animácio ? vagy hogyafaszba kerül elé

        EndTurn();
    }

    public void GetThreeDifferentChips()
    {
        
        EndTurn();
    }

    public void GetTwoChips()
    {

        EndTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
