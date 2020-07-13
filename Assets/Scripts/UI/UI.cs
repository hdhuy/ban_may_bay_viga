using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject panel;
    public GameObject Player;
    public GameObject WhenPlayerDie;
    public Button btn50coin;
    public Text TextCoin;
    //
    public GameObject Pause;
    private void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public void continu()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
    }
    public void pause()
    {
        Time.timeScale = 0;
        Pause.SetActive(true);
    }
    public void liveWith50coin()
    {
        int coin = PlayerPrefs.GetInt("coin");
        coin -= 50;
        PlayerPrefs.SetInt("coin", coin);
        setPlayerLive();
        TextCoin.text = coin.ToString();
    }
    public void setPlayerLive()
    {
        Player.GetComponent<PlayerHealth>().Reset();
        Time.timeScale = 1;
        WhenPlayerDie.SetActive(false);
    }
    public void loadThisScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void exit()
    {
        Application.Quit(0);
    }
    public void showPanel(bool s)
    {
        panel.SetActive(s);
        int coin = PlayerPrefs.GetInt("coin");
        if (coin >= 50)
        {
            btn50coin.interactable = true;
        }
        else
        {
            btn50coin.interactable = false;
        }
    }
}
