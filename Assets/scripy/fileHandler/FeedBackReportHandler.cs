using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

using TMPro;

public class FeedBackReportHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public List<CaseFile> FbList ;
    public int Ncases = 0;

    public List<GameObject> position;

    public RoundManager rm;



    private void Awake()
    {
        

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetFeedback()
    {
        foreach( GameObject go in position)
        {
            go.SetActive(false);
        }

        FbList.Clear();

    }
    public void addCase(CaseFile caseFile)
    {
        FbList.Add(caseFile);

    }

    public void LoadFeedBack()
    {
        int x = 0;
        foreach(CaseFile cf in FbList)
        {
            GameObject  pos = position[x];

            TMP_Text fbText = pos.transform.Find("closeUp").Find("Canvas").Find("Text").GetComponent<TMP_Text>();

            switch (cf.decision)
            {
                case CaseFile.Decision.Supernatural:
                    fbText.text = cf.fb_dispatch;
                    pos.SetActive(true);
                    break;
                case CaseFile.Decision.Urgent:
                    fbText.text = cf.fb_sup;
                    pos.SetActive(true);
                    break;
                case CaseFile.Decision.Ignore:
                    fbText.text = cf.fb_close;
                    pos.SetActive(true);
                    break;
                case CaseFile.Decision.NULL:
                    fbText.text = "";
                    pos.SetActive(false);
                    break;

            }

            x++;
        }
    }

    


}
