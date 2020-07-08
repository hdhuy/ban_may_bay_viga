using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Gun_Parent_Boss : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject HealthBarParent;
    public Transform FirePoint;
    public int Blood = 100;
    //static
    public static int destroyed;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            if (Blood > 0)
            {
                int dam = collision.GetComponent<Bullet>().damage;
                Blood -= dam;
                if (Blood <= 0)
                {
                    Transform vfx = ObjectPutter.getInstance.PutObject(SpawnerType.SmallExplosion, ObjectType.Effect);
                    vfx.position = transform.position;
                    destroyed++;
                    HealthBarParent.SetActive(false);
                    if (GameObject.FindGameObjectsWithTag("Boss").Length>0)
                    {
                        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
                        if (destroyed == 10)
                        {
                            boss.GetComponent<Boss>().SetLevel2();
                        }
                        if (destroyed == 12)
                        {
                            boss.GetComponent<Boss>().SetLevel3();
                        }
                    }
                    
                }
                else
                {
                    float scale = Blood * 0.01f;
                    HealthBar.transform.localScale = new Vector3(scale, 1, 1);
                }

            }
        }
        
    }
}
