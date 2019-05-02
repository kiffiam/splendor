using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipStashService : MonoBehaviour
{
    public string stashColor;

    public int stashNumber;

    //elvesz egyet a stashből
    public void OnLeftClick()
    {
        if (stashNumber >= 1)
        {
            stashNumber--;
            //player chip ++
        }
    }

    //elvesz kettőt a stashből, ha legalább kettő maradna a vétel után, következő játékos
    public void OnRigthClick()
    {
        if (stashNumber - 2 >= 2)
        {
            stashNumber = stashNumber - 2;
            //player chip = player chips + 2;
            //endturn
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
