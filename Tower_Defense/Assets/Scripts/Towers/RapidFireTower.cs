using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireTower : Base_Tower
{
    
    private float timeBetweenShots ;
    private float NextTimeToShoot;
    private float Rotationspeed = 5;
    public Animator BarrelAnimation;

    public GameObject[] GunBarrels;
    public GameObject bullet;


    private GameObject currentTarget;

    [SerializeField] private List<GameObject> RapidNearbyEnemies = new List<GameObject>();

    private void Start()
    {
        timeBetweenShots = FireRate;
    }   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            RapidNearbyEnemies.Add(collision.gameObject);
            
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            RapidNearbyEnemies.Remove(collision.gameObject);
            if (this.RapidNearbyEnemies.Count == 0)
            {
                currentTarget = null;
            }
        }
    }
    private void Update()
    {
        updateNearestEnemy();
        if (currentTarget != null && this.RapidNearbyEnemies.Count > 0)
        {
            
            var offset = 0f;
            Vector3 dir = currentTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Rotationspeed * Time.deltaTime);

            if (Time.time >= NextTimeToShoot)
            {
                Shoot();
                NextTimeToShoot = Time.time + timeBetweenShots;
            }
        }
    

    }
    private void updateNearestEnemy()
    {
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in RapidNearbyEnemies)
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
    private void Shoot()
    {
        FindObjectOfType<SoundManagerScript>().PlayRapidFireShot();
        int random = Random.Range(0, GunBarrels.Length);
        if (random == 0)
        {
            BarrelAnimation.Play("Barrel1_Fire");
        }
        if (random == 1)
        {
            BarrelAnimation.Play("Barrel2_Fire");
        }
        if (random == 2)
        {
            BarrelAnimation.Play("Barrel3_Fire");
        }
        GameObject newBullet = Instantiate(bullet);
        newBullet.GetComponent<BulletScript>().bulletdamage = damage;
        newBullet.transform.position = GunBarrels[random].gameObject.transform.position;
        newBullet.transform.rotation = this.transform.rotation;
        

        

    }
}
