using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletdamage;
    [SerializeField] private float bulletLifeTime;
    private void Start()
    {
        
    }
    void Update()
    {
        this.transform.position += transform.right * bulletSpeed * Time.deltaTime;
        if (this != null)
        {
            Destroy(gameObject, bulletLifeTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletdamage);
            Destroy(gameObject, 0.2f);
        }
        else
        {

        }
    }
    
}
