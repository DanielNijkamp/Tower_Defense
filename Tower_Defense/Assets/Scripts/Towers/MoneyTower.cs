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
        Debug.Log("got money from money tower");
    }
    void AddWaveMoney()
    {
        FindObjectOfType<GameManager>().PlayerWealth += Random.Range(5,35);
    }
     
}
