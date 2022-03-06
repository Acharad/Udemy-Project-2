using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    
    public GameManager Instance { get; private set; }

    private void Awake() 
    {
        SingeltonThisObject();
    }

    private void SingeltonThisObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
            Destroy(this.gameObject);
    }

    public void SplashScreen()
    {
        StartCoroutine(SplashScreenAsync());
    }
    
    private IEnumerator SplashScreenAsync()
    {
        yield return SceneManager.LoadSceneAsync("SplashScreen");

        yield return new WaitForSeconds(3f);
        
        StartGame();
    }
    
    public void StartGame()
    {
        StartCoroutine(StartGameAsync());
    }

    private IEnumerator StartGameAsync()
    {
        yield return SceneManager.LoadSceneAsync("Game");
    }

    public void ReturnMenu()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

