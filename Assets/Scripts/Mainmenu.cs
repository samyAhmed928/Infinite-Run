using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{



    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
