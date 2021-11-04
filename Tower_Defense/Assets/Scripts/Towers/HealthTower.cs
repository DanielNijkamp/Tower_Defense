using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTower : MonoBehaviour
{
    private int healthToAdd;

    
    public void AddHealth()
    {
        healthToAdd = Random.Range(10, 35);
        FindObjectOfType<GameManager>().PlayerHealth += healthToAdd;
        FindObjectOfType<SoundManagerScript>().Play_Health_Sound();
    }
}
