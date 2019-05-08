using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public int OnTurnPlayerId = 0;

    public GameObject[] players;

    //public Transform target;

    private Animator cameraAnimationAC { get; set; }

    private float speed = 2.0f;

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

    public void MoveToNextPlayer()
    {
        cameraAnimationAC.SetTrigger("PlayerTurnEnd");
        SetNextPlayerId();

    }

    public PlayerService GetOnTurnPlayer()
    {
        return players[OnTurnPlayerId].GetComponent<PlayerService>();
    }

    public void LookAtCards()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)/* && (cameraAnimationAC.GetBool("LookAtCards")== false)*/)
        {
            cameraAnimationAC.SetBool("LookAtCards", true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            cameraAnimationAC.SetBool("LookAtCards", false);
        }
       


    }

    private void Awake()
    {
        cameraAnimationAC = gameObject.GetComponent<Animator>();
        
    }
    
    

    // Update is called once per frame
    void Update()
    {
        LookAtCards();

        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }*/
    }
}
