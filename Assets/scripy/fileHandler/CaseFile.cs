using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using static CaseFile;


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

    public enum Value
    {
        FAILED,
        WRONG,
        INCORRECT,
        CORRECT
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
    public Sprite annex;

    public GameObject fileHolder;

    





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
        fileHolder = cf.fileHolder;
        annex =cf.annex;



        decisionDictionary = cf.decisionDictionary;









        // Optionally, you can also call the Load() function to load the sprites using the specified paths
        loadVariables();
    }



    private void loadVariables()
    {
        Transform table = transform.Find("onTable");
        
        Transform open = transform.Find("Open");
        Transform file = open.transform.Find("File");
         
        if ( annex !=  null )
        {
            Transform mark =file.transform.Find("Mark");
            SpriteRenderer spriteRenderer = mark.GetComponent<SpriteRenderer>();


            spriteRenderer.sprite = annex;
        }


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

            TMP_Text t = text.GetComponent<TMP_Text>();

            t.text = report;

        }






    }


    public void DeliverCase()
    {
        FileHolder fh = fileHolder.GetComponent<FileHolder>();
        fh.addCaseFile(gameObject.GetComponent<CaseFile>());

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

        //feedback.SetActive(true);


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


    private Dictionary<Decision, Value> decisionDictionary = new Dictionary<Decision, Value>();


    public void BuildDictionary(string format)
    {
        decisionDictionary.Clear();

        // Split the format string into individual assignments
        string[] assignments = format.Split(',');

        // Process each assignment and add it to the dictionary
        foreach (string assignment in assignments)
        {
            // Split the assignment into key and value
            string[] parts = assignment.Trim().Split('=');

            if (parts.Length == 2)
            {
                // Trim the key and value strings
                string keyString = parts[0].Trim();
                string valueString = parts[1].Trim();

                // Parse the key and value enums
                Decision key;
                Value value;

                if (Enum.TryParse(keyString, out key) && Enum.TryParse(valueString, out value))
                {
                    // Add the key-value pair to the dictionary
                    decisionDictionary[key] = value;
                }
                else
                {
                    Debug.LogWarning($"Failed to parse assignment: {assignment}");
                }
            }
            else
            {
                Debug.LogWarning($"Invalid assignment format: {assignment}");
            }
        }

        // Add NULL key with the value of FAILED
        decisionDictionary[Decision.NULL] = Value.FAILED;
    }

    public string Solution()
    {
        if (decisionDictionary.ContainsKey(decision))
        {
            return decisionDictionary[decision].ToString();
        }
        else
        {
            Debug.LogWarning($"No solution found for decision: {decision}");
            return Value.FAILED.ToString();
        }
    }















}
