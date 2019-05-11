using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CardStats : MonoBehaviour
{
    public int whiteChipsValue;
    public int blueChipsValue;
    public int greenChipsValue;
    public int redChipsValue;
    public int blackChipsValue;

    public int lvl;

    public string color;

    public int pointValue;

    public PlayerService bookedBy;

    public bool isBooked = false;

    Vector3 targetPos;
    Quaternion targetRot;
    private bool enabledToMove;
    private float timer = 0;
    private float timerEnd = 3f;

    private void Awake()
    {
        color = name.Substring(1, 3);

        lvl = int.Parse(name.Substring(0, 1));

        pointValue = int.Parse(name.Substring(4, 1));

        whiteChipsValue = int.Parse(name.Substring(5, 1));
        blueChipsValue = int.Parse(name.Substring(6, 1));
        greenChipsValue = int.Parse(name.Substring(7, 1));
        redChipsValue = int.Parse(name.Substring(8, 1));
        blackChipsValue = int.Parse(name.Substring(9, 1));
    }

    //kattintásra vagy felveszi a kártyát vagy visszautasítja a játékost
    public void OnLeftClick(PlayerService player)
    {
        if (player.pickingChips)
        {
            print("Can't buy card and pick chips in the same turn, continue looting!");
            return;
        }
    
        if (!isPlayerBookedMe(player) && isBooked)
        {
            print("Someone else has booked this card!");
            return;
        }

        if (!CheckPlayer(player))
        {
            print("Not enough chips to buy this card!");
            return;
        }
        
        player.GetCard(GetComponent<CardStats>());
    }

    //foglalás, arany check. kihelyezni a saját deckbe. left click ugyanúgy mukődik rá. 
    public void OnRightClick(PlayerService player)
    {
        if (isBooked)
        {
            print("Someone has already booked this card!");
            return;
        }
        isBooked = true;
        bookedBy = player;
        player.BookCard(GetComponent<CardStats>());
    }

    public bool CheckPlayer(PlayerService player)
    {
        if (player.whiteChips + player.whiteCardNumber >= whiteChipsValue && 
            player.blueChips + player.blueCardNumber >= blueChipsValue &&
            player.greenChips + player.greenCardNumber >= greenChipsValue &&
            player.redChips + player.redCardNumber >= redChipsValue &&
            player.blackChips + player.blackCardNumber >= blackChipsValue)
        {
            return true;
        }
        else { return false; }
        
    }

    public bool isPlayerBookedMe(PlayerService player)
    {
        if (bookedBy == player)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void MoveToPlayer(PlayerService player)
    {
        
        switch (color)
        {
            case "WHI":
                MoveTo(player.whiteCardPlacingPoints[player.whiteCardNumber]);
                //ChangeTransform(player.whiteCardPlacingPoints[player.whiteCardNumber]);
                break;
            case "BLU":
                MoveTo(player.blueCardPlacingPoints[player.blueCardNumber]);
                //ChangeTransform(player.blueCardPlacingPoints[player.blueCardNumber]);
                break;
            case "GRE":
                MoveTo(player.greenCardPlacingPoints[player.greenCardNumber]);
                //ChangeTransform(player.greenCardPlacingPoints[player.greenCardNumber]);
                break;
            case "RED":
                MoveTo(player.redCardPlacingPoints[player.redCardNumber]);
                //ChangeTransform(player.redCardPlacingPoints[player.redCardNumber]);
                break;
            case "BLA":
                MoveTo(player.blackCardPlacingPoints[player.blackCardNumber]);
                //ChangeTransform(player.blackCardPlacingPoints[player.blackCardNumber]);
                break;
            default:
                break;
        }
       
        enabledToMove = true;
    }

    public void MoveToPlayerBooks(PlayerService player)
    {
        MoveTo(player.bookedCardPlacingPoints[player.bookedCardsNumber]);
    }

    public void MoveTo(Transform destination)
    {
        print("nem kértem el kec");
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        //gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(destination.rotation.eulerAngles.x, destination.rotation.eulerAngles.y, 0)));
        ChangeTransform(destination);
        enabledToMove = true;
    }

    public void MoveToTable(Transform destination)
    {
        print("elkérem kec");
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(destination.rotation.eulerAngles.x, destination.rotation.eulerAngles.y, 12)));
        ChangeTransform(destination);
        enabledToMove = true;
    }


    public void ChangeTransform(Transform target)
    {
        targetPos = target.position;
        targetRot = target.rotation;
       
    }

    void Update()
    {
        if (enabledToMove && timer < timerEnd)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Slerp(transform.position, targetPos, 2f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, 2f * Time.deltaTime);
            
            if (timer > timerEnd)
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                enabledToMove = false;
                timer = 0;
            }
        }
    }
}
