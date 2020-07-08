using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;

    [SerializeField]
    private List<ParticleSystem> _listFirePointEffect;

    private float fire_rate_weapon = 0.15f;


    private IEnumerator SpawnBullet()
    {
        createBullet(_listFirePoint[0], _listFirePointEffect[0]);
        createBullet(_listFirePoint[1], _listFirePointEffect[1]);
        createBullet(_listFirePoint[2], _listFirePointEffect[2]);
        createBullet(_listFirePoint[3], _listFirePointEffect[3]);
        yield return null;
    }
    private void createBullet(Transform t,ParticleSystem p)
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.PlayerBullet);
        bullet1.position = t.position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);
        bullet1.GetComponent<Bullet>().Activate();
        p.Play();
    }
    private IEnumerator StartFire()
    {
        yield return new WaitForSeconds(2.0f);
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