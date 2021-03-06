using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    private void Start()
    {
        gameObject.GetComponent<Animator>().SetInteger("Movement",1);
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        
        float angle = Mathf.Atan2(variableJoystick.Horizontal, variableJoystick.Vertical) * Mathf.Rad2Deg; 
        this.transform.rotation =Quaternion.Euler(new Vector3(0, angle+180f, 0));
        
        
    }
}