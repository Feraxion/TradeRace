using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CollectTradeObjects : MonoBehaviour
{

    public int collectedObjects;
    public Slider playerSlider;
    public Transform holdPosition;
    public Transform[] toySpots;
    public GameObject holdingGO;
    private int spotCount;
    public bool isHolding;
    public Rigidbody rb;
    public Animator playerAnimator;
    public DropOffPlacement dropOffScript;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        spotCount = 0;
        rb = gameObject.GetComponent<Rigidbody>();
        playerAnimator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (holdingGO != null && !holdingGO.Equals(null))
        {
            holdingGO.transform.position = holdPosition.position;
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (rb.velocity.magnitude < 0.3f && !isHolding)
            {
                playerAnimator.SetInteger("Movement",0);

            }
        
            if (rb.velocity.magnitude > 0.3f && !isHolding)
            {
                playerAnimator.SetInteger("Movement",1);

            }
        }
        else
        {
            if (!isHolding)
            {
                playerAnimator.SetInteger("Movement",1);

            }
        }
        
        
        
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("TradeObject") && !isHolding)
        {
            //Destroy(other.gameObject);
            playerAnimator.SetInteger("Movement",2);
            holdingGO = other.gameObject;
            holdingGO.GetComponent<Rigidbody>().useGravity = false;

            isHolding = true;
            holdingGO.GetComponent<BoxCollider>().enabled = false;

            holdingGO.gameObject.transform.SetParent(holdPosition);
            holdingGO.gameObject.transform.position = holdPosition.position;
            holdingGO.gameObject.transform.rotation = new Quaternion(0,0,0,0);
            //holdingGO.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            collectedObjects += holdingGO.GetComponent<TradeObjectValue>().ItemValue;
            StartCoroutine(DelaySlider(holdingGO.GetComponent<TradeObjectValue>().ItemValue));
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("DropOff"))
        {

            
            if (holdingGO)
            {
                
                switch (other.GetComponent<DropOffInfo>().color)
                {
                    case 1:
                        
                        if (gameObject.CompareTag("Player"))
                        {
                            dropOffScript.AddStair(2);
                            StartCoroutine(wait(0.1f,0));
                        }
                        

                        return;
                
                    case 2:
                        if (gameObject.CompareTag("GreenChar"))
                        {
                            dropOffScript.AddStair(3);
                            StartCoroutine(wait(0.1f,1));

                        }

                        return;
                
                    case 3:
                        if (gameObject.CompareTag("BlueChar"))
                        {
                            dropOffScript.AddStair(1);
                            StartCoroutine(wait(0.1f,2));

                        }
                        return;
                
                }

            }
            


        }
    }
    
    IEnumerator wait(float value,int color)
    {
        yield return new WaitForSeconds(value);
        //toySpots[spotCount];
        holdingGO.transform.SetParent(null);
        holdingGO.transform.DOMove(toySpots[color].transform.position, 1);

        //holdingGO.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        holdingGO.GetComponent<Rigidbody>().useGravity = true;
        holdingGO.GetComponent<BoxCollider>().enabled = true;
        holdingGO.gameObject.tag = "Pushable";
        holdingGO = null;
        playerAnimator.SetInteger("Movement",1);
        isHolding = false;


    }
    
    IEnumerator DelaySlider(int value)
    {

        for (int j = 0; j < value * 100; j++)
        {

            playerSlider.value += 0.01f;
            yield return new WaitForSeconds(0.01f);

        }
        
       
    }
    
}
