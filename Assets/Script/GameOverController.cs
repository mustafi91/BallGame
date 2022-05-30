using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void ReloadGame()
    {
        GameManager.instance.ReloadCurrentLevel();
    }

    public void PlayAgain()
    {
        GameManager.instance.StartLevelOne();
    }

    public void QuiteGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
