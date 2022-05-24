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
    private int counter = 5;

    public UnityEvent lifeChanged = new UnityEvent();
    public UnityEvent roundsChanged = new UnityEvent();
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
        SceneManager.LoadScene(2);
    }
    public void ToLoss()
    { 
        CollisionCounter();
        TOGameOver();
    }
     private void CollisionCounter(){
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
        if(maxLife == 0)
        {
            SceneManager.LoadScene(4);  
        }
    }
    
    public void ToWinLevelOne(){
        roundsPlayed = 1; 
        lifeChanged.Invoke();
        roundsChanged.Invoke();
        winLevelOne.Invoke();
    }
}
