using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CaseFile;

using UnityEngine.Events;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.Contracts;

[System.Serializable] 
public class RoundManager : MonoBehaviour
{

    public Clock clock;

    private float roundDuration = 480f; // Round duration in seconds (8 minutes)
    private float halfTrigger  = 240f; // Break duration in seconds (4 minutes)

    public int minPerRound = 8; 


    public float timer = 0f;

    public bool afternoon = false;
    public bool isRoundActive = false;
    public bool isBreakActive = false;


    public int[] casePerRound ;
    public  int roundIndex;
    public int caseOffset;

    public CaseLoader caseLoader;

    public GameObject casePosition1;
    public GameObject casePosition2;
    public GameObject casePosition3;

    public GameObject fileHolder;
    public GameObject feedBack;


    public List<UnityEvent> onStart;
    public List<UnityEvent> onLunch;
    public List<UnityEvent> onEnd;


    Logger logger;

    private void Start()
    {
        roundDuration = minPerRound * 60f;
        halfTrigger = roundDuration / 2;


        roundIndex = PlayerPrefs.GetInt("Round");
        caseOffset = PlayerPrefs.GetInt("caseOffset");


        Debug.Log("CASE COUNTER  =  " + caseOffset);


        logger =GameObject.Find("Logger").GetComponent<Logger>();

        afternoon = false;
        isBreakActive = false;

        StartRound();
    }

    private void Update()
    {
        if (isRoundActive)
        {
            timer += Time.deltaTime;

            if (!afternoon && timer >= halfTrigger)
            {
                onStartLunchbreak();
                isRoundActive = false; 
            }
            else if (afternoon && timer >= halfTrigger)
            {
                EndRound();
            }

        }

    }

    private void StartRound()
    {
        // Start the round
        Debug.Log("New Day Load!");

        int nCases = casePerRound[roundIndex];

        caseLoader.caseCounter = caseOffset;

        switch (nCases)
        {
            case 3:
                caseLoader.LoadNextCase(casePosition1);
                caseLoader.LoadNextCase(casePosition2);
                caseLoader.LoadNextCase(casePosition3);
                break; 
            case 2:
                caseLoader.LoadNextCase(casePosition1);
                caseLoader.LoadNextCase(casePosition2);
                break;
            case 1:
                caseLoader.LoadNextCase(casePosition1);


                
                break;
            default:
                Debug.LogError("Invalid number of cases in this round");
                break;

        }

        caseOffset += nCases;


        onStart[roundIndex].Invoke();

        FileHolder fh = fileHolder.GetComponent<FileHolder>();
        fh.allcases = nCases;
    }

    public void EndRound()
    {
        // End the round
        Debug.Log("Round ended!");

        isRoundActive = false;
        clock.clockSpeed = 0;
        timer = 0f; // Reset the timer for the next round


        casePosition1.SetActive(false);
        casePosition2.SetActive(false);
        casePosition3.SetActive(false);


        onEnd[roundIndex].Invoke();
        
    }

    private void onStartLunchbreak()
    {
        // Start the lunch break
        Debug.Log("Lunch break started!");

        isBreakActive = true;
        clock.clockSpeed = 0;

        onLunch[roundIndex].Invoke();
        

    }

    public void EndLunchbreak()
    {
        // End the lunch break
        Debug.Log("Lunch break ended!");
        clock.clockSpeed = 60;
        clock.minutes = 0;
        clock.seconds = 0;
        clock.hour= 2;
        isBreakActive = false;
        afternoon = true;
        isRoundActive = true;
        timer = 0f; 
    }

    public void StartMorning()
    {
        Debug.Log("Clock Start!");
        clock.clockSpeed = 60;
        clock.hour = 9;
        clock.minutes = 0;
        clock.seconds = 0;

        isRoundActive = true;
    }

    public void EndDay()
    {
        Debug.Log("Next Day!");

        feedBack = GameObject.Find("Permanent");
        FeedBackReportHandler fb =feedBack.GetComponent<FeedBackReportHandler>();

        FileHolder fh  =  fileHolder.GetComponent<FileHolder>();

        fb.ResetFeedback();


        switch (casePerRound[roundIndex])
        {
            case 3:
                CaseFile cf1 = casePosition1.GetComponent<CaseFile>();
                CaseFile cf2 = casePosition2.GetComponent<CaseFile>();
                CaseFile cf3 = casePosition3.GetComponent<CaseFile>();

                fb.addCase(cf1);
                fb.addCase(cf2);
                fb.addCase(cf3);


                logger.AppendToSolutionLog(cf1.id, cf1.Solution());
                logger.AppendToSolutionLog(cf2.id, cf2.Solution());
                logger.AppendToSolutionLog(cf3.id, cf3.Solution());

                break;
            case 2:
                CaseFile cf_1 = casePosition1.GetComponent<CaseFile>();
                CaseFile cf_2 = casePosition2.GetComponent<CaseFile>();
               

                fb.addCase(cf_1);
                fb.addCase(cf_2);


                logger.AppendToSolutionLog(cf_1.id, cf_1.Solution());
                logger.AppendToSolutionLog(cf_2.id, cf_2.Solution());

                break;
            case 1:
                CaseFile cf = casePosition1.GetComponent<CaseFile>();
                fb.addCase(cf);

                logger.AppendToSolutionLog(cf.id, cf.Solution());
                break;
            default:
                Debug.LogError("Invalid number of cases in this round");
                break;

        }



        fb.LoadFeedBack();



        roundIndex++;

        PlayerPrefs.SetInt("Round", roundIndex);
        PlayerPrefs.SetInt("caseOffset", caseOffset);

        if (roundIndex < casePerRound.Length)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }


        Debug.Log("THE FEED Back is Here ");





    }

    public void ClickerLog()
    {
        logger.gameObject.GetComponent<clickerLogger>().Log();
    }


    







}
