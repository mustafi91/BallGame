using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private static int nextScene = 1;
    private bool freeze = false;
    private bool gameOver = false;
    private bool endLevel = false;
    private bool waterLoss = false;
    private bool frontGround = false;
    private bool backGround =  false;
    private bool lossToPosition = false;
    public float maxLife;
    public float roundsPlayed;
    public UnityEvent lifeChanged = new UnityEvent();
    public UnityEvent roundsChanged = new UnityEvent();
    
    public bool Freeze{
        get
        {
            return this.freeze;
        }
        set
        {
            this.freeze = value;
        }
    }
    public bool WaterLoss{
        get
        {
            return this.waterLoss;
        }
        set
        {
            this.waterLoss = value;
        }
    }
    public bool FrontGround{
        get
        {
            return this.frontGround;
        }
        set
        {
            this.frontGround = value;
        }
    }
    public bool BackGround{
        get
        {
            return this.backGround;
        }
        set
        {
            this.backGround = value;
        }
    }
    public bool LossToPosition{
        get
        {
            return this.lossToPosition;
        }
        set
        {
            this.lossToPosition = value;
        }
    }
    public bool GameOver{
        get
        {
            return this.gameOver;
        }
        set
        {
            this.gameOver = value;
        }
    }
      public bool EndLevel{
        get
        {
            return this.endLevel;
        }
        set
        {
            this.endLevel = value;
        }
    }

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
        maxLife = 10f;
        roundsPlayed = 0f;
        SceneManager.LoadScene(2);
    }

    public void ToReplayLevelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void StartLevelTwo()
    {
        SceneManager.LoadScene(3);
    }

    public void TOGameOver(){
  
        gameOver = true;
    }
    public void GameOverLevelTwo(){
  
         SceneManager.LoadScene(4);
    }

    public void ToWinLevelOne(){
        ++roundsPlayed; 
        lifeChanged.Invoke();
        roundsChanged.Invoke();
    }

     public void ToWinLevelTwo(){
        ++roundsPlayed;
        SceneManager.LoadScene(4);
    }

    public void ToLoss()
    {
        --maxLife; 
        lifeChanged.Invoke();
       
        if(maxLife == 0 && !endLevel)
        {
            TOGameOver();  
        }
        else if(maxLife == 0 && endLevel)
        {
            GameOverLevelTwo();
        }
        else if (WaterLoss)
        {    
            Freeze = true;
            WaterLoss = false; 
        }
        else if (LossToPosition)
        {
            LossToPosition = false;
        }
    }
}
