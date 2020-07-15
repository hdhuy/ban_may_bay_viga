using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void loadlevel()
    {
        SceneManager.LoadScene(1);
    }
    public void exit()
    {
        Application.Quit(0);
    }
}
