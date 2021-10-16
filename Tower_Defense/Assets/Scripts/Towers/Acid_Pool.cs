using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid_Pool : MonoBehaviour
{
    public GameObject Acid_Pool_Effect;
    public int Acid_Tick = 0;
    public bool Iscooldown;


    private void Start()
    {
        Acid_Pool_Effect.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Acid_Pool_Effect.SetActive(true);
    }
    IEnumerator IncreaseAcidTick()
    {
        Iscooldown = true;
        yield return new WaitForSeconds(1);
        Acid_Tick++;
        Iscooldown = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(this.transform.position, 1);
        foreach (Collider2D enemy in enemiesHit)
        {
            if (enemy.CompareTag("Enemy") && Acid_Tick < FindObjectOfType<AcidTowerScript>().Max_Acid_Tick)
            {
                enemy.GetComponent<Enemy>().TakeDamage(FindObjectOfType<AcidTowerScript>().damage);

            }
            

        }
        
    }
    private void Update()
    {
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
