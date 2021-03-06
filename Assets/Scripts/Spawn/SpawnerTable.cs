﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Create SpawnerTable", fileName = "SpawnerTable")]
public class SpawnerTable : ScriptableObject
{
    public List<SpawnerInfo> ListBullet;
    public List<SpawnerInfo> ListEnermy;
    public List<SpawnerInfo> ListEffect;
    public List<SpawnerInfo> ListCoin;
    public SpawnerInfo GetSpawnerInfo(SpawnerType type, ObjectType a)
    {
        switch (a)
        {
            case ObjectType.Bullet:
                return ListBullet.FirstOrDefault(n => n.type == type);
            case ObjectType.Enermy:
                return ListEnermy.FirstOrDefault(n => n.type == type);
            case ObjectType.Coin:
                return ListCoin.FirstOrDefault(n => n.type == type);
            case ObjectType.Effect:
                return ListEffect.FirstOrDefault(n => n.type == type);
            default: return ListEffect.FirstOrDefault(n => n.type == type);
        }
    }
}
