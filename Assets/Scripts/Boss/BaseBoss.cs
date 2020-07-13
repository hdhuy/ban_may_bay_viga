using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoss : BaseEnemy
{
    public bool isProtected=true;
    public Transform healthBar;
    public Transform currentHealthBar;
    private void OnEnable()
    {
        setLevel_1();
    }
    public override void DecreaHealth(int bulletDamage)
    {
        base.DecreaHealth(bulletDamage);
        if (currentHealth > 0)
        {
            currentHealthBar.localScale = new Vector3(currentHealth * 0.001f, 1f, 1f);
        }
    }
    public override void onEnterPlayerBullet(Collider2D collision)
    {
        Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark, ObjectType.Effect);
        vfx.position = collision.transform.position;
        collision.gameObject.SetActive(false);
        if (!isProtected)
        {
            int dam = collision.GetComponent<Bullet>().damage;
            DecreaHealth(dam);
        }
    }
    public override void SpawnCoin()
    {
        createCoin(SpawnerType.CoinHigh, new Vector2(0, 0));
        createCoin(SpawnerType.CoinNormal, new Vector2(0, 5));
        createCoin(SpawnerType.CoinHigh, new Vector2(0, 10));

        createCoin(SpawnerType.CoinNormal, new Vector2(5, 0));
        createCoin(SpawnerType.CoinNormal, new Vector2(-5, 0));
        createCoin(SpawnerType.CoinHigh, new Vector2(5, 5));
        createCoin(SpawnerType.CoinHigh, new Vector2(-5, 5));

        createCoin(SpawnerType.CoinNormal, new Vector2(10, 0));
        createCoin(SpawnerType.CoinNormal, new Vector2(-10, 0));
        createCoin(SpawnerType.CoinNormal, new Vector2(10, 5));
        createCoin(SpawnerType.CoinNormal, new Vector2(-10, 5));

        createCoin(SpawnerType.CoinNormal, new Vector2(15, 0));
        createCoin(SpawnerType.CoinNormal, new Vector2(-15, 0));

        createCoin(SpawnerType.CoinNormal, new Vector2(20, 0));
        createCoin(SpawnerType.CoinNormal, new Vector2(-20, 0)) ;
    }
    public void setLevel_1()
    {
        healthBar.gameObject.SetActive(false);
        GetComponent<Animator>().SetInteger("next", 0);
        GetComponent<Animator>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    public void setLevel_2()
    {
        StartCoroutine(Changing());
    }
    public void setLevel_3()
    {
        //GetComponent<BossHealth>().isProtected = false;
        isProtected = false;
       GetComponent<Collider2D>().enabled = true;
        healthBar.gameObject.SetActive(true);
        GetComponent<Animator>().SetInteger("next", 1);
    }
    IEnumerator Changing()
    {
        GetComponent<Animator>().enabled = true;
        
        yield return new WaitForSeconds(5.1f);
        //GetComponent<Animator>().SetInteger("next", 1);
    }
}
