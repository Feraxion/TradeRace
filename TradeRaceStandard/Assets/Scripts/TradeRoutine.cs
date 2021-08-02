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
    private int turn = 0;
    
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
        playerHand.transform.DOMoveX(playerHand.transform.position.x + 1.15f, 1);
        
        yield return new WaitForSeconds(1f);
        
        obj.transform.SetParent(null);
        playerHand.transform.DOMoveX(playerHand.transform.position.x - 1.15f, 1);
        yield return new WaitForSeconds(1f);
        StartCoroutine(AITurn(toys[turn]));

    }
    
    IEnumerator AITurn(GameObject toy)
    {
        
        GameObject obj =Instantiate(toy,opponentHoldPos.transform.position,Quaternion.identity,opponentHoldPos.transform);
        opponentHand.transform.DOMoveX(opponentHand.transform.position.x - 0.5f, 1);
        
        yield return new WaitForSeconds(1f);
        
        obj.transform.SetParent(null);
        opponentHand.transform.DOMoveX(opponentHand.transform.position.x + 0.5f, 1);
        turn++;

    }
    
}
