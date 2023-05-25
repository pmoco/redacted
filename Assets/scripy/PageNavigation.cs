using UnityEngine;

public class PageNavigation : MonoBehaviour
{
    public GameObject pages;  // Reference to the parent object "Pages"
    private Transform[] pageArray;  // Array to store individual page references
    private int currentPageIndex;  // Index of the current page

     public Collider leftCollider ; // Collider to check against
     public Collider rightCollider; // Collider to check against

    private bool isFirstClick =true;
      public GameObject ObjectReturn;

    private void Start()
    {
        // Get all the child page objects and store their references in the array
        int pageCount = pages.transform.childCount;
        pageArray = new Transform[pageCount];
        for (int i = 0; i < pageCount; i++)
        {
            pageArray[i] = pages.transform.GetChild(i);
            pageArray[i].gameObject.SetActive(false);  // Hide all the pages initially
        }

        currentPageIndex = 0;
        pageArray[currentPageIndex].gameObject.SetActive(true);  // Show the first page
    }

    private void NavigateToNextPage()
    {
        // Hide the current page
        pageArray[currentPageIndex].gameObject.SetActive(false);

        // Move to the next page (loop back to the first page if at the end)
        currentPageIndex = (currentPageIndex + 1) % pageArray.Length;

        // Show the next page
        pageArray[currentPageIndex].gameObject.SetActive(true);
    }

    private void NavigateToPreviousPage()
    {
        // Hide the current page
        pageArray[currentPageIndex].gameObject.SetActive(false);

        // Move to the previous page (loop back to the last page if at the beginning)
        currentPageIndex = (currentPageIndex + pageArray.Length - 1) % pageArray.Length;

        // Show the previous page
        pageArray[currentPageIndex].gameObject.SetActive(true);
    }


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
                    if (hit.collider != rightCollider && hit.collider != leftCollider)
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
                    else if (hit.collider == leftCollider)
                    {
                        Debug.Log("PREV");
                        NavigateToPreviousPage();
                    }else if (hit.collider == rightCollider){
                        Debug.Log("NEXT");
                        NavigateToNextPage();
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