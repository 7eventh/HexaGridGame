using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    // General variables 
    public bool isPlayerUnitSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsUnitSelected();
    }

    private void IsUnitSelected()
    {
        // If one of the players selects a unit, disable their ability to spawn traps, obstacles etc 
    }

    // Handle traps from both sides 
    public void TrapPlaced()
    {

    }

    // Handle cards 
    public void CardsTaken()
    {

    }

}
