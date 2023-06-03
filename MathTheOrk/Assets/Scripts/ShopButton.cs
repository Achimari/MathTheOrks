using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour, IButton
{

    public Shop shop;
    public void Press()
    {
        if (GameManager.money >= Shop.cost)
        {
            GameManager.money -= Shop.cost;
            Shop.cost += 1000;
            Timer.additionalTime += 100;
            shop.UpdateCost();
            shop.UpdateMoney();
            shop.UpdateTimerLvl();
        }
    }
}
