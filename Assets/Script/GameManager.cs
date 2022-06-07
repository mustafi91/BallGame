using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private static int nextScene = 1;
    public float maxLife;
    public float roundsPlayed;
    public float coinsNumber;
    private int counter = 5;

    public UnityEvent lifeChanged = new UnityEvent();
    public UnityEvent roundsChanged = new UnityEvent();
    public UnityEvent scoreChanged = new UnityEvent();
    public UnityEvent winLevelOne = new UnityEvent();
    public UnityEvent panalLoss = new UnityEvent();
    
    public static void Load()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }

    public void Awake() {
       if (instance == null)
       {
            instance = this;  
            DontDestroyOnLoad(gameObject);
       } 
       SceneManager.LoadScene(1);
    }
    public void StartLevelOne()
    {
        maxLife = 3f;
        roundsPlayed = 0f;
        coinsNumber = 0f;
        SceneManager.LoadScene(3);
    }

    public void StartLevelTwo()
    {
        SceneManager.LoadScene(3);
    }

    public void ReloadCurrentLevel()
    {
        --roundsPlayed; 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (roundsPlayed == 1)
        {
            SceneManager.LoadScene(currentSceneIndex+2);  
        }
        else if (roundsPlayed == 2)
        {
            SceneManager.LoadScene(currentSceneIndex+3); 
        }
    }

    public void ToLoss()
    { 
        CollisionCounter();
        if (maxLife == 0)
        {
            TOGameOver();    
        }
    }

    private void CollisionCounter()
    {
        --counter;
        if (counter == 0)
        {
            --maxLife;
            counter = 5;
            panalLoss.Invoke();
            lifeChanged.Invoke();
        }
    }
    public void TOGameOver(){
        SceneManager.LoadScene(6); 
        lifeChanged.Invoke();
        roundsChanged.Invoke();
        scoreChanged.Invoke(); 
    }
    
    public void ToWinLevel(){
        ++roundsPlayed; 
        lifeChanged.Invoke();
        roundsChanged.Invoke();
        scoreChanged.Invoke(); 
        SceneManager.LoadScene(2); 
    }

    public void CollectionOfManey()
    {
        ++coinsNumber;
        scoreChanged.Invoke();
    }
}
