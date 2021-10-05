using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTowerScript : MonoBehaviour
{
    public float SlowEffect;
    public float TankSlowEffect;
    private int Normalspeed;
    [SerializeField] List<GameObject> FoundEnemies = new List<GameObject>();
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            FoundEnemies.Add(collision.gameObject);
            if (FoundEnemies.Contains(collision.gameObject))
            {
                if (collision.gameObject.GetComponent<Enemy>().isTank)
                {
                    collision.gameObject.GetComponent<Enemy>().speed = TankSlowEffect;
                }
                else
                {
                    collision.gameObject.GetComponent<Enemy>().speed = SlowEffect;
                }
                
            }
            

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag =="Enemy")
        {
            FoundEnemies.Remove(collision.gameObject);
            if (!FoundEnemies.Contains(collision.gameObject))
            {
                if (collision.gameObject.GetComponent<Enemy>().isTank)
                {
                    collision.gameObject.GetComponent<Enemy>().speed = collision.gameObject.GetComponent<Enemy>().baseSpeed;
                }
                else
                {
                    collision.gameObject.GetComponent<Enemy>().speed = collision.gameObject.GetComponent<Enemy>().baseSpeed;
                }
            }
        }
    }
    private void Update()
    {
    }
    
}
