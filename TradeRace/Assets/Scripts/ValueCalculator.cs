using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueCalculator : MonoBehaviour
{
    public int playerTradeValue,opponentTradeValue,valueRatio;

    public GameObject ratioBar;
    public float zRot;
    
    // Start is called before the first frame update
    void Start(){
    
        
        
    }
    float smooth = 5.0f;

    // Update is called once per frame
    void Update()
    {
        valueRatio = playerTradeValue - opponentTradeValue ;
        
        if (valueRatio > 0)
        {
            zRot = valueRatio * 15;
        }
        else
        {
            zRot = valueRatio * 15;

        }
        
        zRot = Mathf.Clamp(zRot, -80, 80);

        Quaternion target = Quaternion.Euler(0, 0, zRot);

        // Dampen towards the target rotation
        

        ratioBar.transform.rotation = Quaternion.Slerp(ratioBar.transform.rotation, target,  Time.deltaTime * smooth);

        Debug.Log(zRot);

        
    }
}
