using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidTowerScript : MonoBehaviour
{
    public float damage;
    public float timeBetweenShots;
    private float NextTimeToShoot;

    
    private GameObject currentTarget;

    public List<GameObject> Acid_Nearby = new List<GameObject>();

    public int radius;
    public int Max_Acid_Tick;

    GameObject currentEnemy;

    public GameObject Acid_Pool_Prefab;
    private GameObject Acid_Pool;


    public bool hasShot = false;
    private void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Acid_Nearby.Add(collision.gameObject);             
        }
    }
   
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Acid_Nearby.Remove(collision.gameObject);
            if (Acid_Nearby.Count == 0)
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
            var offset = 0f;
            Vector3 dir = currentTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 3 * Time.deltaTime);
        }
        
    }
    private void updateNearestEnemy()
    {
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in Acid_Nearby)
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
        
        Acid_Pool = Instantiate(Acid_Pool_Prefab);
        Acid_Pool.transform.position = currentTarget.transform.position;
        hasShot = true;
        yield return new WaitForSeconds(2f);
        hasShot = false;

    }
}
