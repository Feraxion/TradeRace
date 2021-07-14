using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueSender : MonoBehaviour
{
    public ValueCalculator valueCalc;
    
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
            if (gameObject.name.Contains("Player"))
            {
                valueCalc.playerTradeValue += other.gameObject.GetComponent<TradeObjectValue>().ItemValue;

            }
            else
            {
                valueCalc.opponentTradeValue += other.gameObject.GetComponent<TradeObjectValue>().ItemValue;

            }
        }
    }
}
