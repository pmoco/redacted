using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{


    Collider red; 
    Collider green;
    Collider blue;
    Collider photoCollider;

    CaseFile currentFile;



    // Start is called before the first frame update
    void Start()
    {
        red = transform.Find("redButton").GetComponent<Collider>();
        blue = transform.Find("blueButton").GetComponent<Collider>();
        green = transform.Find("greenButton").GetComponent<Collider>();
        photoCollider = transform.Find("photo").GetComponent<Collider> ();
        currentFile = null;
    }

    // Update is called once per frame


    private void Update()
    {
        if (currentFile != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider == photoCollider)
                    {
                        Debug.Log("scanner");


                        Transform photo = transform.Find("photo");

                        SpriteRenderer spriteRenderer = photo.GetComponent<SpriteRenderer>();

                        if (spriteRenderer != null)
                        {
                            spriteRenderer.sprite = null;
                        }
                        currentFile = null;
                    }

                    if (hit.collider == red)
                    {
                        Debug.Log("red");
                        RedProcess();
                    }
                    else if (hit.collider == blue)
                    {
                        BlueProcess();
                    }
                    else if (hit.collider == green)
                    {
                        GreenProcess();
                    }

                    Debug.Log(hit.collider.name);
                }
            }
        }
    }







    public void SetImage (CaseFile cf)
    {
        Transform photo = transform.Find("photo");

        SpriteRenderer spriteRenderer = photo.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = cf.photo;
        }
        currentFile = cf;
    }


    public void RedProcess()
    {
        if(currentFile != null)
        {
            GameObject computer  = GameObject.Find("computer");

            computer.transform.Find("imageOnScreen").GetComponent<SpriteRenderer>().sprite = currentFile.png_red;
            computer.transform.Find("imageOnScreen").gameObject.SetActive(true);

            Transform photo = transform.Find("photo");

            SpriteRenderer spriteRenderer = photo.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = null;
            }
            currentFile = null;
        }
    }

    public void BlueProcess()
    {
        if (currentFile != null)
        {
            GameObject computer = GameObject.Find("computer");

            computer.transform.Find("imageOnScreen").GetComponent<SpriteRenderer>().sprite = currentFile.png_blue;
            computer.transform.Find("imageOnScreen").gameObject.SetActive(true);

            Transform photo = transform.Find("photo");

            SpriteRenderer spriteRenderer = photo.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = null;
            }
            currentFile = null;

        }
    }

    public void GreenProcess()
    {
        if (currentFile != null)
        {
            GameObject computer = GameObject.Find("computer");

            computer.transform.Find("imageOnScreen").GetComponent<SpriteRenderer>().sprite = currentFile.png_green;
            computer.transform.Find("imageOnScreen").gameObject.SetActive(true);

            Transform photo = transform.Find("photo");

            SpriteRenderer spriteRenderer = photo.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = null;
            }
            currentFile = null;
        }
    }





}
