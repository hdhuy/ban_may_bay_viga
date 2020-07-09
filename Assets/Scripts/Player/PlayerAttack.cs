using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player
{
    [SerializeField]
    private float BulletSpeed;
    [SerializeField]
    private List<Transform> ListFirepoint;

    [SerializeField]
    private List<ParticleSystem> ListShootEffect;

    private float fire_rate_weapon = 0.15f;


    private IEnumerator SpawnBullet()
    {
        createBullet(ListFirepoint[0], ListShootEffect[0],.5f);
        createBullet(ListFirepoint[1], ListShootEffect[1],-.5f);
        createBullet(ListFirepoint[2], ListShootEffect[2],1.5f);
        createBullet(ListFirepoint[3], ListShootEffect[3],-1.5f);
        yield return null;
    }
    private void createBullet(Transform t,ParticleSystem p,float z)
    {
        Transform bullet1 = ObjectPutter.getInstance.PutObject(SpawnerType.PlayerBullet, ObjectType.Bullet);
        bullet1.position = t.position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, z);
        bullet1.GetComponent<Bullet>().Activate();
        p.Play();
    }
    private IEnumerator StartFire()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(fire_rate_weapon);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartFire());
    }

}