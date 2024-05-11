using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public GameObject transition;

    public void doExitGame() 
    {
        Application.Quit();
    }

    public void goMainMenu()
    {
        transition.GetComponent<SceneTransitionManager>().GoToScene(0);
    }
}
