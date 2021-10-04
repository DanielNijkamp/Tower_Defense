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
    public Button RapidFireButton, AoE_Button, SlowButton, MoneyButton, HealthButton;

    public int RapidFireCost = 100, AoE_Cost = 500, SlowCost = 300, MoneyCost = 800, HealthCost = 1000;

    public GameObject RapidFireTower, AoE_Tower, SlowTower, MoneyTower, HealthTower;

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

    

