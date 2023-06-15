using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CaseLoader : MonoBehaviour
{
    public string parentDirectoryPath; // Path to the parent directory
    public string directoryPrefix; // Prefix of the numbered subdirectories

    
    public  List<CaseFile> caseFiles; // List to store loaded case files

    void Start()
    {
        caseFiles = new List<CaseFile>();
        LoadSubdirectories();

        gameObject.GetComponentInChildren<CaseFile>().LoadExternalCaseFile(caseFiles[0]);
        




    }

    void LoadSubdirectories()
    {
        string[] subdirectoryPaths = Directory.GetDirectories(parentDirectoryPath); // Get an array of subdirectory paths

        foreach (string path in subdirectoryPaths)
        {
            if (Path.GetFileName(path).StartsWith(directoryPrefix))
            {


                CaseFile caseFile = new CaseFile();

                // Set the properties of the CaseFile object
                caseFile.id= (Path.GetFileName(path));
                caseFile.report = File.ReadAllText(Path.Combine(path, "rep_text.txt"));
                caseFile.reading = Resources.Load<Sprite>(caseFile.id + "/reading");
                caseFile.photo = Resources.Load<Sprite>(caseFile.id + "/rep_photo");
                caseFile.png_blue= Resources.Load<Sprite>(caseFile.id + "/photoB");
                caseFile.png_red= Resources.Load<Sprite>(caseFile.id + "/photoR");
                caseFile.png_green = Resources.Load<Sprite>(caseFile.id+ "/photoG");
                caseFile.fb_sup = File.ReadAllText(Path.Combine(path, "fbrep_Sup.txt"));
                caseFile.fb_close = File.ReadAllText(Path.Combine(path, "fbrep_close.txt"));
                caseFile.fb_dispatch = File.ReadAllText(Path.Combine(path, "fbrep_dispatch.txt"));



                caseFiles.Add(caseFile); // Add the CaseFile object to the list
            }
        }

        // Do something with the caseFiles list, such as using the loaded data
        foreach (CaseFile caseFile in caseFiles)
        {
            // Use the loaded case file data as needed
            Debug.Log("Paths for CaseFile " + caseFile.id + ":");
            Debug.Log("Report: " + caseFile.report);


            Debug.Log("Feedback Sup: " + caseFile.fb_sup);
            Debug.Log("Feedback Close: " + caseFile.fb_close);
            Debug.Log("Feedback Dispatch: " + caseFile.fb_dispatch);

            Debug.Log("PHOTO : " + caseFile.photo.name);
            Debug.Log("-------------------------------------------");
            // ...
        }
    }






}