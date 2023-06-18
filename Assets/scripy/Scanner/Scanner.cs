using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Scanner : MonoBehaviour
{


    Collider red; 
    Collider green;
    Collider blue;
    Collider photoCollider;

    CaseFile currentFile;


    public GameObject screen;

    private bool isCounting=false;
    private float timer=0f;

    private string color="";
    public int loadingTime = 30;

    public GameObject canvas;





    // Start is called before the first frame update
    void Start()
    {
        red = transform.Find("redButton").GetComponent<Collider>();
        blue = transform.Find("blueButton").GetComponent<Collider>();
        green = transform.Find("greenButton").GetComponent<Collider>();
        photoCollider = transform.Find("photo").GetComponent<Collider> ();
        currentFile = null;

        canvas = screen.transform.Find("imageOnScreen").Find("Canvas").gameObject;


    }

    // Update is called once per frame


    private void Update()
    {
        if (currentFile != null && !isCounting)
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
                        color = "red";
                        timer = 0f;
                        isCounting = true;
                        canvas.SetActive(true);
                    }
                    else if (hit.collider == blue)
                    {
                        color = "blue";
                        timer = 0f;
                        isCounting = true;
                        canvas.SetActive(true);

                        
                    }
                    else if (hit.collider == green)
                    {
                        color = "green";
                        timer = 0f;
                        isCounting = true;
                        canvas.SetActive(true);

                    }

                    Debug.Log(hit.collider.name);
                }
            }
        }
        else if (isCounting)
        {
            timer += Time.deltaTime;
            if (timer >= loadingTime)
            {
                switch (color)
                {
                    case "red":
                        RedProcess();

                        break;
                    case "blue":
                        BlueProcess();
                        break;
                    case "green":
                        GreenProcess();
                        break;
                }
                canvas.SetActive(false);
                isCounting = false;
            }

            Text percentage = screen.transform.Find("imageOnScreen").Find("Canvas").Find("percentage").gameObject.GetComponent<Text>();


            percentage.text = timer *100 / loadingTime +"%";


        }

    }







    public void SetImage (CaseFile cf)
    {
        Transform photo = transform.Find("photo");

        SpriteRenderer spriteRenderer = photo.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = cf.getPhoto("default");
        }
        currentFile = cf;
    }


    public void RedProcess()
    {
        if(currentFile != null)
        {
            GameObject computer  = GameObject.Find("computer");

            computer.transform.Find("imageOnScreen").GetComponent<SpriteRenderer>().sprite = currentFile.getPhoto("red");
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

            computer.transform.Find("imageOnScreen").GetComponent<SpriteRenderer>().sprite = currentFile.getPhoto("blue");
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

            computer.transform.Find("imageOnScreen").GetComponent<SpriteRenderer>().sprite = currentFile.getPhoto("green");
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
