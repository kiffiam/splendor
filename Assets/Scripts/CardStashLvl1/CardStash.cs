using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStash : MonoBehaviour
{
    public int cardNumber;
    public List<GameObject> cards;
    public string lvl;

    private void Awake()
    {
        lvl = name.Substring(3, 1);
        cards = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/lvl" + lvl + "Prefabs"));
        cardNumber = cards.Count;
        
        //animációahogy beesnek ebbe a cuccba vagy egymásra
        //TODO

        PlaceStartingCards();
    }

    //called in awake
    public void PlaceStartingCards()
    {
        //intantiate meglévő koordinátákra
    }

    //called by cards which is being picked up
    public void PlaceCard(Vector3 cardPlace)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
