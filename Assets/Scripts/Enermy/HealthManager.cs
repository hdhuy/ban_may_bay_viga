using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    [ReadOnly(true)]
    protected int health = 100;
    [SerializeField]
    protected int currentHealth;

    private void Awake()
    {
        currentHealth = health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            onEnterPlayerBullet(collision);
        }
    }
    public virtual void onEnterPlayerBullet(Collider2D collision)
    {
        Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark, ObjectType.Effect);
        vfx.position = collision.transform.position;
        collision.gameObject.SetActive(false);
        int dam = collision.GetComponent<Bullet>().damage;
        DecreaHealth(dam);
    }
    public virtual void DecreaHealth(int bulletDamage)
    {
    }

}
