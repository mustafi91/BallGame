using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneController : MonoBehaviour
{

    public GameObject PanalWin;
    public GameObject PanalLoss;
    public GameObject PanalMain;


    // Start is called before the first frame update
    void Start()
    {
        PanalWin.SetActive(false);
        PanalLoss.SetActive(false);
        GameManager.instance.winLevelOne.AddListener(PanalActiveWin);
        GameManager.instance.panalLoss.AddListener(PanalActiveLoss);
        LossController.panalMain.AddListener(PanalActiveMain);
     
    }

    public void PanalActiveLoss(){
        PanalLoss.SetActive(true);
        PanalMain.SetActive(false);
    }

    public void PanalActiveMain(){
        PanalLoss.SetActive(false);
        PanalMain.SetActive(true);
    }

    public void PanalActiveWin(){
        PanalWin.SetActive(true);
        PanalMain.SetActive(false);
    }
}
