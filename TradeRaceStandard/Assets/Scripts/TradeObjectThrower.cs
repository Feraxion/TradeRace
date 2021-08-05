using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeObjectThrower : MonoBehaviour
{
    //public GameObject objectToThrow;

    public int xForce,yForce,zForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void ThrowObject(GameObject objectToThrow)
    {
        GameObject throwing = Instantiate(objectToThrow, gameObject.transform.position, Quaternion.Euler(-90,0,0),gameObject.transform);
        throwing.transform.GetComponent<Rigidbody>().AddForce(new Vector3(xForce,yForce,zForce));
        zForce += 160;
    }
    
}
