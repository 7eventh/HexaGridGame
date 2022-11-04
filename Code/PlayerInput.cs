using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private string Ostcl = "Obstacle";
    [SerializeField] private string Empt = "Empty";

    public UnityEvent<Vector3> PointerClick;

    void Update()
    {
        DetectMouseClick();
    }

    private void DetectMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        // Get mouse position Only when there is a click 
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            PointerClick?.Invoke(mousePos);
        }

        // Get information about object by shooting rays 
        if (Physics.Raycast(ray, out hitInfo))
        {
            var selection = hitInfo.transform;
            // IF player clicks a hex compare the tags.
            // Depending on if the hax is empty do something.
            if (Input.GetMouseButtonDown(0))
            {   
                if (selection.CompareTag(Ostcl))
                {
                    Debug.Log("Has Obstacle");   
                }
                // If is empty allow player to place a trap. (If available)
                else if (selection.CompareTag(Empt))
                {
                    Debug.Log("Empty");
                }
            }
        }   
    }
}
