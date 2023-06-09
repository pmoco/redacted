using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class DeselectView : MonoBehaviour
{

    public GameObject ObjectReturn;


    public Collider[] collidersToIgnore; // Array of colliders to ignore
    
   private bool ArrayContainsCollider(Collider[] colliders, Collider collider)
    {
        foreach (Collider c in colliders)
        {
            if (c == collider)
            {
                return true;
            }
        }
        return false;
    }


bool isFirstClick = true;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (isFirstClick)
                {
                    isFirstClick = false;
                    return;
                }


                // Cast a ray from the mouse position into the scene
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Check if the raycast hits any collider
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the collider hit is different from the colliderToCheck
                    if (!ArrayContainsCollider(collidersToIgnore, hit.collider))
                    {
                        // Mouse click was outside of the colliderToCheck
                        Debug.Log("Mouse click was peepeepoopoo");
                        gameObject.SetActive(false);
                            
                        if (ObjectReturn != null)
                            ObjectReturn.SetActive(true);

                        // Mouse click was outside of any collider
                        Debug.Log("Mouse click was outside of any collider");
                        isFirstClick = true;
                        // Place your logic here to show the object and hide the object containing the script
                    }
                    else {
                    Debug.Log(hit.collider.name);
                    }
                }
                else
                {

                    Debug.Log("Mouse click was outside of the colliderXXXXXX");
                    gameObject.SetActive(false);

                    if (ObjectReturn != null)
                        ObjectReturn.SetActive(true);

                    // Mouse click was outside of any collider
                    Debug.Log("Mouse click was outside of any collider");
                    isFirstClick = true;

                // Place your logic here to show the object and hide the object containing the script
                }
            }
        }
    }