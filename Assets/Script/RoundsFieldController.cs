using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsFieldController : MonoBehaviour
{
    void Start()
    {
       GetComponent<Text>().text = GameManager.instance.roundsPlayed.ToString();
       GameManager.instance.roundsChanged.AddListener(UpdateText);
    }
    public void UpdateText()
    {
       GetComponent<Text>().text = GameManager.instance.roundsPlayed.ToString();
    }
}