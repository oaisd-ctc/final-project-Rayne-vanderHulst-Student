using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{

    [SerializeField] private string GameButtonlevel = "level1";
   public void GameButton()
    {
        SceneManager.LoadScene(GameButtonlevel);
    }

}
