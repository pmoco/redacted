using System;
using System.IO;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public string logFolderPath;
    private string clickerLogFilePath;
    private string solutionLogFilePath;
    private string attemptNrFilePath;
    public  int attemptNr;

    private void Awake()
    {
        clickerLogFilePath = Path.Combine(logFolderPath, "ClickerLog.csv");
        solutionLogFilePath = Path.Combine(logFolderPath, "SolutionLog.csv");
        attemptNrFilePath = Path.Combine(logFolderPath, "attemptNr.txt");

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CreateLogFolderIfNotExists();
        CreateClickerLogFileIfNotExists();
        CreateSolutionLogFileIfNotExists();
        ReadOrInitializeAttemptNr();

        // Start logging events or perform other operations
    }

    private void CreateLogFolderIfNotExists()
    {
        if (!Directory.Exists(logFolderPath))
        {
            Directory.CreateDirectory(logFolderPath);
        }
    }

    private void CreateClickerLogFileIfNotExists()
    {
        if (!File.Exists(clickerLogFilePath))
        {
            File.WriteAllText(clickerLogFilePath, "AttemptNr,ClickId,Count\n");
        }
    }

    private void CreateSolutionLogFileIfNotExists()
    {
        if (!File.Exists(solutionLogFilePath))
        {
            File.WriteAllText(solutionLogFilePath, "AttemptNr,CaseFile,Solution\n");
        }
    }

    private void ReadOrInitializeAttemptNr()
    {
        if (File.Exists(attemptNrFilePath))
        {
            string attemptNrString = File.ReadAllText(attemptNrFilePath);
            if (int.TryParse(attemptNrString, out int number))
            {
                attemptNr = number;
                IncrementAttemptNr();
            }
            else
            {
                Debug.LogWarning("Failed to parse the attempt number from the file. Initializing attempt number to 1.");
                attemptNr = 1;
            }
        }
        else
        {
            attemptNr = 1;
            File.WriteAllText(attemptNrFilePath, attemptNr.ToString());
        }
    }

    // Other logging methods or functionality can be added here

    public void IncrementAttemptNr()
    {
        attemptNr++;
        File.WriteAllText(attemptNrFilePath, attemptNr.ToString());
    }

    public void AppendToClickerLog(string target, string Counter)
    {
        string logLine = $"{attemptNr},{target},{Counter}";
        File.AppendAllText(clickerLogFilePath, logLine + Environment.NewLine);
    }

    public void AppendToSolutionLog(string caseFileId, string solutionData)
    {
        string logLine = $"{attemptNr},{caseFileId},{solutionData}";
        File.AppendAllText(solutionLogFilePath, logLine + Environment.NewLine);
    }



}