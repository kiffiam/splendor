using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClicking : MonoBehaviour
{

    //kártyára leftclick
    public void OnCardLeftClick(CardStats card)
    {
        card.checkPlayer();
    }

    public void OnChipLeftClick(ChipStashService chipStash)
    {
        chipStash.OnLeftClick();
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
