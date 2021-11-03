using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTowerScript : MonoBehaviour
{
    public float SlowEffect;
    public float TankSlowEffect;
    private int Normalspeed;
    [SerializeField] List<GameObject> FoundEnemies = new List<GameObject>();
    private void Start()
    {
        FindObjectOfType<SoundManagerScript>().Play_Slow_Sound(0);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Enemy")
        {
            FoundEnemies.Add(col.gameObject);
            if (FoundEnemies.Contains(col.gameObject))
            {
                if (col.gameObject.GetComponent<Enemy>().isBoss)
                {
                    col.gameObject.GetComponent<Enemy>().speed = col.gameObject.GetComponent<Enemy>().bossslowspeed;
                }
                else
                {
                    col.gameObject.GetComponent<Enemy>().speed = col.gameObject.GetComponent<Enemy>().slowspeed;
                }

            }


        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.tag == "Enemy")
        {
            FoundEnemies.Remove(collision.gameObject);
            if (!FoundEnemies.Contains(collision.gameObject))
            {
                if (collision.gameObject.GetComponent<Enemy>().isTopDown)
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
}
