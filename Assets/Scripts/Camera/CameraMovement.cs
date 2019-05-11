using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public int OnTurnPlayerId = 0;

    public GameObject[] players;

    private Animator cameraAnimationAC { get; set; }

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

    }


    public void ChangeCamera(Transform transform)
    {
        targetCamPos = transform.position;
        targetCamRot = transform.rotation;
        cameraMoveEnabled = true;
    }

    

    public PlayerService GetOnTurnPlayer()
    {
        return players[OnTurnPlayerId].GetComponent<PlayerService>();
        
    }

    public void MoveToNextPlayer()
    {
        SetNextPlayerId();
        ChangeCamera(playerPovs[OnTurnPlayerId]);
        cameraMoveEnabled = true;
    }

    public void ChangeIsOutOfPov()
    {
        if (isOutOfPov)
        {
            isOutOfPov = false;
        }
        if (!isOutOfPov)
        {
            isOutOfPov = true;
        }
    }

    

    public void LookAtCards()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isOutOfPov)
        {
            ChangeCamera(CardsPov);
            //cameraMoveEnabled = true;
            isOutOfPov = true;
            
            
        }
        else if (Input.GetKeyDown(KeyCode.A) && isOutOfPov)
        {
            print("cards");
            ChangeCamera(playerPovs[OnTurnPlayerId]);
            //cameraMoveEnabled = true;
            isOutOfPov = false;
        }
    }

    public void LookAtNobles()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isOutOfPov)
        {
            ChangeCamera(NoblePov);
            //cameraMoveEnabled = true;
            isOutOfPov = true;

        }
        else if (Input.GetKeyDown(KeyCode.S) && isOutOfPov)
        {
            print("noble");
            ChangeCamera(playerPovs[OnTurnPlayerId]);
            //cameraMoveEnabled = true;
            isOutOfPov = false;
        }
    }

    public void LookAtChips()
    {
        if (Input.GetKeyDown(KeyCode.D) && !isOutOfPov)
        {
            ChangeCamera(ChipStashPov);
            //cameraMoveEnabled = true;
            isOutOfPov = true;

        }
        else if (Input.GetKeyDown(KeyCode.D) && isOutOfPov)
        {
            print("chips");
            ChangeCamera(playerPovs[OnTurnPlayerId]);
            //cameraMoveEnabled = true;
            isOutOfPov = false;
        }
    }

    public void LookAtOwn()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeCamera(playerPovs[OnTurnPlayerId]);
            //cameraMoveEnabled = true;
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
            //cameraMoveEnabled = true;
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
            //cameraMoveEnabled = true;
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
            //cameraMoveEnabled = true;
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
        cameraAnimationAC = gameObject.GetComponent<Animator>();
        //targetCamPos = playerPovs[OnTurnPlayerId].transform.position;
        //targetCamRot = playerPovs[OnTurnPlayerId].transform.rotation;
        //cameraMoveEnabled = true;
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
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetCamRot, smoothing * Time.deltaTime);

            if (timer > 6f)
            {
                timer = 0;
                cameraMoveEnabled = false;
            }
        }
    }
}
