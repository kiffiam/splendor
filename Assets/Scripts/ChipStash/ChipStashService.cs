using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipStashService : MonoBehaviour
{
    public Color stashColor;

    public int stashNumber;

    //elvesz egyet a stashből
    void OnLeftClick() { }

    //elvesz kettőt a stashből, ha legalább kettő maradna a vétel után, következő játékos
    void OnRigthClick()
    {
        if (stashNumber - 2 >= 2)
        {
            //itt átmegy a 2 chips a játékoshoz
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
