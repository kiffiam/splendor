using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipStashService : MonoBehaviour
{
    public string stashColor;
    public int stashNumber;
    public List<GameObject> chips;
    public GameObject coloredChips;

    private void Awake()
    {
        chips = new List<GameObject>();
        stashColor = gameObject.name.Substring(0, 3);
        if (stashColor == "GOL")
        {
            for (int i = 0; i < 5; i++)
            {
                chips.Add(Instantiate(coloredChips,transform.position,transform.rotation));
            }
            stashNumber = 5;
        }
        else
        {
            stashNumber = 7;
            for (int i = 0; i < 7; i++)
            {
                chips.Add(Instantiate(coloredChips, transform.position, transform.rotation));
            }
        }
    }

    //elvesz egyet a stashből
    public void OnLeftClick(PlayerService player)
    {
        if (stashNumber >= 1)
        {
            print("onleftclick a chipstashserviceben");
            //stashNumber--;
            player.GetChip(this);
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
            //stashNumber = stashNumber - 2;
            player.GetTwoChips(this);
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

    public void GiveChipToPlayer(PlayerService player)
    {
        chips[stashNumber-1].GetComponent<ChipService>().MoveToPlayer(player);
        player.AddChip(chips[stashNumber - 1]);
        chips.RemoveAt(stashNumber-1);
        stashNumber--;
    }

    public void GetBackChipFromPlayer(GameObject chip)
    {
        chips.Add(chip);
        chip.GetComponent<ChipService>().MoveTo(this.transform);
        stashNumber++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
