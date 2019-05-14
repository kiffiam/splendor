using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClicking : MonoBehaviour
{

    int cardMask;
    int chipStashMask;
    float camRayLength = 100f;
    CameraMovement cameraMovement;
    ChipTextManager chipTextManager;

    private void Awake()
    {
        chipTextManager = GetComponent<ChipTextManager>();
        cardMask = LayerMask.GetMask("cardMask");
        chipStashMask = LayerMask.GetMask("chipStashMask");
        cameraMovement = gameObject.GetComponent<CameraMovement>();
    }

    //kártyára leftclick
    public void OnCardLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit cardHit;

            if (Physics.Raycast(ray, out cardHit, camRayLength, cardMask))
            {
                cardHit.transform.GetComponent<CardStats>().OnLeftClick(cameraMovement.GetOnTurnPlayer());
                //chipTextManager.UpdatePlayer(cameraMovement.GetOnTurnPlayer());
            }
        }
    }

    public void OnCardRightClick()
    {
        //jobb klikkel foglalás, owner beállitás, kártya odakerülés, egy arany zseton elvétel
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit cardHit;

            if (Physics.Raycast(ray, out cardHit, camRayLength, cardMask))
            {
                cardHit.transform.GetComponent<CardStats>().OnRightClick(cameraMovement.GetOnTurnPlayer());
                //chipTextManager.UpdatePlayer(cameraMovement.GetOnTurnPlayer());
            }
        }
    }

    public void OnChipLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit chipHit;

            if (Physics.Raycast(ray, out chipHit, camRayLength, chipStashMask))
            {
                if (!cameraMovement.GetOnTurnPlayer().chipsTaken.Contains(chipHit.transform.GetComponent<ChipStashService>().stashColor))
                {
                    chipHit.transform.GetComponent<ChipStashService>().OnLeftClick(cameraMovement.GetOnTurnPlayer());
                    //chipTextManager.UpdatePlayer(cameraMovement.GetOnTurnPlayer());
                }
                else
                {
                    print("Already took one from this color!");
                }

            }
        }
    }

    public void OnChipRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit chipHit;

            if (Physics.Raycast(ray, out chipHit, camRayLength, chipStashMask))
            {
                if (chipHit.transform.GetComponent<ChipStashService>().stashColor != "GOL")
                {
                    chipHit.transform.GetComponent<ChipStashService>().OnRigthClick(cameraMovement.GetOnTurnPlayer());
                    //chipTextManager.UpdatePlayer(cameraMovement.GetOnTurnPlayer());
                }
                else
                {
                    print("Can't take two from the Gold chips! Book a card with right click to get one!");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMovement.lastCounter != 0)
        {
        OnCardLeftClick();

        OnCardRightClick();

        OnChipLeftClick();

        OnChipRightClick();
        }
       
    }
}
