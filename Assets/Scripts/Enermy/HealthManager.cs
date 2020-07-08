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

    public virtual void DecreaHealth(int bulletDamage)
    {
    }
    public virtual void SpawnCoin()
    {
    }
}
