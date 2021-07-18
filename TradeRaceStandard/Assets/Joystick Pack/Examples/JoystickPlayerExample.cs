using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public bool canMove;
    //public float h1, v1;

    private void Start()
    {
        gameObject.GetComponent<Animator>().SetInteger("Movement",1);
    }

    public void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            
            //Twist();
            float angle = Mathf.Atan2(variableJoystick.Horizontal, variableJoystick.Vertical) * Mathf.Rad2Deg; 
            this.transform.rotation =Quaternion.Euler(new Vector3(0, angle+180f, 0));

        }
        
        
        
        
    }
    
    /*void Twist ()
    {
        h1 = variableJoystick.Horizontal; // set as your inputs 
        v1 = variableJoystick.Vertical;
        if (h1 == 0f && v1 == 0f) { // this statement allows it to recenter once the inputs are at zero 
            Vector3 curRot = gameObject.transform.localEulerAngles; // the object you are rotating
            Vector3 homeRot;
            if (curRot.y > 180f) { // this section determines the direction it returns home 
                Debug.Log (curRot.y);
                homeRot = new Vector3 (0f,359.999f, 0f); //it doesnt return to perfect zero 
            } else {                                                                      // otherwise it rotates wrong direction 
                homeRot = Vector3.zero;
            }
            gameObject.transform.localEulerAngles = Vector3.Slerp (curRot, homeRot, Time.deltaTime*2);
        } else {
            gameObject.transform.localEulerAngles = new Vector3 (0f, Mathf.Atan2 (h1, v1) * 180 / Mathf.PI, 0f); // this does the actual rotaion according to inputs
        }
    }*/
}