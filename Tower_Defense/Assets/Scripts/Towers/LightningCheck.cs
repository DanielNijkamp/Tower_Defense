using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCheck : MonoBehaviour
{
    
    private float _damage;
    private int _chaincount;
    private int _maxchaincount;

    public GameObject AoE_TowerReference;
    public GameObject lightningBolt;
    public LayerMask layer;

    public List<GameObject> Hit_Enemies = new List<GameObject>();

    private void Start()
    {
        _maxchaincount = FindObjectOfType<AoETowerScript>().maxchaincount;
        Destroy(this.gameObject, FindObjectOfType<AoETowerScript>().timeBetweenShots);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, AoE_TowerReference.GetComponent<AoETowerScript>().radius, layer);
        foreach (Collider2D anEnemy in enemiesInRange)
        {
            if (anEnemy.CompareTag("Enemy") && !this.Hit_Enemies.Contains(anEnemy.gameObject) && this.Hit_Enemies.Count <= _maxchaincount)
            {
                this.Hit_Enemies.Add(anEnemy.gameObject);
            }
            
        }
    }
    private void Update()
    {
        layer = ~layer;
    }



}
