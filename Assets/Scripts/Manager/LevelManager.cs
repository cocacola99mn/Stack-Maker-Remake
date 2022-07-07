using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    Scene m_Scene;
    string sceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public string getLevelName()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        string nextSceneName = SceneManager.GetSceneAt(currentIndex + 1).name;
        return nextSceneName;
    }*/
}
