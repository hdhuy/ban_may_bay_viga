using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Swing_Boss : Gun_Parent_Boss
{
    private void Start()
    {
        StartCoroutine(ShootWing());
    }
    
    IEnumerator ShootWing()
    {
        if (Blood > 0)
        {
            yield return new WaitForSeconds(4);
            Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Wing_Boss);
            bullet1.rotation = FirePoint.rotation;
            bullet1.position = FirePoint.position;
            bullet1.GetComponent<Bullet>().Activate();
            StartCoroutine(ShootWing());
        }
        
    }
    
}
