using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 100;
    public int CurrentHealth;
    public GameObject HealthBar;
    private void Start()
    {
        CurrentHealth = Health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("EnermyBullet"))
        {
            int dam = collision.gameObject.GetComponent<Bullet>().damage;
            beHurt(dam);
            //eff
            Transform exp = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            exp.position = collision.transform.position;
            collision.gameObject.SetActive(false);
        }
        Debug.Log(collision.tag);
    }
    private void beHurt(int dam)
    {
        CurrentHealth -= dam;
        if (CurrentHealth <= 0)
        {
            Transform exp = ObjectPutter.Instance.PutObject(SpawnerType.PlayerExplosion);
            exp.position = transform.position;
            HealthBar.transform.localScale = new Vector3(0, 1, 1);
            Destroy(gameObject);
            if (GameObject.Find("UI") != null)
            {
                GameObject a = GameObject.Find("UI");
                a.GetComponent<UI>().showPanel(true);
            }
            else
            {
                Debug.Log("k tim thay");
            }
        }
        else
        {
            float scale = CurrentHealth * 0.01f;
            HealthBar.transform.localScale = new Vector3(scale, 1, 1);
        }
    }
}
