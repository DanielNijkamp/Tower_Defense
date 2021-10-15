using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TileScript : MonoBehaviour
{
    private bool checkedTower = false;
    public bool HasTower;
    public GameObject ShopCanvas;
    //public Button RapidFireButton, AoE_Button, SlowButton, MoneyButton, HealthButton, HighCalButton;

    public int RapidFireCost = 100, AoE_Cost = 500, SlowCost = 300, MoneyCost = 800, HealthCost = 1000, HighCalCost = 1000, AcidCost = 1200;

    public GameObject RapidFireTower, AoE_Tower, SlowTower, MoneyTower, HealthTower, High_Cal_Tower, Acid_Tower;

    private void Start()
    {
        FindObjectOfType<GameManager>().WealthText = GameObject.Find("CoinTextObject").GetComponent<TextMeshProUGUI>();

    }


    public void RapidPressed()
    {
        if (FindObjectOfType<GameManager>().PlayerWealth > 0 && FindObjectOfType<GameManager>().PlayerWealth - RapidFireCost >= 0)
        {
            GameObject newTower = Instantiate(RapidFireTower);
            newTower.transform.position = this.transform.position;

            FindObjectOfType<GameManager>().PlayerWealth -= RapidFireCost;

            this.HasTower = true;
            
        }
    }
    public void AoE_Pressed()
    {
        if (FindObjectOfType<GameManager>().PlayerWealth > 0 && FindObjectOfType<GameManager>().PlayerWealth - AoE_Cost >= 0)
        {
            GameObject newTower = Instantiate(AoE_Tower);
            newTower.transform.position = this.transform.position;

            FindObjectOfType<GameManager>().PlayerWealth -= AoE_Cost;

            this.HasTower = true;
            
        }
    }
    public void SlowPressed()
    {
        if (FindObjectOfType<GameManager>().PlayerWealth > 0 && FindObjectOfType<GameManager>().PlayerWealth - SlowCost >= 0)
        {
            GameObject newTower = Instantiate(SlowTower);
            newTower.transform.position = this.transform.position;

            FindObjectOfType<GameManager>().PlayerWealth -= SlowCost;

            this.HasTower = true;
        }
    }
    public void MoneyPressed()
    {
        if (FindObjectOfType<GameManager>().PlayerWealth > 0 && FindObjectOfType<GameManager>().PlayerWealth - MoneyCost >= 0)
        {
            GameObject newTower = Instantiate(MoneyTower);
            newTower.transform.position = this.transform.position;

            FindObjectOfType<GameManager>().PlayerWealth -= MoneyCost;

            this.HasTower = true;
        }
    }
    public void HealthPressed()
    {
        if (FindObjectOfType<GameManager>().PlayerWealth > 0 && FindObjectOfType<GameManager>().PlayerWealth - HealthCost >= 0)
        {
            GameObject newTower = Instantiate(HealthTower);
            newTower.transform.position = this.transform.position;

            FindObjectOfType<GameManager>().PlayerWealth -= HealthCost;

            this.HasTower = true;
        }
    }
    public void High_Cal_Pressed()
    {
        if (FindObjectOfType<GameManager>().PlayerWealth > 0 && FindObjectOfType<GameManager>().PlayerWealth - HighCalCost >= 0)
        {
            GameObject newTower = Instantiate(High_Cal_Tower);
            newTower.transform.position = this.transform.position;
            FindObjectOfType<GameManager>().PlayerWealth -= HighCalCost;
            this.HasTower = true;
            Physics2D.IgnoreCollision(newTower.GetComponent<CircleCollider2D>(), this.GetComponent<BoxCollider2D>(), true);
        }
    }
    public void Acid_Pressed()
    {
        if (FindObjectOfType<GameManager>().PlayerWealth > 0 && FindObjectOfType<GameManager>().PlayerWealth - AcidCost >= 0)
        {
            GameObject newTower = Instantiate(Acid_Tower);
            newTower.transform.position = this.transform.position;
            FindObjectOfType<GameManager>().PlayerWealth -= AcidCost;
            this.HasTower = true;
            Physics2D.IgnoreCollision(newTower.GetComponent<CircleCollider2D>(), this.GetComponent<BoxCollider2D>(), true);
        }
    }
    private void FixedUpdate()
    {
        if (this.HasTower && !checkedTower)
        {
            this.ShopCanvas.SetActive(false);
            FindObjectOfType<ClickManager>().i++;
            checkedTower = true;

        }
    }
    
    

}

    

