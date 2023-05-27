using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeFile : MonoBehaviour
{
    // Start is called before the first frame update
    CaseFile cf;

    Transform table; 
    Transform deliver; 


    // Start is called before the first frame update
    void Start()
    {


        cf = transform.parent.parent.GetComponent<CaseFile>();
        table = cf.transform.Find("onTable"); 
        deliver = cf.transform.Find("Deliverspot");
    }

    private void OnMouseDown()
    {
        
        table.gameObject.SetActive(false);
        deliver.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        cf.DeliverCase();

    }
}
