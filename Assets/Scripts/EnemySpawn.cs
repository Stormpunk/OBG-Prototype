using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WaveText.text = "Wave" + currentWave.ToString() +"/"+ maxWave.ToString();
       maxWave = GameObject.Find("EnemySpawn").GetComponent<Difficulty>().maxWave;
        maxEnemiesToSpawn = GameObject.Find("EnemySpawn").GetComponent<Difficulty>().maxEnemiesToSpawn;
        if(currentWave >= maxWave)
        {
            
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
        }
    }
    void Randomize()
    {
        spawnTime = Random.Range(2f, 7f);
    }
    void SpawnEnemy()
    {
        Object.Instantiate(enemy);
        enemiesToSpawn -= 1;
    }
    void NextWave()
    {
        enemiesToSpawn = maxEnemiesToSpawn;
    }
}
