using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    //public List<CardStash> cardStashes;

    public CardStash cardStash;

    private void Awake()
    {
        //cardStash = gameObject.GetComponent<CardStash>();
    }

    //called by cards which is being picked up
    public void PlaceCard(GameObject card)
    {
        int lvl = card.GetComponent<CardStats>().lvl;
        //lvl--;

        switch (lvl)
        {
            case 1:
                if (cardStash.cardsInStash1.Count >= 1)
                {
                    cardStash.cardsInStash1[0].GetComponent<CardStats>().MoveToTable(card.GetComponent<Transform>());
                    cardStash.cardsInStash1.RemoveAt(0);
                }
                
                break;
            case 2:
                if (cardStash.cardsInStash2.Count >= 1)
                {
                    cardStash.cardsInStash2[0].GetComponent<CardStats>().MoveToTable(card.GetComponent<Transform>());
                    cardStash.cardsInStash2.RemoveAt(0);
                }
                break;
            case 3:
                if (cardStash.cardsInStash3.Count >= 1)
                {
                    cardStash.cardsInStash3[0].GetComponent<CardStats>().MoveToTable(card.GetComponent<Transform>());
                    cardStash.cardsInStash3.RemoveAt(0);
                }
                   
                break;
            default:
                break;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
