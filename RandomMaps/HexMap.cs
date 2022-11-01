using UnityEngine;
using System.Collections;

// The purpose of this script is to generate a completely random map where two or more players can play toghether


public class HexMap : MonoBehaviour {

	public GameObject hexPrefab;

	// Size of the map in terms of number of hex tiles
	// This is NOT representative of the amount of world space that we're going to take up.
	// For optimal rendering speed keep the values less than 40
	int width_z_axis = 25;
	int height_y_axis = 20;

    // Depending on the size of the hex-tile the offsets may vary
    // Always check the size of a new prefab before adding new code
	float xOffset = 2;
	float zOffset = 1.73f;

    public Material[] HexMaterials;

	// Use this for initialization
    // Can also be changed to public void Awake() to combine with menus'
	void Start () {
        GenerateMap();
    }
	
    virtual public void GenerateMap()
    {
        // With the following two loops generate the hexagonal rows
		for (int x = 0; x < width_z_axis; x++) {
			for (int y = 0; y < height_y_axis; y++) {

				float xPos = x * xOffset;
                
				// When there is a new row to be created use the predefined xoffset
				if( y % 2 == 1 ) {
					xPos += xOffset/2f;
				}
                // In case the tiles must be rotated change te Quanterion.identity to Quanterion.Euler(x,y,z) 
				GameObject hex_go = (GameObject)Instantiate(hexPrefab, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity);
                MeshRenderer mr = hex_go.GetComponentInChildren<MeshRenderer>();
                mr.material = HexMaterials[ Random.Range(0, HexMaterials.Length)]; 

                // Use the line bellow while on development mode. 
                // Once the game development is over either toggle off the TextMesh or take away the component from the Hex prefab.
                hex_go.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", x, y );
			}
		}
    }


}
