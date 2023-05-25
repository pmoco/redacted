using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToScanner : MonoBehaviour
{


    private void OnMouseDown()
    {

        Debug.Log("kjsfklabnsdkfn");
        // Find the GameObject named "scanner"
        GameObject scannerObject = GameObject.Find("scanner");

        // Check if the "scanner" GameObject is found
        if (scannerObject != null)
        {
            // Get the Scanner script component attached to the "scanner" GameObject
            Scanner scanner = scannerObject.GetComponent<Scanner>();

            CaseFile cf = transform.parent.parent.GetComponent<CaseFile>();


            // Check if the Scanner script component is found
            if (scanner != null)
            {
                // Call the SetImage function of the Scanner script with the sprite from this.sprite
                scanner.SetImage(cf);
            }
            else
            {
                Debug.LogError("Scanner script component not found on the 'scanner' GameObject!");
            }
        }
        else
        {
            Debug.LogError("GameObject named 'scanner' not found!");
        }
    }
}

