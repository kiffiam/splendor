using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NobleCardManager : MonoBehaviour
{

    public int nobleCardNumber;
    public List<GameObject> nobleCards;

    private void Awake()
    {
        var notRandomizedCards = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/nobleCardPrefabs"));
        nobleCards = new List<GameObject>(ShuffleCards(notRandomizedCards));

        PlaceCardsOnTable();
    }


    public List<GameObject> ShuffleCards(List<GameObject> notRandomizedCards)
    {
        var shuffledcards = notRandomizedCards.OrderBy(a => Random.Range(0, notRandomizedCards.Count + 1)).ToList();
        return shuffledcards;
    }

    public void PlaceCardsOnTable()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(nobleCards[i], transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            //más helyekre kell őket rakosgatni,positiont változtatni kell

        }
    }

    void Update()
    {
        
    }
}
