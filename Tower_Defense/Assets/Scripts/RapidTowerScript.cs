using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidTowerScript : MonoBehaviour
{
    
    [SerializeField] List<GameObject> FoundEnemies = new List<GameObject>();
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag =="Enemy")
        {
            FoundEnemies.Add(collision.gameObject);
            Debug.Log("added enemy to list");
        }
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag =="Enemy")
        {
            FoundEnemies.Remove(collision.gameObject);
            Debug.Log("removed enemy to list");
        }
    }
    private void Update()
    {
         
        
    }
}
