using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Save : MonoBehaviour
{

    public bool isStart;
    public async void Awake()
    {
        if (isStart)
        {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            LoadData();

            Invoke("GoToStartMenu", 5F);

        }
    }

    public async void SaveData()
    {
        var data = new Dictionary<string, object> 
        { 
            { "money", GameManager.money.ToString() }, 
            { "highScore", GameManager.highScore.ToString() },
            { "additional", Timer.additionalTime.ToString() }
        };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
    }

    public void GoToStartMenu()
    {
        SceneManager.LoadScene("StarterMenu");
    }

    public async void LoadData()
    {
        Dictionary<string, string> savedData = await CloudSaveService.Instance.Data.LoadAllAsync();
        GameManager.money = Convert.ToInt32(savedData["money"]);
        GameManager.highScore = Convert.ToInt32(savedData["highScore"]);
        Timer.additionalTime = Convert.ToInt32(savedData["additional"]);
    }
}
