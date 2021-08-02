using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeObjectValue : MonoBehaviour
{
    public int ItemValue;
    public GameObject particleEffect;
    
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(particleEffect, gameObject.transform.position, Quaternion.identity,gameObject.transform);
            Debug.Log("asd");
        }    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    IEnumerator waitForSeconds()
    {
        yield return new WaitForSeconds(3f);
    }
}
