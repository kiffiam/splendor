using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipTextManager : MonoBehaviour
{
    public Text p1White;
    public Text p1Blue;
    public Text p1Green;
    public Text p1Red;
    public Text p1Black;
    public Text p1Gold;

    public Text p2White;
    public Text p2Blue;
    public Text p2Green;
    public Text p2Red;
    public Text p2Black;
    public Text p2Gold;

    public Text p3White;
    public Text p3Blue;
    public Text p3Green;
    public Text p3Red;
    public Text p3Black;
    public Text p3Gold;

    public Text p4White;
    public Text p4Blue;
    public Text p4Green;
    public Text p4Red;
    public Text p4Black;
    public Text p4Gold;

    public PlayerService player1;
    public PlayerService player2;
    public PlayerService player3;
    public PlayerService player4;

    void UpdateP1()
    {
        p1White.text = player1.whiteChips.Count.ToString();
        p1Blue.text = player1.blueChips.Count.ToString();
        p1Green.text = player1.greenChips.Count.ToString();
        p1Red.text = player1.redChips.Count.ToString();
        p1Black.text = player1.blackChips.Count.ToString();
        p1Gold.text = player1.goldChips.Count.ToString();
    }

    void UpdateP2()
    {
        p2White.text = player2.whiteChips.Count.ToString();
        p2Blue.text = player2.blueChips.Count.ToString();
        p2Green.text = player2.greenChips.Count.ToString();
        p2Red.text = player2.redChips.Count.ToString();
        p2Black.text = player2.blackChips.Count.ToString();
        p2Gold.text = player2.goldChips.Count.ToString();
    }

    void UpdateP3()
    {
        p3White.text = player3.whiteChips.Count.ToString();
        p3Blue.text = player3.blueChips.Count.ToString();
        p3Green.text = player3.greenChips.Count.ToString();
        p3Red.text = player3.redChips.Count.ToString();
        p3Black.text = player3.blackChips.Count.ToString();
        p3Gold.text = player3.goldChips.Count.ToString();
    }

    void UpdateP4()
    {
        p4White.text = player4.whiteChips.Count.ToString();
        p4Blue.text = player4.blueChips.Count.ToString();
        p4Green.text = player4.greenChips.Count.ToString();
        p4Red.text = player4.redChips.Count.ToString();
        p4Black.text = player4.blackChips.Count.ToString();
        p4Gold.text = player4.goldChips.Count.ToString();
    }

    public void UpdatePlayer(string name)
    {

        switch (name)
        {
            case "Player1":
                UpdateP1();
                break;
            case "Player2":
                UpdateP2();
                break;
            case "Player3":
                UpdateP3();
                break;
            case "Player4":
                UpdateP4();
                break;
            default:
                break;
        }
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
