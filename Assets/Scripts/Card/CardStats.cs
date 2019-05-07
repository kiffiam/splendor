﻿using System.Collections;
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

    public string color;

    public int pointValue;

    public PlayerService bookedBy;

    public bool isBooked = false;

    private void Awake()
    {
        color = name.Substring(1, 3);

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
        
        player.GetCard(this.GetComponent<CardStats>());
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
        player.BookCard();
        //anim a playerhez, arany zseton a playerhez
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


    //void onHover() ha a kurzor rajta van akkor kiírja az értékét

    // Update is called once per frame
    void Update()
    {
        
    }
}
