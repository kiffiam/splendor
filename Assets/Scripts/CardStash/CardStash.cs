using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardStash : MonoBehaviour
{
    public int cardNumber;
    public List<GameObject> cardPrefabs;
    public List<GameObject> cardsInStash;
    public string lvl;
    public Transform CardBaseSpawnPoint;
    private float placeTime = 1f;
    Vector3 current;
    
    private void Awake()
    {
        current = CardBaseSpawnPoint.transform.position;

        lvl = name.Substring(3, 1);

        var notRandomizedCards = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/lvl" + lvl + "Prefabs"));
        cardPrefabs = new List<GameObject>(ShuffleCards(notRandomizedCards));

        PlaceCardStashOnTable();
        //PlaceStartingCards();
        for (int i = 0; i < 4; i++)
        {
            Invoke("PlaceStartingCards", placeTime);
            placeTime += 3f;
        }
        
        
        cardNumber = cardsInStash.Count;
    }

    public List<GameObject> ShuffleCards(List<GameObject> notRandomizedCards)
    {    
        var shuffledcards = notRandomizedCards.OrderBy(a => Random.Range(0,notRandomizedCards.Count+1)).ToList();
        return shuffledcards;
    }

    public void PlaceCardStashOnTable()
    {
        foreach (var card in cardPrefabs)
        {
            cardsInStash.Add(Instantiate(card, transform.position, Quaternion.Euler(new Vector3(0, 0, 180))));
        }
    }

    public void PlaceStartingCards()
    {
        
        //for (int i = 0; i < 4; i++)
        //{

            
            CardBaseSpawnPoint.position = current;
            
            cardsInStash[0].GetComponent<CardStats>().MoveToTable(CardBaseSpawnPoint);
            current.x += 0.65f;
            //original.x += 0.65f;
            cardsInStash.RemoveAt(0);
            //repeatTime = 0;
            //timer = 0;
            //Instantiate(cardPrefabs[i], current, Quaternion.Euler(new Vector3(0, 0, 0)));
            //current.x += 0.65f;
        //}
        //cardsInStash.RemoveRange(0,4);
    }

    

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
    }
}
