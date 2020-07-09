using System;
using System.ComponentModel;
using UnityEngine;

public class EnermyHealth : Enermy
{
    [SerializeField]
    [ReadOnly(true)]
    protected int Blood;
    [SerializeField]
    protected int CurrentBlood;
    [SerializeField]
    protected ExplosionEffectType ExplosionType;
    
    private void Awake()
    {
        CurrentBlood = Blood;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            int dam = collision.GetComponent<Bullet>().damage;
            Transform exp = ObjectPutter.getInstance.PutObject(SpawnerType.VFXSpark, ObjectType.Effect);
            exp.position = collision.transform.position;
            BeHurt(dam);
            collision.gameObject.SetActive(false);
        }
    }
    public virtual void BeHurt(int dam)
    {
        CurrentBlood -= dam;
        if (CurrentBlood <= 0)
        {
            Transform explosion = null;
            switch (ExplosionType)
            {
                case ExplosionEffectType.SmallExplosion:
                    explosion = ObjectPutter.getInstance.PutObject(SpawnerType.SmallExplosion, ObjectType.Effect);
                    break;
                case ExplosionEffectType.MediumExplosion:
                    explosion = ObjectPutter.getInstance.PutObject(SpawnerType.MediumExplosion,ObjectType.Effect);
                    break;
            }
            explosion.position = transform.position;
            SpawnCoin();
            DeActivate();
        }
    }
    public virtual void SpawnCoin()
    {
        createCoin(SpawnerType.CoinNormal,new Vector2(0, 0));
    }
    protected void createCoin(SpawnerType type,Vector2 force)
    {
        Transform coin = ObjectPutter.getInstance.PutObject(type, ObjectType.Coin);
        coin.transform.position = transform.position;
        coin.GetComponent<Rigidbody2D>().AddForce(force);
    }
    public override void Reset()
    {
        base.Reset();
        CurrentBlood = Blood;
    }
    

}
