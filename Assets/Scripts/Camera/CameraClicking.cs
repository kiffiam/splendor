using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClicking : MonoBehaviour
{

    int cardMask;
    int chipMask;
    float camRayLength = 100f;
    CameraMovement cameraMovement;

    private void Awake()
    {
        cardMask = LayerMask.GetMask("cardMask");
        chipMask = LayerMask.GetMask("chipMask");
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
            }
        }
    }

    public void OnCardRightClick()
    {
        //jobb klikkel foglalás
        /*if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit cardHit;

            if (Physics.Raycast(ray, out cardHit, camRayLength, cardMask))
            {
                
            }
        }*/
    }

    public void OnChipLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit chipHit;

            if (Physics.Raycast(ray, out chipHit, camRayLength, chipMask))
            {
                chipHit.transform.GetComponent<ChipStashService>().OnLeftClick();
            }
        }
    }

    public void OnChipRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit chipHit;

            if (Physics.Raycast(ray, out chipHit, camRayLength, chipMask))
            {
                chipHit.transform.GetComponent<ChipStashService>().OnRigthClick();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnCardLeftClick();

        //OnCardRightClick();

        //OnChipLeftClick();

        //OnChipRightClick();
    }
}
