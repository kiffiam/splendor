using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobleCardStats : MonoBehaviour
{
    public int pointValue;

    public int whiteCardValue;
    public int blueCardValue;
    public int greenCardValue;
    public int redCardValue;
    public int blackCardValue;

    private void Awake()
    {
        pointValue = int.Parse(name.Substring(1, 1));

        whiteCardValue = int.Parse(name.Substring(2, 1));
        blueCardValue = int.Parse(name.Substring(3, 1));
        greenCardValue = int.Parse(name.Substring(4, 1));
        redCardValue = int.Parse(name.Substring(5, 1));
        blackCardValue = int.Parse(name.Substring(6, 1));
    }

    public void OnLeftClick(PlayerService player)
    {
        if (CheckPlayer(player))
        {
            player.GetCard(this.GetComponent<CardStats>());
            //return true;
        }
        else
        {
            print("not enough chips");
            //return false;
        }
    }

    public bool CheckPlayer(PlayerService player)
    {
        if (player.whiteCardNumber >= whiteCardValue &&
            player.blueCardNumber >= blueCardValue &&
            player.greenCardNumber >= greenCardValue &&
            player.redCardNumber >= redCardValue &&
            player.blackCardNumber >= blackCardValue)
        {
            return true;
        }
        else { return false; }

    }
}
