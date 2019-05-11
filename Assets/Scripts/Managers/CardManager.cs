using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<CardStash> cardStashes;

    private void Awake()
    {
        
    }

    //called by cards which is being picked up
    public void PlaceCard(GameObject card)
    {
        int lvl = card.GetComponent<CardStats>().lvl;
        lvl--;

        cardStashes[lvl].cardsInStash[0].GetComponent<CardStats>().MoveToTable(card.transform);
        cardStashes[lvl].cardsInStash.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
