using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectTradeObjects : MonoBehaviour
{

    public int collectedObjects;
    public Slider playerSlider;
    public Transform holdPosition;

    public GameObject holdingGO;

    public bool isHolding;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingGO != null && !holdingGO.Equals(null))
        {
            holdingGO.transform.position = holdPosition.position;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("TradeObject") && !isHolding)
        {
            //Destroy(other.gameObject);
            gameObject.GetComponent<Animator>().SetInteger("Movement",2);
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
                StartCoroutine(wait(0.5f));
                

            }
            


        }
    }
    
    IEnumerator wait(float value)
    {
        yield return new WaitForSeconds(value);

        holdingGO.transform.parent = null;
        //holdingGO.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        holdingGO.GetComponent<Rigidbody>().useGravity = true;
        holdingGO.GetComponent<BoxCollider>().enabled = true;
        holdingGO.gameObject.tag = "Pushable";
        holdingGO = null;
        gameObject.GetComponent<Animator>().SetInteger("Movement",1);
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
