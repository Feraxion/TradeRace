﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTeleport : MonoBehaviour
{
    public GameObject tradeCanvas;

    public GameObject gameplayCamera;

    public GameObject tradeCamera;
    public GameObject player;
    public GameObject playerControl;
    public Transform tradePosition;
    public GameObject sliderGO;
    public JoystickPlayerExample joystick;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<CollectTradeObjects>().collectedObjects >= 5) ;
            {
                player.GetComponent<Animator>().SetInteger("Movement",0);
                joystick.canMove = false;
                playerControl.SetActive(false);
                tradeCamera.SetActive(true);
                gameplayCamera.SetActive(false);
                sliderGO.SetActive(false);
                player.transform.position = tradePosition.position;
                //tradeCanvas.SetActive(true);
            }
            
        }
    }
    
    
}