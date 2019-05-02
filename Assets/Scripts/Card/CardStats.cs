using System.Collections;
using System.Collections.Generic;
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

    //kattintásra vagy felveszi a kártyát vagy visszautasítja a játékost
    void onLeftClick()
    {
        if (checkPlayer())
        {
            //player.getCard
        }
    }

    //foglalás, arany check. kihelyezni a saját deckbe. left click ugyanúgy mukődik rá. 
    void OnRightClick()
    {

    }

    public bool checkPlayer()
    {
        if (white)
        {
            if (blue)
            {
                if (green)
                {
                    if (red)
                    {
                        if (black)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    //void onHover() ha a kurzor rajta van akkor kiírja az értékét
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
