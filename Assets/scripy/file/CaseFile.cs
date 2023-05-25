using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CaseFile : MonoBehaviour
{
    // Start is called before the first frame update
   public  enum Decision
    {
        NULL,
        Urgent,
        Supernatural,
        Ignore
    }

    public int id;
    public Sprite sprite;
    public Sprite spriteOpen;

    public Sprite photo;
    public Sprite png_red;
    public Sprite png_blue;
    public Sprite png_green;

    public Decision decision;

    public GameObject fbUrgent;
    public GameObject fbSuper;
    public GameObject fbIgnore;


    void Start()
    {
        loadVariables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadVariables()
    {
        Transform table= transform.Find("onTable");
        Transform open = transform.Find("Open");
        Transform file = open.transform.Find("File");
        Transform png = open.transform.Find("photo");


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






    }




}
