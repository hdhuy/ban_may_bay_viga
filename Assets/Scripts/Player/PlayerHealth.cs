using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100;
    public float CurrentHealth;
    public GameObject HealthBar;
    public GameObject Protect;
    private bool isProtecd;
    public UI ui;
    private void Start()
    {
        CurrentHealth = Health;
        StartCoroutine(protect());
    }
    IEnumerator protect()
    {
        Protect.SetActive(true);
        isProtecd = true;
        yield return new WaitForSeconds(3);
        Protect.SetActive(false);
        isProtecd = false;
    }
    public void beEnterTrigger(float dam)
    {
        BeHurt(dam);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnermyBullet"))
        {
            int dam = collision.gameObject.GetComponent<Bullet>().damage;
            BeHurt(dam);
            //eff
            Transform exp = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark, ObjectType.Effect);
            exp.position = collision.transform.position;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Enermy") || collision.CompareTag("Boss"))
        {
            BeHurt(1000);
            //eff
            Transform exp = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark, ObjectType.Effect);
            exp.position = collision.transform.position;
            if (collision.CompareTag("Enermy"))
            {
                collision.gameObject.GetComponent<BaseEnemy>().DecreaHealth(1000);
            }
        }
    }
    private void BeHurt(float dam)
    {
        if (CurrentHealth > 0)
        {
            if (!isProtecd)
            {
                CurrentHealth -= dam;
                if (CurrentHealth <= 0)
                {
                    Transform exp = ObjectPutter.Instance.PutObject(SpawnerType.PlayerExplosion, ObjectType.Effect);
                    exp.position = transform.position;
                    HealthBar.transform.localScale = new Vector3(0, 1, 1);
                    gameObject.SetActive(false);
                    WaitToReSpawn();
                }
                else
                {
                    float scale = CurrentHealth * 0.01f;
                    HealthBar.transform.localScale = new Vector3(scale, 1, 1);
                }
            }
        }

    }
    public void Reset()
    {
        gameObject.SetActive(true);
        CurrentHealth = 100;
        HealthBar.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(protect());
    }
    private void WaitToReSpawn()
    {
        Time.timeScale = 0.3f;
        ui.showWhenLose(true);
    }
}
