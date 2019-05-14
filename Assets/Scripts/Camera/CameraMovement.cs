using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool isLastRound = false;
    public int lastCounter = 4;

    public int OnTurnPlayerId = 0;

    public List<GameObject> players;

    private float smoothing = 1.5f;

    public Transform[] playerPovs;

    

    public Transform CardsPov;
    public Transform NoblePov;
    public Transform ChipStashPov;
    
    Vector3 targetCamPos;
    Quaternion targetCamRot;

    public bool cameraMoveEnabled = false;

    private bool isOutOfPov = false;
    private float timer;

    public void SetNextPlayerId()
    {
        if (OnTurnPlayerId != 3)
        {
            OnTurnPlayerId++;
        }
        else
        {
            OnTurnPlayerId = 0;
        }
        timer = 0;

    }


    public void ChangeCamera(Transform transform)
    {
        targetCamPos = transform.position;
        targetCamRot = transform.rotation;
        timer = 0;
        cameraMoveEnabled = true;
    }

    

    public PlayerService GetOnTurnPlayer()
    {
        return players[OnTurnPlayerId].GetComponent<PlayerService>();
    }

    public void MoveToNextPlayer()
    {
        if (GetOnTurnPlayer().points >= 15)
        {
            isLastRound = true;
        }

        if (isLastRound && lastCounter != 0)
        {
            lastCounter--;
        }

        if (lastCounter != 0)
        {
        SetNextPlayerId();
        ChangeCamera(playerPovs[OnTurnPlayerId]);
        }
    }

    public void LookAtCards()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeCamera(CardsPov);
            isOutOfPov = true;
        }
    }

    public void LookAtNobles()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeCamera(NoblePov);
            isOutOfPov = true;
        }
    }

    public void LookAtChips()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeCamera(ChipStashPov);
            isOutOfPov = true;
        }
    }

    public void LookAtOwn()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeCamera(playerPovs[OnTurnPlayerId]);
            isOutOfPov = false;
        }
    }

    public void LookAtOthers()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (OnTurnPlayerId)
            {
                case 0:
                    ChangeCamera(playerPovs[2]);
                    break;
                case 1:
                    ChangeCamera(playerPovs[3]);
                    break;
                case 2:
                    ChangeCamera(playerPovs[0]);
                    break;
                case 3:
                    ChangeCamera(playerPovs[1]);
                    break;
            }
            isOutOfPov = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (OnTurnPlayerId)
            {
                case 0:
                    ChangeCamera(playerPovs[1]);
                    break;
                case 1:
                    ChangeCamera(playerPovs[2]);
                    break;
                case 2:
                    ChangeCamera(playerPovs[3]);
                    break;
                case 3:
                    ChangeCamera(playerPovs[0]);
                    break;
            }
            isOutOfPov = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (OnTurnPlayerId)
            {
                case 0:
                    ChangeCamera(playerPovs[3]);
                    break;
                case 1:
                    ChangeCamera(playerPovs[0]);
                    break;
                case 2:
                    ChangeCamera(playerPovs[1]);
                    break;
                case 3:
                    ChangeCamera(playerPovs[2]);
                    break;
            }
            isOutOfPov = true;
        }
    }

    /*public void MoveToNextPlayer()
    {
        cameraAnimationAC.SetTrigger("PlayerTurnEnd");
        SetNextPlayerId();
    }

    /*public void LookAtCards()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                cameraAnimationAC.SetBool("LookAtCards", true);
            }
            //else
            if (Input.GetKeyUp(KeyCode.A))
            {
                cameraAnimationAC.SetBool("LookAtCards", false);
            }
        }

    public void LookAtNobles()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            cameraAnimationAC.SetBool("LookAtNobles", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            cameraAnimationAC.SetBool("LookAtNobles", false);
        }
    }

    public void LookAtChips()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            cameraAnimationAC.SetBool("LookAtChips", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            cameraAnimationAC.SetBool("LookAtChips", false);
        }
    }

    public void LookAtOwn()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cameraAnimationAC.SetBool("LookAtOwn", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            cameraAnimationAC.SetBool("LookAtOwn", false);
        }
    }

    public void LookAtOthers()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cameraAnimationAC.SetBool("LookAtFront", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            cameraAnimationAC.SetBool("LookAtFront", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cameraAnimationAC.SetBool("LookAtRight", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            cameraAnimationAC.SetBool("LookAtRight", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cameraAnimationAC.SetBool("LookAtLeft", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            cameraAnimationAC.SetBool("LookAtLeft", false);
        }
    }*/

    private void Awake()
    {

    }
    
    

    // Update is called once per frame
    void Update()
    {
        LookAtCards();

        LookAtNobles();

        LookAtChips();

        LookAtOwn();

        LookAtOthers();

        if (cameraMoveEnabled)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Slerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetCamRot, smoothing * Time.deltaTime);

            if (timer > 6f)
            {
                timer = 0;
                cameraMoveEnabled = false;
            }
        }
    }
}
