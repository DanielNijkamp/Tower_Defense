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

    private GameObject CurrentTower;

    private int CurrentTowerCost;
    private int CurrentTowerSellAmount;
    private float UpgradeAmount;

    public GameObject ShopCanvas;
    public GameObject SellCanvas;

    public TextMeshProUGUI selltext;
    public TextMeshProUGUI upgradetext;

    private int Tower_Tier;
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
            this.CurrentTower = newTower;
            this.CurrentTowerCost = RapidFireCost;
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
            this.CurrentTower = newTower;
            this.CurrentTowerCost = AoE_Cost;
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
            this.CurrentTower = newTower;
            this.CurrentTowerCost = SlowCost;
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
            this.CurrentTower = newTower;
            this.CurrentTowerCost = MoneyCost;
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
            this.CurrentTower = newTower;
            this.CurrentTowerCost = HealthCost;
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
            this.CurrentTower = newTower;
            this.CurrentTowerCost = HighCalCost;
            FindObjectOfType<GameManager>().PlayerWealth -= HighCalCost;
            this.HasTower = true;
            
        }
    }
    public void Acid_Pressed()
    {
        if (FindObjectOfType<GameManager>().PlayerWealth > 0 && FindObjectOfType<GameManager>().PlayerWealth - AcidCost >= 0)
        {
            GameObject newTower = Instantiate(Acid_Tower);
            newTower.transform.position = this.transform.position;
            this.CurrentTower = newTower;
            this.CurrentTowerCost = AcidCost;
            FindObjectOfType<GameManager>().PlayerWealth -= AcidCost;
            this.HasTower = true;
            
        }
    }
    public void Sell_Tower()
    {
        Destroy(CurrentTower);
        this.HasTower = false;
        checkedTower = false;
        this.SellCanvas.SetActive(false);
        FindObjectOfType<GameManager>().PlayerWealth += CurrentTowerCost / 2;
        FindObjectOfType<ClickManager>().i++;
    }
    public void Upgrade_Tower()
    {
        //UpgradeAmount = CurrentTowerCost * 1.5f;
        //FindObjectOfType<GameManager>().PlayerWealth -= Mathf.RoundToInt(UpgradeAmount);
        Tower_Tier++;
        switch (Tower_Tier)
        {
            case 1:
                print("upgrade tier should be 1, is :" + Tower_Tier);
                break;
            case 2:
                print("upgrade tier should be 2, is :" + Tower_Tier);
                break;
            case 3:
                print("upgrade tier should be 3, is :" + Tower_Tier);
                break;
            case 4:
                print("upgrade tier should be 4, is :" + Tower_Tier);
                break;
            case 5:
                print("upgrade tier should be 5, is :" + Tower_Tier);
                break;
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
    private void Update()
    {
        selltext.text = this.CurrentTowerSellAmount + "";
        upgradetext.text = this.UpgradeAmount + "";
    }



}

    

