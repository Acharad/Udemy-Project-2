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

    public void StartGame()
    {
        StartCoroutine(StartGameAsync());
    }

    private IEnumerator StartGameAsync()
    {
        yield return null;
    }

    public void ReturnMenu()
    {
        
    }
}

