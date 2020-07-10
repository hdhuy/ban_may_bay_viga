using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BossGun : BaseBoss
{
    public GameObject HealthBar;
    public GameObject HealthBarParent;
    public Transform FirePoint;
    public int Blood = 100;
    public static int destroyed = 0;
    protected bool isDead;
    //static
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
            //hieu ung
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion, ObjectType.Effect);
            vfx.position = transform.position;
            if (Blood <= 0)
            {
                destroyed++;
                HealthBarParent.SetActive(false);
                checkBossLevel();
                Debug.Log(destroyed);
                isDead = true;
            }
            else
            {
                float scale = Blood * 0.01f;
                HealthBar.transform.localScale = new Vector3(scale, 1, 1);
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
            }
            if (destroyed == 14)
            {
                boss.GetComponent<BaseBoss>().setLevel_3();
            }
        }
        else
        {
            Debug.Log("Khong tim thay boss");
        }
    }
}
