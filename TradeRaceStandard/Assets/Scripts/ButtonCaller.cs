using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCaller : MonoBehaviour
{
    
    MeshRenderer myRenderer;
    public Material white, green;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressButton()
    {
        StartCoroutine(ColorChange());
    }

    IEnumerator ColorChange()
    {
        //myRenderer.material.color = Color.Lerp(Color.white,Color.green, 1f );
        //myRenderer.GetComponent<Renderer>().material.SetColor("MainColor", Color.black);
        
        myRenderer.material.Lerp(white,green,1f);
        //myRenderer.material.SetColor("MainColor",Color.Lerp(Color.white,Color.green, 1f ) );
        yield return new WaitForSeconds(0.4f);
        
        myRenderer.material.Lerp(green,white,1f);

        //myRenderer.material.color = Color.Lerp(Color.green,Color.white, 1f );
        //myRenderer.material.SetColor("MainColor",Color.Lerp(Color.green,Color.white, 1f ) );

    }
}
