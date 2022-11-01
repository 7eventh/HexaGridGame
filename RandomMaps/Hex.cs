using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is similar to the one found on the main Code folder
// Since some maps will be random the Hex script should be modified. 
// If the script is stable untill the end, it can be merged with the main Hex script used for the premade maps. 

[SelectionBase]
public class Hex : MonoBehaviour
{
    private HexCoordinates hexCoordinates;

    public Vector3Int HexCoords => hexCoordinates.GetHexCoords();



    private void Awake()
    {
        hexCoordinates = GetComponent<HexCoordinates>();
    }
}
