using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public IKSolver iksolver;

    public GameObject yes, no, more, standby, middle;

    public ButtonCaller yesButton, noButton, moreButton;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetInteger("Movement",0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            HandToNo();
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            HandToYes();
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            HandToMore();
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            HandToTrade();
        }
    }

    public void HandToYes()
    {
        iksolver.target = yes.transform;
        iksolver.enabled = true;
        StartCoroutine(ColorButton(yesButton));

        StartCoroutine(resetPos());
    }
    
    public void HandToNo()
    {
        iksolver.target = no.transform;
        iksolver.enabled = true;
        StartCoroutine(ColorButton(noButton));

        StartCoroutine(resetPos());
    }
    
    public void HandToMore()
    {
        iksolver.target = more.transform;
        iksolver.enabled = true;
        StartCoroutine(ColorButton(moreButton));

        StartCoroutine(resetPos());
        
    }
    
    public void HandToTrade()
    {
        iksolver.target = middle.transform;
        iksolver.enabled = true;

        StartCoroutine(resetPos());
        
    }
    
    IEnumerator ColorButton(ButtonCaller button)
    {
        yield return new WaitForSeconds(0.2f);

        button.PressButton();

    }

    IEnumerator resetPos()
    {
        
        yield return new WaitForSeconds(0.5f);

        iksolver.target = standby.transform;
        yield return new WaitForSeconds(1f);

        iksolver.enabled = false;
    }
    
}
