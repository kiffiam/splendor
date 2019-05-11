using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    bool isOnTurn = false;

    CameraMovement cameraMovement;

    public CardManager cardManager;

    List<ChipStashService> chipStashes;

    public Transform[] nobleCardPlacingPoints;

    public Transform[] whiteCardPlacingPoints;
    public Transform[] blueCardPlacingPoints;
    public Transform[] greenCardPlacingPoints;
    public Transform[] redCardPlacingPoints;
    public Transform[] blackCardPlacingPoints;

    public Transform[] bookedCardPlacingPoints;

    public Transform[] whiteChipPlacingPoints;
    public Transform[] blueChipPlacingPoints;
    public Transform[] greenChipPlacingPoints;
    public Transform[] redChipPlacingPoints;
    public Transform[] blackChipPlacingPoints;
    public Transform[] goldChipPlacingPoints;

    public List<string> chipsTaken;

    public int points = 0;

    public int chipsToTake = 3;

    public int whiteChipNumber = 0;
    public int blueChipNumber = 0;
    public int greenChipNumber = 0;
    public int redChipNumber = 0;
    public int blackChipNumber = 0;
    public int goldChipNumber = 0;

    private int missingChipNumber = 0;

    public List<GameObject> goldChips;
    public List<GameObject> whiteChips;
    public List<GameObject> blueChips;
    public List<GameObject> greenChips;
    public List<GameObject> redChips;
    public List<GameObject> blackChips;

    public int whiteCardNumber = 0;
    public int blueCardNumber = 0;
    public int greenCardNumber = 0;
    public int redCardNumber = 0;
    public int blackCardNumber = 0;

    public int bookedCardsNumber = 0;

    public int nobleCards = 0;

    public NobleCardStash nobleCardStash;

    public bool pickingChips = false;



    private void Awake()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();

        goldChips = new List<GameObject>();
        whiteChips = new List<GameObject>();
        blueChips = new List<GameObject>();
        greenChips = new List<GameObject>();
        redChips = new List<GameObject>();
        blackChips = new List<GameObject>();

        nobleCardStash = (NobleCardStash)FindObjectOfType(typeof(NobleCardStash));

        whiteChipNumber = 0; //for testing
        blueChipNumber = 0;
        greenChipNumber = 0;
        redChipNumber = 0;
        blackChipNumber = 0;
        goldChipNumber = 0;

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
        if (card.isBooked)
        {
            bookedCardsNumber--;
        }

        whiteChipNumber = whiteChipNumber - card.whiteChipsValue;
        blueChipNumber = blueChipNumber - card.blueChipsValue;
        greenChipNumber = greenChipNumber - card.greenChipsValue;
        redChipNumber = redChipNumber - card.redChipsValue;
        blackChipNumber = blackChipNumber - card.blackChipsValue;

        PayChips(card);

        AddPoint(card.pointValue);

        AddCardGem(card.color);

        card.MoveToPlayer(this);

        cardManager.PlaceCard(card.gameObject);

        nobleCardStash.CheckPlayerCardValues(this);

        EndTurn();
    }

    public void GetTwoChips(ChipStashService chipStash)
    {
        if (chipsToTake == 3 && chipStash.stashColor != "GOL")
        {
            GetChip(chipStash);
            GetChip(chipStash);
            EndTurn();
        }
        else
        {
            print("Cannot do that!");
        }
    }

    public void PayChips(CardStats card)
    {


        if (card.whiteChipsValue != 0)
        {
            chipStashes.Find(c => c.stashColor == "WHI").GetBackChipFromPlayer(whiteChips[whiteChipNumber-1]);
            whiteChips.RemoveAt(whiteChipNumber-1);
        }
        if (card.blueChipsValue != 0)
        {
            chipStashes.Find(c => c.stashColor == "BLU").GetBackChipFromPlayer(blueChips[0]);
            blueChips.RemoveAt(0);
        }
        if (card.greenChipsValue != 0)
        {
            chipStashes.Find(c => c.stashColor == "GRE").GetBackChipFromPlayer(greenChips[0]);
            greenChips.RemoveAt(0);
        }
        if (card.redChipsValue != 0)
        {
            chipStashes.Find(c => c.stashColor == "RED").GetBackChipFromPlayer(redChips[0]);
            redChips.RemoveAt(0);
        }
        if (card.blackChipsValue != 0)
        {
            chipStashes.Find(c => c.stashColor == "BLA").GetBackChipFromPlayer(blackChips[0]);
            blackChips.RemoveAt(0);
        }
        //missing chips paying wih golds
        /*if (missingChipsNumber>0)
        {
            chipStashes.Find(c => c.stashColor == "GOL").GetBackChipFromPlayer(goldChips[0]);
            goldChips.RemoveAt(0);
        }*/

        /*foreach (var stash in chipStashes)
        {
            switch (stash.stashColor)
            {
                case "WHI":
                    //stash.IncreaseStashNumber(card.whiteChipsValue);
                    for (int i = 0; i < card.whiteChipsValue; i++)
                    {
                        stash.GetBackChipFromPlayer(whiteChips[0]);
                        whiteChips.RemoveAt(0);
                    }
                    break;
                case "BLU":
                    //stash.IncreaseStashNumber(card.blueChipsValue);
                    for (int i = 0; i < card.blueChipsValue; i++)
                    {
                        stash.GetBackChipFromPlayer(blueChips[0]);
                        blueChips.RemoveAt(0);
                    }
                    break;
                case "GRE":
                    //stash.IncreaseStashNumber(card.greenChipsValue);
                    for (int i = 0; i < card.greenChipsValue; i++)
                    {
                        stash.GetBackChipFromPlayer(greenChips[0]);
                        greenChips.RemoveAt(0);
                    }
                    break;
                case "RED":
                    //stash.IncreaseStashNumber(card.redChipsValue);
                    for (int i = 0; i < card.redChipsValue; i++)
                    {
                        stash.GetBackChipFromPlayer(redChips[0]);
                        redChips.RemoveAt(0);
                    }
                    break;
                case "BLA":
                    //stash.IncreaseStashNumber(card.blackChipsValue);
                    for (int i = 0; i < card.blackChipsValue; i++)
                    {
                        stash.GetBackChipFromPlayer(blackChips[0]);
                        blackChips.RemoveAt(0);
                    }
                    break;
                case "GOL":
                    /*stash.IncreaseStashNumber(1);
                    for (int i = 0; i < missing; i++)
                    {

                    }
                    stash.GetBackChipFromPlayer(goldChips[0]);
                    goldChips.RemoveAt(0);
                    break;
                default:
                    break;
            }*/
        
    }

    public void GetChip(ChipStashService chipStash)
    {
        
        switch (chipStash.stashColor)
        {
            case "WHI":
                whiteChipNumber++;
                break;
            case "BLU":
                blueChipNumber++;
                break;
            case "GRE":
                greenChipNumber++;
                break;
            case "RED":
                redChipNumber++;
                break;
            case "BLA":
                blackChipNumber++;
                break;
            case "GOL":
                print("Book a card with right click to earn a gold chip!");
                return;
            default:
                break;
        }

        chipStash.GiveChipToPlayer(this);

        chipsTaken.Add(chipStash.stashColor);

        chipsToTake--;

        pickingChips = true;

        if (chipsToTake == 0)
        {
            EndTurn();
        }

    }

    public void BookCard(CardStats card)
    {
        card.MoveToPlayerBooks(this);

        cardManager.PlaceCard(card.gameObject);

        goldChipNumber++;
        bookedCardsNumber++;

        chipStashes.Find(c => c.stashColor == "GOL").GiveChipToPlayer(this);
        //chipStashes.Find(c => c.stashColor == "GOL").DecreaseStashNumber(1);

        EndTurn();
    }

    public void GetNobleCard(NobleCardStats nobleCard)
    {
        points = points + nobleCard.pointValue;
        nobleCard.MoveToPlayer(this);
        nobleCards++;
    }

    public void AddChip(GameObject chip)
    {
        switch (chip.GetComponent<ChipService>().color)
        {
            case "WHI":
                whiteChips.Add(chip);
                break;
            case "BLU":
                blueChips.Add(chip);
                break;
            case "GRE":
                greenChips.Add(chip);
                break;
            case "RED":
                redChips.Add(chip);
                break;
            case "BLA":
                blackChips.Add(chip);
                break;
            case "GOL":
                goldChips.Add(chip);
            break;
            default:
                break;
        }
    }
}
