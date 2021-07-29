using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TradeRoutine : MonoBehaviour
{
    
    public GameObject playerHand, opponentHand;
    public GameObject playerHoldPos, opponentHoldPos;

    public GameObject[] toys;
    public GameObject[] aiToys;
    public ValueCalculator valueCalc;
    
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
        
        obj.transform.SetParent(null);
        playerHand.transform.DOMoveZ(playerHand.transform.position.z - 2.6f, 1);
        
        yield return new WaitForSeconds(1f);
        StartCoroutine(AITurn(toys[0]));
        
    }
    
    IEnumerator AITurn(GameObject toy)
    {
        
        GameObject obj =Instantiate(toy,opponentHoldPos.transform.position,Quaternion.identity,opponentHoldPos.transform);
        opponentHand.transform.DOMoveZ(opponentHand.transform.position.z - 2.6f, 1);
        
        yield return new WaitForSeconds(1f);
        
        obj.transform.SetParent(null);
        opponentHand.transform.DOMoveZ(opponentHand.transform.position.z + 2.6f, 1);

    }
    
}
