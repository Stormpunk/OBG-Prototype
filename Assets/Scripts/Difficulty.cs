using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
   public float maxWave;
    public float maxEnemiesToSpawn;
    public GameObject DifficultyPanel;
    private void Update()
    { 
        if (DifficultyPanel.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else if (!DifficultyPanel.activeInHierarchy)
        {
            Time.timeScale = 1;
        }
    }
    public void Easy()
    {
        maxWave = 3;
        maxEnemiesToSpawn = 3;
        Debug.Log("Difficulty is Easy");
        DifficultyPanel.SetActive(false);
    }
    public void Normal()
    {
        maxWave = 5;
        maxEnemiesToSpawn = 7;
        Debug.Log("Difficulty is Normal");
        DifficultyPanel.SetActive(false);
    }
    public void Hard()
    {
        maxWave = 8;
        maxEnemiesToSpawn = 10;
        Debug.Log("Dark Souls");
        DifficultyPanel.SetActive(false);
    }
}
