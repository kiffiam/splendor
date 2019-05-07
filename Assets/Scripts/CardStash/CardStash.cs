using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardStash : MonoBehaviour
{
    public int cardNumber;
    public List<GameObject> cards;
    public string lvl;

    private void Awake()
    {
        lvl = name.Substring(3, 1);
        var notRandomizedCards = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/lvl" + lvl + "Prefabs"));
        cards = new List<GameObject>(ShuffleCards(notRandomizedCards));

        //cards = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/lvl" + lvl + "Prefabs"));

        cardNumber = cards.Count;
        
        PlaceCardsOnTable();
    }

    public List<GameObject> ShuffleCards(List<GameObject> notRandomizedCards)
    {    
        var shuffledcards = notRandomizedCards.OrderBy(a => Random.Range(0,notRandomizedCards.Count+1)).ToList();
        return shuffledcards;
    }

    //called in awake
    public void PlaceCardsOnTable()
    {
        foreach (var card in cards)
        {
            Instantiate(card, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
        }
        
    }

    //called by cards which is being picked up
    public void PlaceCard(Vector3 cardPlace)
    {

    }

    public void PlaceStartingCards()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
