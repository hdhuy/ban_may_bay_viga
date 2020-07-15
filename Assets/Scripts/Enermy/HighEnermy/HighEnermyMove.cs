using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighEnermyMove : BaseEnemy
{
    public Transform healthBar;

    public Transform currentHealthBar;
    public override void SpawnCoin()
    {
        float r = Random.Range(13, 20);
        float r2 = Random.Range(5, 10);
        createCoin(SpawnerType.CoinNormal, new Vector2(r, r2));
        createCoin(SpawnerType.CoinNormal, new Vector2(-r2, r));
        createCoin(SpawnerType.CoinHigh, new Vector2(2, r2));
    }
    public override void DecreaHealth(int bulletDamage)
    {
        if (!healthBar.gameObject.activeSelf)
        {
            healthBar.gameObject.SetActive(true);
            currentHealthBar.localScale = Vector3.one;
        }
        base.DecreaHealth(bulletDamage);
        if (currentHealth > 0)
        {
            currentHealthBar.localScale = new Vector3(currentHealth * 0.01f, 1f, 1f);
        }
    }

    private void FixRotation()
    {
        healthBar.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void Update()
    {
        FixRotation();
    }
}
