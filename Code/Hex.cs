using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Hex : MonoBehaviour
{
    [SerializeField]
    private GlowHighlight highlight;
    private HexCoordinates hexCoordinates;

    [SerializeField]
    private HexType hexType;

    [SerializeField]
    private IsblockedBy blockedBy;

    public Vector3Int HexCoords => hexCoordinates.GetHexCoords(); 

    
    // If the hex changes ex. has obstacle, trap etc. Update the tag
    private void Update() 
    {
        if (this.hexType == HexType.Obstacle)
        {
            gameObject.tag = "Obstacle"; 
        }    
        // Add more condidtions for when it is not an obstacle or a semiobstacle. 
    }

    public int GetCost()
        => hexType switch
        {
            HexType.Difficult => 20,
            HexType.Default => 10,
            HexType.Road => 5,
            _ => throw new Exception($"Hex of type {hexType} not supported")
        };

    public bool IsObstacle()
    {
        return this.hexType == HexType.Obstacle;
    }

    private void Awake()
    {   // On awake set all tags to empty 
        gameObject.tag = "Empty";
        hexCoordinates = GetComponent<HexCoordinates>();
        highlight = GetComponent<GlowHighlight>();
    }
    public void EnableHighlight()
    {
        highlight.ToggleGlow(true);
    }

    public void DisableHighlight()
    {
        highlight.ToggleGlow(false);
    }

    internal void ResetHighlight()
    {
        highlight.ResetGlowHighlight();
    }

    internal void HighlightPath()
    {
        highlight.HighlightValidPath();
    }
}

public enum HexType
{
    None,
    Default,
    Difficult,
    Road,
    Water,
    Obstacle
}

public enum IsblockedBy 
{
    None,
    Fence,
    Bomb,
    Tree, 
    hole
}
