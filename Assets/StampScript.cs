using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class StampScript : MonoBehaviour
{
    CaseFile cf;

    public CaseFile.Decision value;
    SpriteRenderer sp;
    public Sprite mark; 
    
    // Start is called before the first frame update
    void Start()
    {
       cf = transform.parent.parent.parent.GetComponent<CaseFile>();
       sp = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
       Transform deliver = cf.transform.Find("Open").transform.Find("Deliver");
        
        cf.decision = value;
        cf.stamp.SetActive(true);
        cf.stamp.GetComponent<SpriteRenderer>().sprite = mark;

        deliver.gameObject.SetActive(true);



    }

    private void OnMouseOver()
    {
        



        sp.sortingOrder= 10;


    }

    private void OnMouseExit()
    {


        sp.sortingOrder = 3;

    }

}
