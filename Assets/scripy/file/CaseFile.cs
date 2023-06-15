using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

[System.Serializable]
public class CaseFile : MonoBehaviour
{
    [System.Serializable]
    public enum Decision
    {
        NULL,
        Urgent,
        Supernatural,
        Ignore
    }

    public string id;
    public Sprite sprite;
    public Sprite spriteOpen;
    public string report;

    public Decision decision;

    public GameObject stamp;

    public string fb_sup;
    public string fb_close;
    public string fb_dispatch;

    public Sprite photo;
    public Sprite png_red;
    public  Sprite png_blue;
    public Sprite png_green;
    public Sprite reading;



    void Start()
    {


        loadVariables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadExternalCaseFile(CaseFile cf)
    {
        // Set the properties of the current CaseFile object using the properties of the external CaseFile

        id = cf.id;
        report = cf.report;
        reading = cf.reading;
        png_red= cf.png_red;
        png_blue= cf.png_blue;
        png_green = cf.png_green;
        photo= cf.photo;

        fb_sup = cf.fb_sup;
        fb_close = cf.fb_close;
        fb_dispatch = cf.fb_dispatch;

        // Optionally, you can also call the Load() function to load the sprites using the specified paths
        loadVariables();
    }



    private void loadVariables()
    {
        Transform table = transform.Find("onTable");
        Transform deliver = transform.Find("Deliverspot");
        Transform open = transform.Find("Open");
        Transform file = open.transform.Find("File");
        Transform png = open.transform.Find("photo");

        Transform text = file.transform.Find("Canvas").transform.Find("Text");




        // Check if the child object is found
        if (table != null)
        {
            SpriteRenderer spriteRenderer = table.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprite;
            }
        }
        else
        {
            Debug.LogError("Child object named 'onTable' not found!");
        }

        if (deliver != null)
        {
            SpriteRenderer spriteRenderer = deliver.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprite;
            }
        }

        else
        {
            Debug.LogError("Child object named 'Deliverspot' not found!");
        }

        // Check if the child object is found
        if (file != null)
        {
            SpriteRenderer spriteRenderer = file.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = spriteOpen;
            }
        }
        else
        {
            Debug.LogError("Child object named 'File' not found!");
        }

        if (png != null)
        {
            SpriteRenderer spriteRenderer = png.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = photo;
            }
        }
        else
        {
            Debug.LogError("Child object named 'photo' not found!");
        }

        if (text != null)
        {
            Debug.Log("slçdkfhasjdbg");
            Debug.Log(text);

            Text t = text.GetComponent<Text>();

            t.text = report;

        }






    }


    public void DeliverCase()
    {
        GameObject feedback = transform.Find("feedBack").gameObject;
        SpriteRenderer sp = feedback.transform.Find("closeUp").GetComponent<SpriteRenderer>();



       //switch (decision)
       // {
       //     case Decision.Supernatural:
       //         sp.sprite = fbSuper;
       //         break;
       //     case Decision.Urgent:
       //         sp.sprite = fbUrgent;
       //         break;
       //     case Decision.Ignore:
       //         sp.sprite = fbIgnore;
       //         break;

       // }

        feedback.SetActive(true);


    }

    public Sprite getPhoto(string version)
    {
        switch (version)
        {
            case "green":
                return png_green;


            case "blue":
                return png_blue;


            case "red":
                return png_red;


            case "default":
                return photo;
            default:
                return null;

        }




    }




    }
