using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipService : MonoBehaviour
{
    public string color;
    private float timer = 0;
    private float timerEnd = 4f;
    private bool enabledToMove = false;

    Vector3 targetPos;
    Quaternion targetRot;

    private Rigidbody rigidbody;

    public Transform chipStash;

    private void Awake()
    {
        color = gameObject.name.Substring(0, 3);
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }

    public void MoveToPlayer(PlayerService player)
    {
        switch (color)
        {
            case "WHI":
                MoveTo(player.whiteChipPlacingPoints[player.whiteChipNumber]);
                break;
            case "BLU":
                MoveTo(player.blueChipPlacingPoints[player.blueChipNumber]);
                break;
            case "GRE":
                MoveTo(player.greenChipPlacingPoints[player.greenChipNumber]);
                break;
            case "RED":
                MoveTo(player.redChipPlacingPoints[player.redChipNumber]);
                break;
            case "BLA":
                MoveTo(player.blackChipPlacingPoints[player.blackChipNumber]);
                break;
            case "GOL":
                MoveTo(player.goldChipPlacingPoints[player.goldChipNumber]);
                break;
            default:
                break;
        }

        enabledToMove = true;
    }

    public void MoveTo(Transform destination)
    {
        print("nem kértem el");
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        ChangeTransform(destination);
        enabledToMove = true;
    }

    public void ChangeTransform(Transform target)
    {
        targetPos = target.position;
        targetRot = target.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (enabledToMove && timer < timerEnd)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 3f * Time.deltaTime);
            if (timer > timerEnd)
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                enabledToMove = false;
                timer = 0;
            }
        }
    }
}
