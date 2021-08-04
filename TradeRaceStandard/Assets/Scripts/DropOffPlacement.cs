using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DropOffPlacement : MonoBehaviour
{

    public GameObject[] blueStairs;
    public GameObject[] redStairs;
    public GameObject[] greenStairs;

    public GameObject red1, red2, blue1, blue2, green1, green2, playerBridgeWall;

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
        
       
    }

    public void AddStair(int color)
    {
        switch (color)
        {
            case 1:
                StartCoroutine(AddStairs(blueStairs[blue]));
                
                StartCoroutine(RotateLeftGO(blue1));
                StartCoroutine(RotateRightGO(blue2));
                blue++;
                
                return;
            case 2:

                StartCoroutine(AddStairs(redStairs[red]));


                StartCoroutine(RotateLeftGO(red1));
                StartCoroutine(RotateRightGO(red2));
                red++;

                if (red>4)
                {
                    playerBridgeWall.SetActive(false);
                }
                
                return;
            case 3:
                
                StartCoroutine(AddStairs(greenStairs[green]));


                StartCoroutine(RotateLeftGO(green1));
                StartCoroutine(RotateRightGO(green2));
                green++;
                
                
                return;
                
        }
    }
    
    IEnumerator AddStairs(GameObject color)
    {
        yield return new WaitForSeconds(1f);
        
        color.SetActive(true);
        color.transform.DOScale(new Vector3(34.57f, 92f, 7.96f),1);

        
    }

    IEnumerator RotateLeftGO(GameObject leftGO)
    {
        yield return new WaitForSeconds(1f);

        //leftGO.transform.DORotate(openLeftPos,1);
        leftGO.transform.DOLocalRotateQuaternion(Quaternion.Euler(openLeftPos),1);

        yield return new WaitForSeconds(1.4f);
        
        //leftGO.transform.DORotate(closedPos,1);
        leftGO.transform.DOLocalRotateQuaternion(Quaternion.Euler(closedPos),1);

        
    }
    
    IEnumerator RotateRightGO(GameObject rightGO)
    {
        yield return new WaitForSeconds(1f);

        rightGO.transform.DOLocalRotate(openRightPos,1,0);
        

        yield return new WaitForSeconds(1.4f);
        
        rightGO.transform.DOLocalRotate(closedPos,1,0);
        
    }
}
