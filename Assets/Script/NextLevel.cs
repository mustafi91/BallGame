using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public void LoadNextLevel()
    {
        GameManager.instance.LoadNextLevel();
    }
    public void ReloadLevel()
    {
        GameManager.instance.ReloadCurrentLevel();
    }
    public void QuiteGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

}