using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireTower : MonoBehaviour
{
    public float damage = 2.5f;
    public float timeBetweenShots;
    private float NextTimeToShoot;
    private float Rotationspeed = 5;

    public GameObject[] GunBarrels;
    public GameObject bullet;

    private GameObject currentTarget;

    public List<GameObject> NearbyEnemies = new List<GameObject>();


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            NearbyEnemies.Add(collision.gameObject);
            currentTarget = collision.gameObject;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            NearbyEnemies.Remove(collision.gameObject);
            if (NearbyEnemies.Count == 0)
            {
                currentTarget = null;
            }
        }
    }
    private void Update()
    {
        if (currentTarget != null)
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
    private void Shoot()
    {
        int random = Random.Range(0, GunBarrels.Length);
        GameObject newBullet = Instantiate(bullet);
        newBullet.GetComponent<BulletScript>().bulletdamage = damage;
        newBullet.transform.position = GunBarrels[random].gameObject.transform.position;
        newBullet.transform.rotation = this.transform.rotation;

    }
}
