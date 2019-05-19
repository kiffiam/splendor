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
    public List<bool> freeBookedPlaces;

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

    ChipTextManager chipTextManager;

    private void Awake()
    {
        chipTextManager = FindObjectOfType<ChipTextManager>();
        cameraMovement = Camera.main.GetComponent<CameraMovement>();

        goldChips = new List<GameObject>();
        whiteChips = new List<GameObject>();
        blueChips = new List<GameObject>();
        greenChips = new List<GameObject>();
        redChips = new List<GameObject>();
        blackChips = new List<GameObject>();

        freeBookedPlaces = new List<bool>();
        for (int i = 0; i < 4; i++)
        {
            freeBookedPlaces.Add(true);
        }

        nobleCardStash = (NobleCardStash)FindObjectOfType(typeof(NobleCardStash));

        whiteChipNumber = 0;
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
        chipTextManager.UpdatePlayer(this.name);
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
            freeBookedPlaces[card.cardInBookingPlaceNumber] = true;
        }

        PayChips(card);

        AddPoint(card.pointValue);

        AddCardGem(card.color);

        card.MoveToPlayer(this);

        nobleCardStash.CheckPlayerCardValues(this);

        if (!card.isBooked) { cardManager.PlaceCard(card.gameObject); }
        
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

        for (int i = 0; i < card.whiteChipsValue-whiteCardNumber; i++)
        {
            if (whiteChips.Count != 0)
            {
                chipStashes.Find(c => c.stashColor == "WHI").GetBackChipFromPlayer(whiteChips[whiteChips.Count - 1]);
                whiteChips.RemoveAt(whiteChips.Count - 1);
                whiteChipNumber--;
            }
            else
            {
                chipStashes.Find(c => c.stashColor == "GOL").GetBackChipFromPlayer(goldChips[goldChips.Count-1]);
                goldChips.RemoveAt(goldChips.Count-1);
                goldChipNumber--;
            }
        }
        for (int i = 0; i < card.blueChipsValue-blueCardNumber; i++)
        {
            if (blueChips.Count != 0)
            {
                chipStashes.Find(c => c.stashColor == "BLU").GetBackChipFromPlayer(blueChips[blueChips.Count - 1]);
                blueChips.RemoveAt(blueChips.Count - 1);
                blueChipNumber--;
            }
            else
            {
                chipStashes.Find(c => c.stashColor == "GOL").GetBackChipFromPlayer(goldChips[goldChips.Count - 1]);
                goldChips.RemoveAt(goldChips.Count - 1);
                goldChipNumber--;
            }
        }
        for (int i = 0; i < card.greenChipsValue-greenCardNumber; i++)
        {
            if (greenChips.Count != 0)
            {
                chipStashes.Find(c => c.stashColor == "GRE").GetBackChipFromPlayer(greenChips[greenChips.Count - 1]);
                greenChips.RemoveAt(greenChips.Count - 1);
                greenChipNumber--;
            }
            else
            {
                chipStashes.Find(c => c.stashColor == "GOL").GetBackChipFromPlayer(goldChips[goldChips.Count - 1]);
                goldChips.RemoveAt(goldChips.Count - 1);
                goldChipNumber--;
            }
        }
        for (int i = 0; i < card.redChipsValue-redCardNumber; i++)
        {
            if (redChips.Count != 0)
            {
                chipStashes.Find(c => c.stashColor == "RED").GetBackChipFromPlayer(redChips[redChips.Count - 1]);
                redChips.RemoveAt(redChips.Count - 1);
                redChipNumber--;
            }
            else
            {
                chipStashes.Find(c => c.stashColor == "GOL").GetBackChipFromPlayer(goldChips[goldChips.Count - 1]);
                goldChips.RemoveAt(goldChips.Count - 1);
                goldChipNumber--;
            }
        }
        for (int i = 0; i < card.blackChipsValue-blackCardNumber; i++)
        {
            if (blackChips.Count != 0)
            {
                chipStashes.Find(c => c.stashColor == "BLA").GetBackChipFromPlayer(blackChips[blackChips.Count - 1]);
                blackChips.RemoveAt(blackChips.Count - 1);
                blackChipNumber--;
            }
            else
            {
                chipStashes.Find(c => c.stashColor == "GOL").GetBackChipFromPlayer(goldChips[goldChips.Count - 1]);
                goldChips.RemoveAt(goldChips.Count - 1);
                goldChipNumber--;
            }
        }
        

        
        
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

    public int CardNumber()
    {
        int cardNumber = whiteCardNumber + blueCardNumber + greenCardNumber + redCardNumber + blackCardNumber;
        return cardNumber;
    }
}
