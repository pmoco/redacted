using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickShow : MonoBehaviour
{


    public GameObject targetToShow; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        targetToShow.SetActive(true);

        gameObject.SetActive(false);

    }



}
