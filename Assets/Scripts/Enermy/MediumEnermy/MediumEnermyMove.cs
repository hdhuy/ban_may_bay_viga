using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MediumEnermyMove : BaseEnemy 
{
    // Start is called before the first frame update
    public Transform healthBar;

    public Transform currentHealthBar;
    private void OnEnable()
    {
        StartCoroutine(Look());
    }
    IEnumerator Look()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;
            float z = 20;
            if (player.x == transform.position.x)
            {
                z = 0;
            }
            else
            {
                if (player.x < transform.position.x)
                {
                    z = -20;
                }
            }
            transform.DORotate(new Vector3(0, 0, z), 1);
            yield return new WaitForSeconds(1);
            StartCoroutine(Look());
        }
        else
        {
            Debug.Log("k tim thay player");
        }
        
    }
    public override void SpawnCoin()
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
