using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid_Pool : MonoBehaviour
{
    public GameObject Acid_Pool_Effect;
    public int Acid_Tick = 0;
    public float Tick;
    public bool Iscooldown;
    public LayerMask layer;

    public List<GameObject> Hit_Enemies = new List<GameObject>();


    private void Start()
    {
        Acid_Pool_Effect.SetActive(false);
        if (this != null)
        {
            Destroy(gameObject, 5);
        }
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Acid_Pool_Effect.SetActive(true);

    }

    IEnumerator IncreaseAcidTick()
    {
        Iscooldown = true;
        yield return new WaitForSeconds(Tick);
        Acid_Tick++;
        Iscooldown = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(this.transform.position, FindObjectOfType<AcidTowerScript>().radius, layer);
        foreach (Collider2D enemy in enemiesHit)
        {
            if (enemy.CompareTag("Enemy") && !this.Hit_Enemies.Contains(enemy.gameObject) && Acid_Tick < FindObjectOfType<AcidTowerScript>().Max_Acid_Tick)
            {
                Hit_Enemies.Add(enemy.gameObject);
            }
        }

    }
    private void FixedUpdate()
    {
        foreach (GameObject enemy in Hit_Enemies)
        {
            if (enemy != null)
            {
                enemy.gameObject.GetComponent<Enemy>().TakeDamage(FindObjectOfType<AcidTowerScript>().damage);
            }
            if (Iscooldown == false)
            {
                StartCoroutine(IncreaseAcidTick());
            }
            if (Acid_Tick >= FindObjectOfType<AcidTowerScript>().Max_Acid_Tick)
            {
                Destroy(this.gameObject);
            }


        }
    }
}

