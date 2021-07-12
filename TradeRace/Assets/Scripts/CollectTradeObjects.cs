using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectTradeObjects : MonoBehaviour
{

    public int collectedObjects;
    public Slider playerSlider;
    
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
        if (other.gameObject.CompareTag("TradeObject"))
        {
            Destroy(other.gameObject);
            collectedObjects += other.GetComponent<TradeObjectValue>().ItemValue;
            StartCoroutine(DelaySlider(other.GetComponent<TradeObjectValue>().ItemValue));
        }
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
