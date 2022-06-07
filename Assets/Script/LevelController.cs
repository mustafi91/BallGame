using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject PanalLoss;
    public GameObject PanalMain;
    public GameObject Player;

    void Start()
    {
        PanalLoss.SetActive(false);
        GameManager.instance.panalLoss.AddListener(PanalActiveLoss);
        LossController.panalMain.AddListener(PanalActiveMain);
     
    }

    public void PanalActiveLoss(){
        PanalLoss.SetActive(true);
        PanalMain.SetActive(false);
        Player.SetActive(false);
    }

    public void PanalActiveMain(){
        PanalLoss.SetActive(false);
        PanalMain.SetActive(true);
        Player.SetActive(true);
    }
}
