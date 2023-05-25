using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSize: MonoBehaviour
{


    public Vector3 newSize;
    public Vector3 newPosition; 


    void OnMouseDown() {
        
        Transform x = transform; 


        transform.localScale =newSize;
        transform.position = newPosition;

        newSize = x.position;
        newPosition= x.position;


    }



}
