using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Player
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
            BeHurt(dam);
            //eff
            Transform exp = ObjectPutter.getInstance.PutObject(SpawnerType.VFXSpark, ObjectType.Effect);
            exp.position = collision.transform.position;
            collision.gameObject.SetActive(false);
        }
    }
    private void BeHurt(int dam)
    {
        CurrentHealth -= dam;
        if (CurrentHealth <= 0)
        {
            Transform exp = ObjectPutter.getInstance.PutObject(SpawnerType.PlayerExplosion, ObjectType.Effect);
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
                Debug.Log("Không tìm thấy UI");
            }
        }
        else
        {
            float scale = CurrentHealth * 0.01f;
            HealthBar.transform.localScale = new Vector3(scale, 1, 1);
        }
    }
}
