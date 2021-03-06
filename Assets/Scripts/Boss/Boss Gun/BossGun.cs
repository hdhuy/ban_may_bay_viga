﻿
using UnityEngine;

public class BossGun : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject HealthBarParent;
    public Transform FirePoint;
    public int Blood = 100;
    public static int destroyed = 0;
    public ParticleSystem SmokeDead;
    protected bool isDead;
    protected static bool isStatus2;
    //static
    private void OnEnable()
    {
        Blood = 100;
        isDead = false;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            int dam = collision.GetComponent<Bullet>().damage;
            enterBullet(dam);
        }

    }
    protected virtual void enterBullet(int dam)
    {
        if (isDead == false)
        {
            Blood -= dam;
            if (HealthBarParent)
            {
                HealthBarParent.SetActive(true);
            }
            //hieu ung
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion, ObjectType.Effect);
            vfx.position = transform.position;
            if (Blood <= 0)
            {
                destroyed++;
                if (HealthBarParent)
                {
                    HealthBarParent.SetActive(false);
                }
                checkBossLevel();
                Debug.Log(destroyed);
                isDead = true;
                Transform smoke = ObjectPutter.Instance.PutObject(SpawnerType.MediumExplosion, ObjectType.Effect);
                smoke.position = FirePoint.position;
                SmokeDead.Play();
            }
            else
            {
                if (HealthBar)
                {
                    float scale = Blood * 0.01f;
                    HealthBar.transform.localScale = new Vector3(scale, 1, 1);
                }
            }
        }
    }
    protected void checkBossLevel()
    {
        if (GameObject.FindGameObjectsWithTag("Boss").Length > 0)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            if (destroyed == 10)
            {
                boss.GetComponent<BaseBoss>().setLevel_2();
                isStatus2 = true;
            }
            if (destroyed == 14)
            {
                boss.GetComponent<BaseBoss>().setLevel_3();
                destroyed = 0;
            }
        }
        else
        {
            Debug.Log("Khong tim thay boss");
        }
    }
}
