using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoETowerScript : Base_Tower
{
    public float timeBetweenShots;
    private float NextTimeToShoot;

    
    private GameObject currentTarget;
    public GameObject nextTarget;

    public List<GameObject> AoE_Nearby = new List<GameObject>();

    public int radius;
    public int chaincount;
    public int maxchaincount;


    public GameObject lightningcheckprefab;
    public GameObject lightningboltprefab;
    public GameObject lightningBolt;
    public GameObject lightningChecker;


    public bool hasShot = false;
    private void Start()
    {
        timeBetweenShots = FireRate;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            AoE_Nearby.Add(collision.gameObject);             
        }
    }
   
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            AoE_Nearby.Remove(collision.gameObject);
            if (AoE_Nearby.Count == 0)
            {
                currentTarget = null;
            }
        }
    }
    private void Update()
    {
        updateNearestEnemy();
        if (currentTarget != null)
        {
            if (Time.time >= NextTimeToShoot)
            {
                StartCoroutine(Shoot());
                NextTimeToShoot = Time.time + timeBetweenShots;
            }
        }
        
    }
    private void updateNearestEnemy()
    {
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in AoE_Nearby)
        {
            if (enemy != null)
            {
                float _distance = (transform.position - enemy.transform.position).magnitude;
                if (_distance < distance)
                {
                    distance = _distance;
                    
                        currentTarget = enemy;
                    
                   

                }
            }

        }
       

    }
    public void ResetFire()
    {
        Destroy(this.lightningBolt, 1);
        Destroy(this.lightningChecker, 1);
        
        
    }
    IEnumerator Shoot()
    {
        FindObjectOfType<SoundManagerScript>().Play_AoE_Shot();
        lightningChecker = Instantiate(lightningcheckprefab);
        lightningChecker.transform.position = currentTarget.transform.position;
        lightningBolt = Instantiate(lightningboltprefab);
        lightningBolt.GetComponent<LightningBolt>().LightDamage = this.damage;
        lightningBolt.transform.position = this.transform.position;
        hasShot = true;
        yield return new WaitForSeconds(2f);
        hasShot = false;

    }
    



}



    



    
    

