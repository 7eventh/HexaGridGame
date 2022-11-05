using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private string Ostcl = "Obstacle";
    [SerializeField] private string Empt = "Empty";

    private const float DOUBLE_CLICK_TIME = .2f;
    public float lastTimeClicked;


    public UnityEvent<Vector3> PointerClick;

    void Update()
    {
        DetectMouseClick();
        ClickForInformation();        
    }

    private void ClickForInformation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo; 
        // Get information about object by shooting rays 
        if (Input.GetMouseButtonDown(0))
        { 
            // Calculate the time since the last click 
            float timeFromLastClick = Time.time - lastTimeClicked;
            // If user dubble click allow selection of single Hex
            // TODO: A future bug will be the fact that user dubble clicks to move minion.
            // This will also select hex which is not desired.
            if (timeFromLastClick <= DOUBLE_CLICK_TIME)
            {
                // IF player clicks a hex compare the tags.
                // Depending on if the hax is empty do something.
                if (Physics.Raycast(ray, out hitInfo)) 
                {   
                    var selection = hitInfo.transform;
                    selection.GetComponent<GlowHighlight>();

                    if (selection.CompareTag(Ostcl))
                    {
                        // Debug.Log("Has Obstacle");   
                    }
                    // If is empty allow player to place a trap. (If available)
                    else if (selection.CompareTag(Empt))
                    {
                        // If hex tag == epty and playerHasObstacles
                        // Spawn players Obstacle + Animation later 
                        // else if tag == notEmpty and playerHasObstacle
                        // say you cant place obstcl here
                        // else if not playerHasObstacle
                        // say you have no obstacles

                        //  

                        if (selection.GetComponent<GlowHighlight>().isGlowing == false)
                        {
                            selection.GetComponent<GlowHighlight>().ToggleGlow(true);
                        }
                        else
                        {
                            selection.GetComponent<GlowHighlight>().ToggleGlow();
                        }
                    }
                }
            }
            else // Ass something here?? else delete
            {
                // Debug.Log("Normal clicked!");
            }
            // Check time passed after clicking 
            lastTimeClicked = Time.time; 
        }   
    }

    private void DetectMouseClick()
    {   
        // Get mouse position Only when there is a click 
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            PointerClick?.Invoke(mousePos);
        }
    }
}
