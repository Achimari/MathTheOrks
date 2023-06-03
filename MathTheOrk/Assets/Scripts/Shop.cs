using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text costText;
    public Text moneyText;
    public Text timeLvlText;

    public static int cost = 5000;

    public void UpdateCost()
    {
        costText.text = $"Cost: {cost}";
    }
    
    public void UpdateTimerLvl()
    {
        timeLvlText.text = $"Addition time lvl: {Timer.additionalTime / 100}";
    }

    public void UpdateMoney()
    {
        moneyText.text = $"Your money: {GameManager.money}";
    }

    void Start()
    {
        UpdateCost();
        UpdateMoney();
        UpdateTimerLvl(); 
    }
}
