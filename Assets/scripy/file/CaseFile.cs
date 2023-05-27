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

    public GameObject stamp;

    public Sprite fbUrgent;
    public Sprite fbSuper;
    public Sprite fbIgnore;


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
        Transform table = transform.Find("onTable");
        Transform deliver = transform.Find("Deliverspot");
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






    }


    public void DeliverCase()
    {
        GameObject feedback = transform.Find("feedBack").gameObject;
        SpriteRenderer sp = feedback.transform.Find("closeUp").GetComponent<SpriteRenderer>();



       switch (decision)
        {
            case Decision.Supernatural:
                sp.sprite = fbSuper;
                break;
            case Decision.Urgent:
                sp.sprite = fbUrgent;
                break;
            case Decision.Ignore:
                sp.sprite = fbIgnore;
                break;

        }

        feedback.SetActive(true);


    }




}
