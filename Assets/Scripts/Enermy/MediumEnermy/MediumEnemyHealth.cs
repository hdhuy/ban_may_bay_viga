using UnityEngine;

public class MediumEnemyHealth : BaseEnemy
{
    public Transform healthBar;

    public Transform currentHealthBar;
    protected override void SpawnCoin()
    {
        createCoin(SpawnerType.CoinNormal, new Vector2(15, 0));
        createCoin(SpawnerType.CoinNormal, new Vector2(-15, 0));
        createCoin(SpawnerType.CoinHigh, new Vector2(0, 5));
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