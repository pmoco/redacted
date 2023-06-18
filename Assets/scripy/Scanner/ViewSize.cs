using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSize: MonoBehaviour
{


    public Vector3 newSize;
    public Vector3 newPosition; 


    void OnMouseDown() {

        Vector3 size = transform.localScale;
        Vector3 pos = transform.position;


        transform.localScale =newSize;
        transform.position = newPosition;

        newSize =size;
        newPosition= pos;


    }



}
