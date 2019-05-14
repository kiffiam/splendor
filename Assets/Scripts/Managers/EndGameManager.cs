using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public CameraMovement cameraMovement;

    public PlayerService WhoWon()
    {
        PlayerService winner = new PlayerService();
        winner.points = 0;
        foreach (var player in cameraMovement.players)
        {
            PlayerService current = player.GetComponent<PlayerService>();

            if (current.points == winner.points)
            {
                if (current.CardNumber() < winner.CardNumber())
                {
                    winner = player.GetComponent<PlayerService>();
                }
            }
            if (current.points > winner.points)
            {
                winner = player.GetComponent<PlayerService>();
            }    
        }
        print(winner.gameObject.name);
        return winner;
        
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
