using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update


    public TMP_Text title; 
    public TMP_Text subtitle;
    public GameObject line;
    public GameObject Logo;

    public GameObject Sign;

    public float timer;


    public float titleTime;
    public float subtitleTime;
    public float lineTime;
    public float signTime;


    public string titleText;
    public string subtitleText;

    public string redactSubtitle;




    public string state;

    public int  lIndex;



    public Texture2D clickCursor; // Reference to the click cursor texture
    public Vector2 cursorHotspot;









    void Start()
    {
        timer = 0f;

        state = "title";
        lIndex = 0;
        title.text = "";
        subtitle.text = "";

        line.GetComponent<RectTransform>().localScale = Vector3.zero;


    }

    // Update is called once per frame
    void Update()
    {
        if (state != "timerStop")
        {
            timer += Time.deltaTime;

            switch (state)
            {
                case "title":
                    if (timer < titleTime)
                    {
                        lIndex = (int)(timer * titleText.Length / titleTime);

                        title.text = titleText.Substring(0, lIndex);
                    }
                    else
                    {
                        title.text = titleText;
                        state = "line";
                        timer = 0f;
                    }
                    break;

                case "subtitle":

                    if (timer < subtitleTime)
                    {
                        lIndex = (int)(timer * subtitleText.Length / subtitleTime);

                        subtitle.text = subtitleText.Substring(0, lIndex);
                    }
                    else
                    {
                        subtitle.text = subtitleText;
                        state = "logo";
                        timer = 0f;
                    }
                    break;
                case "line":
                    line.SetActive(true);
                    if (timer < lineTime)
                    {
                        Vector3 v = new Vector3(timer / lineTime, 1, 1);

                        line.GetComponent<RectTransform>().localScale = v;

                    }
                    else
                    {
                        line.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                        state = "subtitle";
                        timer = 0f;
                    }


                    break;
                case "logo":
                    if (timer >= signTime / 2)
                    {
                        Logo.SetActive(true);

                    }
                    if (timer >= signTime)
                    {
                        timer = 0f;
                        state = "redact";
                    }

                    break;
                case "redact":
                    if (timer < titleTime)
                    {
                        lIndex = (int)(timer * redactSubtitle.Length / titleTime);

                        subtitle.text = "<mark=#000000>" + subtitleText.Substring(0, lIndex) + "</mark>" + subtitleText.Substring(lIndex, subtitleText.Length - lIndex);


                    }
                    else
                    {

                        subtitle.text = "<mark=#000000>" + subtitleText.Substring(0, redactSubtitle.Length) + "</mark>" + subtitleText.Substring(redactSubtitle.Length, subtitleText.Length - redactSubtitle.Length);
                        state = "Button";
                    }
                    break;
                case "Button":
                    if (timer >= signTime / 2)
                    {
                        Sign.SetActive(true);
                        timer = 0f;
                        state = "timerStop";
                    }
                    break;
                case "Leave":
                    timer += Time.deltaTime;
                    if (timer >= 2f)
                    {
                        SceneManager.LoadScene("testing 1");
                        Debug.Log("Next Scene");

                        resetCursor();
                    }
                    break;


            }
        }

    }

    public void NextScene ()
    {
        PlayerPrefs.SetInt("Round", 0);

        PlayerPrefs.SetInt("caseOffset", 0);

        timer = 0f;
        state = "Leave";        

    }
    
    public void changeCursor()
    {
        Cursor.SetCursor(clickCursor, cursorHotspot, CursorMode.Auto);
    }
    public void resetCursor ()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
