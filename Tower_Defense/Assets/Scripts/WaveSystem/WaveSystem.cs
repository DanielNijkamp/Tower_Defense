using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    private bool isCooldown;
    public TextMeshProUGUI waveText;

    public float intermissionTime;
    public float timeBeforeRoundStarts;

    public bool timerIsRunning;
    public float timer;

    //wave states
    public bool isRoundGoing;
    public bool isIntermission;
    public bool isStartOfRound;

    //
    public int MaxEnemyCount;
    public bool hasSpawnedEnemies;

    public float EnemySpawnTime;
    public int WaveCount;
    public int maxWaveCount;

    public GameObject[] EnemyPrefabs; // 1 = base | 2 = fast | 3 = heavy | 4 = tank
    public GameObject[] enemies;
    public List<GameObject> enemiesToSpawn;


    int[,] Waves = {
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},// ignore
        {1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0},
        {2,2,2,1,1,1,2,2,2,0,0,0,0,0,0,0},
        {3,1,3,1,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,1,1,1,1,1,1,1,2,2,3,3,3,4},
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0},
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0},
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0}
    };
    IEnumerator SpawnEnemies()
    {
        int i = 0;
        foreach (GameObject enemy in enemiesToSpawn)
        {
            
            if (enemy != null)
            {
                GameObject newEnemy = Instantiate(enemy, FindObjectOfType<MapGen>().InstantiatedStartingTile.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(EnemySpawnTime);
                i++;
            }
            else
            {
                yield return new WaitForSeconds(EnemySpawnTime-25);
                i++;
            }
            
            
            
        }
        hasSpawnedEnemies = true;
        yield break;
    }
    private void Start()
    {
        WaveCount = 0;
        //start of round: waits 10 seconds before starting wave spawning
        isStartOfRound = true;
        isIntermission = false;
        isRoundGoing = false;

        //turn on timer
        timer = Time.time + timeBeforeRoundStarts;
        timerIsRunning = true;

        
    }
    
    private void GetEnemies()
    {
        for (int enemy = 0; enemy < Waves.GetLength(1); enemy++)
        {
            if (Waves[WaveCount, enemy] == 0)
            {
                enemiesToSpawn.Add(null);
            }
            if (Waves[WaveCount, enemy] == 1)
            {
                enemiesToSpawn.Add(EnemyPrefabs[0]);
            }
            if (Waves[WaveCount, enemy] == 2)
            {
                enemiesToSpawn.Add(EnemyPrefabs[1]);
            }
            if (Waves[WaveCount, enemy] == 3)
            {
                enemiesToSpawn.Add(EnemyPrefabs[2]);
            }
            if (Waves[WaveCount, enemy] == 4)
            {
                enemiesToSpawn.Add(EnemyPrefabs[3]);
            }
        }
        StartCoroutine(SpawnEnemies());
    }
    private void StartNewRound() 
    {
        WaveCount++;
        FindObjectOfType<GameManager>().PlayerWealth += FindObjectOfType<GameManager>().WaveMoney;
        isStartOfRound = false;
        isRoundGoing = true;
        isIntermission = false;
        print("started new round!");
        GetEnemies();
        
    }
    private void StartIntermission()
    {
        timer = Time.time + intermissionTime;
        isRoundGoing = false;
        isIntermission = true;
        

    }


    private void Update()
    {
        waveText.text = "Round: " + WaveCount;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (timerIsRunning)
        {
            timer -= Time.deltaTime;
            if (isStartOfRound)
            {
                
                if (Time.time > timeBeforeRoundStarts)
                {

                    StartNewRound();
                    timerIsRunning = false;
                }
            }
            
            if (isIntermission)
            {
                if (Time.time > intermissionTime)
                {
                    StartNewRound();
                    timerIsRunning = false;
                }
            }
            

        }
       


    }
    private void FixedUpdate()
    {
        if (isRoundGoing)
        {
            //if there are no enemies left start new round
            if (hasSpawnedEnemies && enemies.Length == 0)
            {
                
                
                StartIntermission();
                timerIsRunning = true;
                isRoundGoing = false;
                enemiesToSpawn.Clear();
                hasSpawnedEnemies = false;
            }

        }
    }






    /*for (int i = 0; i < WaveCount; i++)
        {
            if (enemies.Length <= MaxEnemyCount)
            {
                GameObject newEnemy = Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length - 1)], FindObjectOfType<MapGen>().InstantiatedStartingTile.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1.25f);
            }
        }*/


}
