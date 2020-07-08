using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject panel;
    public void loadThisScene()
    {
        SceneManager.LoadScene(0);
    }
    public void exit()
    {
        Application.Quit(0);
    }
    public void showPanel(bool s)
    {
        panel.SetActive(s);
    }
}
