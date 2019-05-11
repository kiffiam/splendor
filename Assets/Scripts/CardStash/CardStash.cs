using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardStash : MonoBehaviour
{
    public int cardNumber;
    
    public string lvl;
    
    private float placeTime = 1f;
    
    public List<GameObject> cardPrefabs1;
    public List<GameObject> cardsInStash1;

    public List<GameObject> cardPrefabs2;
    public List<GameObject> cardsInStash2;

    public List<GameObject> cardPrefabs3;
    public List<GameObject> cardsInStash3;

    public Transform CardBaseSpawnPoint;
    public Transform CardBaseSpawnPoint2;
    public Transform CardBaseSpawnPoint3;

    Vector3 current;
    Vector3 current2;
    Vector3 current3;

    public Transform StashPoint1;
    public Transform StashPoint2;
    public Transform StashPoint3;
    private void Awake()
    {
        current = CardBaseSpawnPoint.transform.position;
        current2 = CardBaseSpawnPoint2.transform.position;
        current3 = CardBaseSpawnPoint3.transform.position;

        lvl = name.Substring(3, 1);

        var notRandomizedCards = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/lvl1Prefabs"));
        cardPrefabs1 = new List<GameObject>(ShuffleCards(notRandomizedCards));

        var notRandomizedCards2 = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/lvl2Prefabs"));
        cardPrefabs2 = new List<GameObject>(ShuffleCards(notRandomizedCards2));

        var notRandomizedCards3 = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/lvl3Prefabs"));
        cardPrefabs3 = new List<GameObject>(ShuffleCards(notRandomizedCards3));

        PlaceCardStashOnTable();

        for (int i = 0; i < 4; i++)
        {
            Invoke("PlaceStartingCards", placeTime);
            placeTime += 3.5f;
        }
    }

    public List<GameObject> ShuffleCards(List<GameObject> notRandomizedCards)
    {    
        var shuffledcards = notRandomizedCards.OrderBy(a => Random.Range(0,notRandomizedCards.Count+1)).ToList();
        return shuffledcards;
    }

    public void PlaceCardStashOnTable()
    {
        foreach (var card in cardPrefabs1)
        {
            cardsInStash1.Add(Instantiate(card, StashPoint1.position, Quaternion.Euler(new Vector3(0, 0, 180))));
        }

        foreach (var card in cardPrefabs2)
        {
            cardsInStash2.Add(Instantiate(card, StashPoint2.position, Quaternion.Euler(new Vector3(0, 0, 180))));
        }

        foreach (var card in cardPrefabs3)
        {
            cardsInStash3.Add(Instantiate(card, StashPoint3.position, Quaternion.Euler(new Vector3(0, 0, 180))));
        }
    }

    public void PlaceStartingCards()
    {
            CardBaseSpawnPoint.position = current;
            CardBaseSpawnPoint2.position = current2;
            CardBaseSpawnPoint3.position = current3;

            cardsInStash1[0].GetComponent<CardStats>().MoveToTable(CardBaseSpawnPoint);
            current.x += 0.65f;
            cardsInStash1.RemoveAt(0);

            cardsInStash2[0].GetComponent<CardStats>().MoveToTable(CardBaseSpawnPoint2);
            current2.x += 0.65f;
            cardsInStash2.RemoveAt(0);

            cardsInStash3[0].GetComponent<CardStats>().MoveToTable(CardBaseSpawnPoint3);
            current3.x += 0.65f;
            cardsInStash3.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
    }
}
