using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTower : MonoBehaviour
{
    public TextMeshProUGUI PopUpText;
    public Animator popupAnimation;
    private void Start()
    {
        InvokeRepeating("AddWaveMoney",0,Random.Range(0.9f, 1.2f));
        InvokeRepeating("PlayAnimation", 0, 0.25f);
    }
    
    public void AddWaveEndMoney()
    {
        FindObjectOfType<GameManager>().PlayerWealth += 100;
        FindObjectOfType<SoundManagerScript>().Play_Money_Sound(1, 2);
    }
    void AddWaveMoney()
    {
        int PopUpMoney;
        PopUpMoney = Random.Range(5, 35);
        FindObjectOfType<GameManager>().PlayerWealth += PopUpMoney;
        PopUpText.text = "+" + PopUpMoney;
        popupAnimation.Play("Money-PopUp");
        
    }
    void PlayAnimation()
    {
        popupAnimation.Play("Money-Animation");
    }
     
}
