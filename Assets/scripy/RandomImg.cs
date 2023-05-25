using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImg : MonoBehaviour
{
    public GameObject[] childObjects;
    private GameObject activeChildObject;

    // Start is called before the first frame update
    void Start()
    {
        // Get all the child objects of the parent object
        childObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
        }

        // Disable all child objects initially
        foreach (GameObject child in childObjects)
        {
            child.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // Disable the parent object (TODO)

        // Enable a random child object
        activeChildObject = GetRandomChildObject();

        if (activeChildObject != null)
        {
            activeChildObject.SetActive(true);
        }
    }

    GameObject GetRandomChildObject()
    {
        // Check if there are any child objects
        if (childObjects.Length > 0)
        {
            // Generate a random index within the range of childObjects array
            int randomIndex = Random.Range(0, childObjects.Length);

            // Return the randomly selected child object
            return childObjects[randomIndex];
        }

        return null; // No child objects found
    }
}