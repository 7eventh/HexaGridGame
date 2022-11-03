using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadMinions : MonoBehaviour
{
    // Store the available minion prefabs and spwan points 
    public GameObject[] minionPrefabs;
    public Transform spawnPoint;
    // The label modifies the UI text responsible for showing the name of the previously selected minion 
    public TMP_Text label; 

    // Start is called before the first frame update
    void Start()
    {
        // With the index given from the selection scene spawn the same character on the game
        int selectedMinion = PlayerPrefs.GetInt("selectedMinion");
        GameObject prefab = minionPrefabs[selectedMinion];
        // Create a clone of the existing prefab and spawn it in a desired position. 
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        // The line above is used for testing 
        // It can either be modified and used somehow in the future or removed competelly. 
        label.text = prefab.name;
    }
}
