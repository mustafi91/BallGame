using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinL1Controller : MonoBehaviour
{
    public void ToNextLevel()
    {
        GameManager.instance.StartLevelTwo();
    }

    public void QuiteGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
