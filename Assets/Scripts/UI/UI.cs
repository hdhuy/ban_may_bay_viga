using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject panel;
    public Text CoinText;
    private void Update()
    {
        //updateCoin();
    }
    public void updateCoin()
    {
        //int coin = PlayerPrefs.GetInt("coin");
        //string coinstr = coin + "";
        //CoinText.text = coinstr;
        CoinText.text = "xxx";
    }
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
