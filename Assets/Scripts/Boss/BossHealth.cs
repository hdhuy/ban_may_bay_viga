using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : HealthManager 
{
    //public GameObject CurrentHealbar;
    //public bool isProtected=true;
    //public override void BeHurt(int dam)
    //{
    //    if (isProtected==false)
    //    {
    //        CurrentBlood -= dam;
    //        if (CurrentBlood <= 0)
    //        {
    //            Transform explosion = ObjectPutter.Instance.PutObject(SpawnerType.MediumExplosion, ObjectType.Effect);
    //            explosion.position = transform.position;
    //            SpawnCoin();
    //            gameObject.SetActive(false);
    //        }
    //        else
    //        {
    //            float scale = CurrentBlood *0.002f;
    //            CurrentHealbar.transform.localScale = new Vector3(scale, 1, 1);
    //        }
    //    }
    //}
    //public override void SpawnCoin()
    //{
    //    createCoin(SpawnerType.CoinHigh,new Vector2(15, 0));
    //    createCoin(SpawnerType.CoinHigh, new Vector2(-15, 0));
    //    createCoin(SpawnerType.CoinHigh, new Vector2(25, 0));
    //    createCoin(SpawnerType.CoinHigh, new Vector2(-25, 0));
    //    createCoin(SpawnerType.CoinHigh, new Vector2(0, 0));
    //    createCoin(SpawnerType.CoinHigh, new Vector2(0, 20));
    //}

}
