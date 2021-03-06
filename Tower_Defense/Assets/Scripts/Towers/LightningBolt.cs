using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    public float LightSpeed;
    public float LightDamage;

    public GameObject LightningChecker;
    public GameObject AoETower;
    [SerializeField] private float LightningTime;
    public int i;
    private void Start()
    {
        i = 0;
        Destroy(this.gameObject, FindObjectOfType<AoETowerScript>().timeBetweenShots);
    }
    private void FixedUpdate()
    {
        if (i < FindObjectOfType<LightningCheck>().Hit_Enemies.Count)
        {
            if (FindObjectOfType<LightningCheck>().Hit_Enemies[i] != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, FindObjectOfType<LightningCheck>().Hit_Enemies[i].transform.position, LightSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, FindObjectOfType<LightningCheck>().Hit_Enemies[i].transform.position) < 0.1)
                {
                    i++;
                }
            }
            else
            {
                i++;
            }
            
        }
        


        //this.transform.position += transform.right * LightSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage(LightDamage);

        }
    }
}
    

