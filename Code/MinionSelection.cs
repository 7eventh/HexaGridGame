using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinionSelection : MonoBehaviour
{
    // Create an array for the available minions 
    public GameObject[] minions;
    // Each minion has it's own index 
    public int selectedMinion = 0;

    // When the "next" button is pressed increase the index by one and switch the prefab accordingly 
    public void NextMinion()
    {   // Set the prefab visibility false/true depending on its state 
        minions[selectedMinion].SetActive(false);
        // Once the Array divided by its self equals zero then start over
        selectedMinion = (selectedMinion + 1) % minions.Length;
        minions[selectedMinion].SetActive(true);
    }

    // This function is the same as the above but in reverse.
    public void PreviousMinion()
    {
        minions[selectedMinion].SetActive(false);
        selectedMinion--;
        if (selectedMinion < 0)
        {
            selectedMinion += minions.Length;
        }
        minions[selectedMinion].SetActive(true);
    }

    public void StartGame()
    {   // Store the players choice and transfer it to the next scene 
        PlayerPrefs.SetInt("selectedMinion", selectedMinion);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
