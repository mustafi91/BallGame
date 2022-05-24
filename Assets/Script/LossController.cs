using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LossController : MonoBehaviour
{
    public static UnityEvent panalMain = new UnityEvent();

    public void ToReturnLevel()
    {
        GameManager.instance.StartLevelOne();
    }
     public void ToWeiter()
    {
        panalMain.Invoke();
    }
}
