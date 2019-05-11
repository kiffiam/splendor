using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobleCardStats : MonoBehaviour
{
    public int pointValue;

    public int whiteCardValue;
    public int blueCardValue;
    public int greenCardValue;
    public int redCardValue;
    public int blackCardValue;

    public bool isOwned = false;

    Vector3 targetPlayerPos;
    Quaternion targetPlayerRot;

    protected float timer = 0;

    bool enabledToMove = false;


    private void Awake()
    {
        pointValue = int.Parse(name.Substring(1, 1));

        gameObject.GetComponent<Rigidbody>().useGravity = true;

        whiteCardValue = int.Parse(name.Substring(2, 1));
        blueCardValue = int.Parse(name.Substring(3, 1));
        greenCardValue = int.Parse(name.Substring(4, 1));
        redCardValue = int.Parse(name.Substring(5, 1));
        blackCardValue = int.Parse(name.Substring(6, 1));
    }

    public bool CheckPlayer(PlayerService player)
    {
        if (player.whiteCardNumber >= whiteCardValue &&
            player.blueCardNumber >= blueCardValue &&
            player.greenCardNumber >= greenCardValue &&
            player.redCardNumber >= redCardValue &&
            player.blackCardNumber >= blackCardValue)
        {
            return true;
        }
        else { return false; }

    }

    public void MoveToPlayer(PlayerService player)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        targetPlayerPos = player.nobleCardPlacingPoints[player.nobleCards].position;
        targetPlayerRot = player.nobleCardPlacingPoints[player.nobleCards].rotation;
        enabledToMove = true;
    }


    private void Update()
    {
        if (enabledToMove) {
            timer += Time.deltaTime;
            transform.position = Vector3.Slerp(transform.position, targetPlayerPos, 1.5f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetPlayerRot, 1.5f * Time.deltaTime);
            if (timer > 6f)
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                enabledToMove = false;
                timer = 0;
            }
        }
    }
}

