using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTower : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("AddWaveMoney",0,1f);
        
    }
    
    public void AddWaveEndMoney()
    {
        FindObjectOfType<GameManager>().PlayerWealth += 100;
        FindObjectOfType<SoundManagerScript>().Play_Money_Sound(1, 2);
    }
    void AddWaveMoney()
    {
        FindObjectOfType<GameManager>().PlayerWealth += Random.Range(5,35);
        
    }
     
}
