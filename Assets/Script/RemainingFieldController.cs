using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RemainingFieldController : MonoBehaviour
{

    void Start()
    {
       GetComponent<Text>().text = GameManager.instance.maxLife.ToString();
       GameManager.instance.lifeChanged.AddListener(UpdateText);
    }
    public void UpdateText()
    {
       GetComponent<Text>().text = GameManager.instance.maxLife.ToString();
    }
}
