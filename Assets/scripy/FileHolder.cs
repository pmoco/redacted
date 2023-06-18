using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileHolder : MonoBehaviour
{

    public List<CaseFile> caseFiles;
    public int nCasesDelivered =0;

    public List<GameObject> files;

    public GameObject endButton;
    public int allcases;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject x in files )
        {
            x.SetActive( false );
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCaseFile(CaseFile cf  )
    {
        caseFiles.Add(cf);

        files[nCasesDelivered].SetActive(true);
        nCasesDelivered++;
        
        if (nCasesDelivered >= allcases)
        {
            endButton.SetActive(true);
        }

    }





}
