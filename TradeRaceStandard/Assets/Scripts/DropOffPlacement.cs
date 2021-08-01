using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DropOffPlacement : MonoBehaviour
{

    public GameObject[] blueStairs;
    public GameObject[] redStairs;
    public GameObject[] greenStairs;

    public GameObject red1, red2, blue1, blue2, green1, green2;

    private Vector3 openLeftPos,openRightPos, closedPos;


    private int red,blue,green;
    
    void Start()
    {
        openLeftPos = new Vector3(180, 0, 0);
        closedPos = new Vector3(270f, 0, 0);
        openRightPos = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            AddStair(1);
            AddStair(2);
            AddStair(3);
        }
    }

    public void AddStair(int color)
    {
        switch (color)
        {
            case 1:
                
                blueStairs[blue].SetActive(true);
                blueStairs[blue].transform.DOScale(new Vector3(34.57f, 100f, 7.96f),1);
                StartCoroutine(RotateLeftGO(blue1));
                StartCoroutine(RotateRightGO(blue2));
                blue++;
                
                return;
            case 2:

                redStairs[red].SetActive(true);
                redStairs[red].transform.DOScale(new Vector3(34.57f, 100f, 7.96f),1);

                StartCoroutine(RotateLeftGO(red1));
                StartCoroutine(RotateRightGO(red2));
                red++;
                
                return;
            case 3:
                
                greenStairs[green].SetActive(true);
                greenStairs[green].transform.DOScale(new Vector3(34.57f, 100f, 7.96f),1);

                StartCoroutine(RotateLeftGO(green1));
                StartCoroutine(RotateRightGO(green2));
                green++;
                
                
                return;
                
        }
    }

    IEnumerator RotateLeftGO(GameObject leftGO)
    {
        
        //leftGO.transform.DORotate(openLeftPos,1);
        leftGO.transform.DORotateQuaternion(Quaternion.Euler(openLeftPos),1);

        yield return new WaitForSeconds(3f);
        
        //leftGO.transform.DORotate(closedPos,1);
        leftGO.transform.DORotateQuaternion(Quaternion.Euler(closedPos),1);

        
    }
    
    IEnumerator RotateRightGO(GameObject rightGO)
    {
        
        rightGO.transform.DORotate(openRightPos,1,0);
        

        yield return new WaitForSeconds(3f);
        
        rightGO.transform.DORotate(closedPos,1,0);
        
    }
}
