using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipStashService : MonoBehaviour
{
    public string stashColor;
    public int stashNumber;




    private void Awake()
    {
        stashColor = gameObject.name.Substring(0, 3);
        if (stashColor == "GOL")
        {
            stashNumber = 5;
        }
        else { stashNumber = 7; }
        
    }

    //elvesz egyet a stashből
    public void OnLeftClick(PlayerService player)
    {
        if (stashNumber >= 1)
        {
            stashNumber--;
            player.GetChip(stashColor);
            
        }
        else
        {
            print("Not enough chips in the stash!");
        }
    }

    //elvesz kettőt a stashből, ha legalább kettő maradna a vétel után, következő játékos
    public void OnRigthClick(PlayerService player)
    {
        if (stashNumber - 2 >= 2)
        {
            stashNumber = stashNumber - 2;
            player.GetTwoChips(stashColor);
        }
        else
        {
            print("Not enough chips in the stash!");
        }
    }

    public void IncreaseStashNumber(int chipNumber)
    {
        stashNumber = stashNumber + chipNumber;
    }

    public void DecreaseStashNumber(int chipNumber)
    {
        if (chipNumber >= stashNumber)
        {
            stashNumber = 0;
        }
        else
        {
            stashNumber = stashNumber - chipNumber;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
