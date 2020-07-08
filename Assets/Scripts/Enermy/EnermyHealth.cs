using System.ComponentModel;
using UnityEngine;

public class EnermyHealth : Enermy
{
    [SerializeField]
    [ReadOnly(true)]
    protected int Blood = 100;
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
            Reset();
        }
    }
    public virtual void SpawnCoin()
    {
        Transform coin = ObjectPutter.getInstance.PutObject(SpawnerType.CoinNormal, ObjectType.Coin);
        coin.transform.position = transform.position;
    }
    public override void Reset()
    {
        base.Reset();
        CurrentBlood = Blood;
    }

}
