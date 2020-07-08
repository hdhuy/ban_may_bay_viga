using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Create SpawnerTable", fileName = "SpawnerTable")]
public class SpawnerTable : ScriptableObject
{
    [SerializeField] private List<SpawnerInfo> ListBullet;
    [SerializeField] private List<SpawnerInfo> ListEnermy;
    [SerializeField] private List<SpawnerInfo> ListEffect;
    [SerializeField] private List<SpawnerInfo> ListCoin;
    public SpawnerInfo GetSpawnerInfo(SpawnerType type, ObjectType a)
    {
        if (a==ObjectType.Bullet)
        {
            return ListBullet.FirstOrDefault(n => n.type == type);
        }
        else
        {
            if (a == ObjectType.Enermy)
            {
                return ListEnermy.FirstOrDefault(n => n.type == type);
            }
            else
            {
                if (a == ObjectType.Coin)
                {
                    return ListEnermy.FirstOrDefault(n => n.type == type);
                }
                else
                {
                    //effect
                    return ListEffect.FirstOrDefault(n => n.type == type);
                }
            }
        }
        
    }
}
