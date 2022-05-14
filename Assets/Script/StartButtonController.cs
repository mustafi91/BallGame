using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.StartLevelOne();
    }

    public void QuiteGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
