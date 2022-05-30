using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFieldController : MonoBehaviour
{
    void Start()
    {
       GetComponent<Text>().text = GameManager.instance.coinsNumber.ToString();
       GameManager.instance.scoreChanged.AddListener(UpdateText);
    }
    public void UpdateText()
    {
       GetComponent<Text>().text = GameManager.instance.coinsNumber.ToString();
    }
}
