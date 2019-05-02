using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{

    public int points = 0;
    public int whiteChips = 0;
    public int blueChips = 0;
    public int greenChips = 0;
    public int redChips = 0;
    public int blackChips = 0;
    public int goldChips = 0;

    public void AddPoint(int point)
    {
        points = points + point;
    }

    public void EndTurn()
    {
        //CameraMovement.MoveToNextPlayer();
    }

    public void GetCard(CardStats card)
    {
        whiteChips = whiteChips - card.whiteChipsValue;
        blueChips = blueChips - card.blueChipsValue;
        greenChips = greenChips - card.greenChipsValue;
        redChips = redChips - card.redChipsValue;
        blackChips = blackChips - card.blackChipsValue;
        AddPoint(card.pointValue);

        //animácio ? vagy hogyafaszba kerül elé
    }

    public void GetChip()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
