using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class High_Cal : Base_Tower
{
    public float timeBetweenShots;
    private float NextTimeToShoot;
    private float Rotationspeed = 5;
    public Animator BarrelAnimation;

    public GameObject gunBarrel;
    public GameObject bullet;

    private GameObject currentTarget;

    [SerializeField] public List<GameObject> High_Cal_NearbyEnemies = new List<GameObject>();

    private void Start()
    {
        timeBetweenShots = FireRate;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            High_Cal_NearbyEnemies.Add(collision.gameObject);
            
        }
        
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            High_Cal_NearbyEnemies.Remove(collision.gameObject);
            if (this.High_Cal_NearbyEnemies.Count == 0)
            {
                currentTarget = null;
            }
        }
    }
    private void Update()
    {
        
        updateNearestEnemy();
        if (currentTarget != null && this.High_Cal_NearbyEnemies.Count > 0)
        {

            var offset = 0f;
            Vector3 dir = currentTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Rotationspeed * Time.deltaTime);

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

        foreach (GameObject enemy in High_Cal_NearbyEnemies)
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
    IEnumerator Shoot()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        FindObjectOfType<SoundManagerScript>().PlayHC_Shot();
        GameObject newBullet = Instantiate(bullet);
        newBullet.GetComponent<BulletScript>().bulletdamage = damage;
        newBullet.transform.position = gunBarrel.gameObject.transform.position;
        newBullet.transform.rotation = this.transform.rotation;
        BarrelAnimation.SetTrigger("High_Cal_Shoot");




    }
}

