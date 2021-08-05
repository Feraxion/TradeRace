using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdCameraMovement : MonoBehaviour
{
    public GameObject adCam;
    public GameObject playerCam;
    public GameObject ai1, ai2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ai1.GetComponent<NavMeshAgent>().enabled = false;
        ai2.GetComponent<NavMeshAgent>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerCam.gameObject.SetActive(true);


            StartCoroutine(WaitFor());
        }  
    }

    IEnumerator WaitFor()
    {                                                                                                                                                      
        yield return new WaitForSeconds(2.8f);
        ai1.GetComponent<NavMeshAgent>().enabled = true;
        ai2.GetComponent<NavMeshAgent>().enabled = true;
        
    }
}
