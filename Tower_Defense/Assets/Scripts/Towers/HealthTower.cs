using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTower : MonoBehaviour
{
    public int healthToAdd;

    
    public void AddHealth()
    {
        FindObjectOfType<GameManager>().PlayerHealth += healthToAdd;
    }
}
