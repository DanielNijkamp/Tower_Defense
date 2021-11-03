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
        {1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0},// 1
        {1,2,1,0,1,2,1,0,0,0,0,0,0,0,0,0},// 2
        {3,1,3,1,0,0,0,0,0,0,0,0,0,0,0,0},// 3
        {1,2,2,1,2,2,1,2,2,0,0,0,0,0,0,0},// 4
        {3,1,3,3,3,0,0,0,0,0,0,0,0,0,0,0},// 5
        {2,2,2,2,2,2,1,1,1,1,0,0,0,0,0,0},// 6
        {1,1,1,1,3,0,0,0,0,0,0,0,0,0,0,0},// 7
        {1,2,1,2,3,2,3,1,2,3,0,0,0,0,0,0},// 8
        {2,1,1,1,1,0,0,0,1,1,0,0,0,3,3,3},// 9
        {3,3,2,2,1,1,1,3,3,0,0,0,0,1,3,3},// 10

        {2,1,2,1,3,2,1,0,0,0,0,0,0,0,0,0},// 11
        {3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0},// 12
        {2,1,2,1,2,1,2,1,2,1,0,0,0,0,0,0},// 13
        {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0},// 14
        {0,3,0,3,0,3,0,0,0,0,0,0,3,3,3,3},// 15
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 16
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 17
        {2,2,2,1,1,1,1,1,0,0,0,0,0,0,0,0},// 18
        {2,1,2,1,2,2,2,2,2,2,2,2,2,2,2,2},// 19
        {1,1,1,1,1,1,1,1,1,3,3,3,3,3,3,4},// 20

        {2,1,2,1,3,2,1,0,0,0,0,0,0,0,0,0},// 21
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 22
        {2,1,3,1,3,2,1,3,0,0,3,3,3,0,0,0},// 23
        {2,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 24
        {2,1,1,3,1,3,3,3,0,0,0,0,0,0,0,0},// 25
        {1,2,2,2,2,2,2,3,0,0,0,0,0,0,0,0},// 26
        {1,2,1,1,3,2,3,2,0,0,0,0,0,0,0,0},// 27
        {1,1,3,3,3,3,2,2,3,1,2,1,1,2,1,3},// 28
        {3,3,3,3,2,3,2,3,1,1,1,1,1,1,1,1},// 29
        {3,1,2,1,2,2,2,2,2,2,2,3,3,4,4,4},// 30

        {2,1,1,3,1,3,3,3,0,0,0,0,0,0,0,0},// 31
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 32
        {3,1,3,1,3,3,0,0,0,0,0,0,0,0,0,0},// 33
        {2,1,3,1,4,2,2,2,3,1,1,2,3,0,0,0},// 34
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 35
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 36
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 37
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 38
        {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},// 39
        {4,4,4,4,4,4,4,3,3,3,3,3,2,2,4,4},// 40
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

        if (WaveCount == 40)
        {
            print("bruh momento");
        }
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
        Activate_Money_Towers();
        Activate_Health_Towers();
        GetEnemies();
        
    }
    
    
    
        
    
    IEnumerator StartIntermission()
    {
        isRoundGoing = false;
        yield return new WaitForSeconds(intermissionTime);
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
                StartNewRound();
                timerIsRunning = false;
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
                
                StartCoroutine(StartIntermission());
                timerIsRunning = true;
                isRoundGoing = false;
                enemiesToSpawn.Clear();
                hasSpawnedEnemies = false;
            }

        }
    }
    public void Activate_Money_Towers()
    {
        GameObject[] moneyTowers = GameObject.FindGameObjectsWithTag("Money_Tower");
        foreach (GameObject money_tower in moneyTowers)
        {
            if (money_tower != null)
            {
                money_tower.GetComponent<MoneyTower>().AddWaveEndMoney();
                
            }
            
        }
    }
    public void Activate_Health_Towers()
    {
        GameObject[] healthTowers = GameObject.FindGameObjectsWithTag("Health_Tower");
        foreach (GameObject health_tower in healthTowers)
        {
            if (health_tower != null)
            {
                health_tower.GetComponent<HealthTower>().AddHealth();

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
