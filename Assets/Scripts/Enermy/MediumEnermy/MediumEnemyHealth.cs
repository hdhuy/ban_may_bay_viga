using UnityEngine;

public class MediumEnemyHealth : EnermyHealth
{
    public Transform healthBar;

    public Transform currentHealthBar;
    public override void SpawnCoin()
    {
        createCoin(SpawnerType.CoinNormal,new Vector2(15,0));
        createCoin(SpawnerType.CoinNormal,new Vector2(-15, 0));
        createCoin(SpawnerType.CoinHigh,new Vector2(0, 5));
    }
    public override void BeHurt(int bulletDamage)
    {
        if (!healthBar.gameObject.activeSelf)
        {
            healthBar.gameObject.SetActive(true);
            currentHealthBar.localScale = Vector3.one;
        }
        base.BeHurt(bulletDamage);
        if (CurrentBlood > 0)
        {
            currentHealthBar.localScale = new Vector3(CurrentBlood *0.01f, 1f, 1f);
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