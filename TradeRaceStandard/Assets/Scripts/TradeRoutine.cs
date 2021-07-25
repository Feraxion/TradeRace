using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TradeRoutine : MonoBehaviour
{
    
    public GameObject playerHand, opponentHand;
    public GameObject playerHoldPos;

    public GameObject[] toys;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void PlayerTurn(int toyArray)
    {
        
        StartCoroutine(PlayerHand(toys[toyArray]));
        
    }

    IEnumerator PlayerHand(GameObject toy)
    {
        
        GameObject obj =Instantiate(toy,playerHoldPos.transform.position,Quaternion.identity,playerHoldPos.transform);
        playerHand.transform.DOMoveZ(playerHand.transform.position.z + 2.6f, 1);
        yield return new WaitForSeconds(1f);
        //toy.transform.parent = null;
        obj.transform.SetParent(null);

        playerHand.transform.DOMoveZ(playerHand.transform.position.z - 2.6f, 1);

    }
    
}
