using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseFile : MonoBehaviour
{
    // Start is called before the first frame update
   public  enum Decision
    {
        Urgent,
        Supernatural,
        Ignore
    }

    public int id;
    public GameObject sprite;
    public GameObject spriteOpen;

    public GameObject photo;
    public GameObject png_red;
    public GameObject png_blue;
    public GameObject png_green;

    public Decision decision;

    public GameObject fbUrgent;
    public GameObject fbSuper;
    public GameObject fbIgnore;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
