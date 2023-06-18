using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class DontDestroy : MonoBehaviour
{

    RoundManager rm;


    private void Awake()
    {
        GameObject perm = GameObject.Find("Permanent");

        if (perm == null)
        {
            DontDestroyOnLoad(this.gameObject);
            this.name= "Permanent";
        }
        else if (perm != gameObject) 
        {
            Destroy(gameObject);
        }

        


    }


}