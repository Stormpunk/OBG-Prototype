using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public float spawnTime;
    public GameObject enemy;
    public float currentWave;
    public float maxWave;
    public float maxEnemiesToSpawn;
    public float enemiesToSpawn;
    public Text WaveText;
    public GameObject winPanel;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WaveText.text = "Wave" + currentWave.ToString() +"/"+ maxWave.ToString();
        //displays the current wave along with the maximum number of waves
       maxWave = GameObject.Find("EnemySpawn").GetComponent<Difficulty>().maxWave;
        maxEnemiesToSpawn = GameObject.Find("EnemySpawn").GetComponent<Difficulty>().maxEnemiesToSpawn;
        //sets the maximum waves and maximum enemies per wave
        if(currentWave >= maxWave)
        {
            VictoryScreen();
            //victory if the player survives all rounds
        }
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            SpawnEnemy();
            Randomize();
        }
        if(enemiesToSpawn <= 0)
        {
            currentWave++;
            maxEnemiesToSpawn += 5f;
            NextWave();
            //resets the enemy spawner and increases the maximum number of enemies it puts out
        }
    }
    void Randomize()
    {
        spawnTime = Random.Range(2f, 7f);
        //selects a float between 2 and 7, allowing enemies to be put out at a random time
    }
    void SpawnEnemy()
    {
        Object.Instantiate(enemy);
        enemiesToSpawn -= 1;
        //spawns an enemy then removes 1 from the maximum pool of enemies to spawn.
    }
    void NextWave()
    {
        enemiesToSpawn = maxEnemiesToSpawn;
        //resets the enemy spawner for the next wave
    }
    public void VictoryScreen()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
        //turns on the enemy screen and pauses the time
    }
}
