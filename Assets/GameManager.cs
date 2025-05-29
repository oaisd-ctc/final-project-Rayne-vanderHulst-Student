using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void NextLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void End()
    {
        SceneManager.LoadScene(4);
    }
    
    
}
