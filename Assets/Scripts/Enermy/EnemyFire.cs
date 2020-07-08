using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;
    [SerializeField]
    private List<float> rotZ;
    void Start()
    {
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        Shoot1();
        yield return new WaitForSeconds(0.2f);
        Shoot1();
        yield return new WaitForSeconds(1);
        Shoot2();
        yield return new WaitForSeconds(0.2f);
        Shoot2();
        yield return new WaitForSeconds(2f);
        StartCoroutine(Fire());
    }
    private void Shoot1()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.BulletMedium);
        bullet1.rotation = transform.localRotation;
        bullet1.position = _listFirePoint[3].position;//1

        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.BulletMedium);
        bullet2.rotation = transform.localRotation;
        bullet2.position = _listFirePoint[2].position;//2

        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.BulletMedium);
        bullet3.rotation = transform.localRotation;
        bullet3.position = _listFirePoint[5].position;//3

        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.BulletMedium);
        bullet4.rotation = transform.localRotation;
        bullet4.position = _listFirePoint[6].position;//4

        bullet1.GetComponent<Bullet>().Activate();
        bullet2.GetComponent<Bullet>().Activate();
        bullet3.GetComponent<Bullet>().Activate();
        bullet4.GetComponent<Bullet>().Activate();
    }
    private void Shoot2()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.BulletMedium);
        bullet1.position = _listFirePoint[0].position;//1 
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);

        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.BulletMedium);
        bullet2.position = _listFirePoint[1].position;//2
        bullet2.rotation = Quaternion.Euler(0f, 0f, -10f);

        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.BulletMedium);
        bullet3.position = _listFirePoint[3].position;//3
        bullet3.rotation = Quaternion.Euler(0f, 0f, -20f);

        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.BulletMedium);
        bullet4.position = _listFirePoint[4].position;//4
        bullet4.rotation = Quaternion.Euler(0f, 0f, 10f);

        Transform bullet5 = ObjectPutter.Instance.PutObject(SpawnerType.BulletMedium);
        bullet5.position = _listFirePoint[6].position;//5
        bullet5.rotation = Quaternion.Euler(0f, 0f, 20f);

        bullet1.GetComponent<Bullet>().Activate();
        bullet2.GetComponent<Bullet>().Activate();
        bullet3.GetComponent<Bullet>().Activate();
        bullet4.GetComponent<Bullet>().Activate();
        bullet5.GetComponent<Bullet>().Activate();
    }
}
