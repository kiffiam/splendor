using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NobleCardStash : MonoBehaviour
{

    public int nobleCardNumber;
    public List<GameObject> nobleCards;
    public Transform nobleBaseSpawnPoint;

    private void Awake()
    {
        var notRandomizedCards = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/nobleCardsPrefabs"));
        nobleCards = new List<GameObject>(ShuffleCards(notRandomizedCards).GetRange(0,5));

        PlaceCardsOnTable();
    }


    public List<GameObject> ShuffleCards(List<GameObject> notRandomizedCards)
    {
        var shuffledcards = notRandomizedCards.OrderBy(a => Random.Range(0, notRandomizedCards.Count + 1)).ToList();
        return shuffledcards;
    }

    public void PlaceCardsOnTable()
    {
        Vector3 current;
        for (int i = 0; i < 5; i++)
        {
            current = nobleBaseSpawnPoint.position;
            current.x += i * 0.65f; 
            Instantiate(nobleCards[i], current, Quaternion.Euler(new Vector3(0, 0, 0)));
            
        }
    }

    public void CheckPlayerCardValues(PlayerService player)
    {
        var nobleCardsOnTable = new List<NobleCardStats>((NobleCardStats[])FindObjectsOfType(typeof(NobleCardStats)));

        foreach (var item in nobleCardsOnTable)
        {
           
            if (!item.isOwned)
            {
                if (item.CheckPlayer(player))
                {
                    nobleCardsOnTable.Remove(item);
                    item.isOwned = true;
                    player.GetNobleCard(item);
                }
            }
        }
    }

    void Update()
    {
        
    }
}
