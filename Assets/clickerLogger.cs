using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickerLogger : MonoBehaviour
{
    // Start is called before the first frame update

    Logger logger;




    private Dictionary<string, int> ClickerLogs;

    private void Start()
    {
        ClickerLogs = new Dictionary<string, int>();

        logger = GetComponent<Logger>();
    }

    public void Increment(string key)
    {
        if (ClickerLogs.ContainsKey(key))
        {
            ClickerLogs[key]++;
        }
        else
        {
            ClickerLogs[key] = 1;
        }
    }

    public void Log()
    {
        foreach (KeyValuePair<string, int> kvp in ClickerLogs)
        {
            logger.AppendToClickerLog(kvp.Key, kvp.Value.ToString());
        }
    }



}
