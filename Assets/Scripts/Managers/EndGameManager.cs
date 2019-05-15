using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public CameraMovement cameraMovement;

    public Text winnerPlayerText;

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
        winnerPlayerText.text = winner.name + " has won!";
        gameObject.GetComponent<Animator>().SetTrigger("GameOver");
        return winner;
    }


    private void Awake()
    {
        winnerPlayerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMovement.lastCounter == 0)
        {
            WhoWon();
        }

    }
}
