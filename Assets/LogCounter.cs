using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCounter : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject loggerObject ;

    public string id;
    public bool ignoreClick =false;


    void Start()
    {
        loggerObject = GameObject.Find("Logger");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Increment();
    }

    public void Increment()
    {
        clickerLogger log = loggerObject.GetComponent<clickerLogger>();

        log.Increment(id);
    }
}
