//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnermyAttack : MonoBehaviour
//{
//    [SerializeField]
//    private List<Transform> ListFirepoint;
//    [SerializeField]
//    private List<float> rotZ;
//    void Start()
//    {
//        StartCoroutine(Fire());
//    }
//    IEnumerator Fire()
//    {
//        Shoot1();
//        yield return new WaitForSeconds(0.2f);
//        Shoot1();
//        yield return new WaitForSeconds(1);
//        Shoot2();
//        yield return new WaitForSeconds(0.2f);
//        Shoot2();
//        yield return new WaitForSeconds(2f);
//        StartCoroutine(Fire());
//    }
//    private void Shoot1()
//    {
//        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium);
//        bullet1.rotation = transform.localRotation;
//        bullet1.position = ListFirepoint[3].position;//1

//        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium);
//        bullet2.rotation = transform.localRotation;
//        bullet2.position = ListFirepoint[2].position;//2

//        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium);
//        bullet3.rotation = transform.localRotation;
//        bullet3.position = ListFirepoint[5].position;//3

//        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium);
//        bullet4.rotation = transform.localRotation;
//        bullet4.position = ListFirepoint[6].position;//4

//        bullet1.GetComponent<Bullet>().Activate();
//        bullet2.GetComponent<Bullet>().Activate();
//        bullet3.GetComponent<Bullet>().Activate();
//        bullet4.GetComponent<Bullet>().Activate();
//    }
//    private void Shoot2()
//    {
//        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium);
//        bullet1.position = ListFirepoint[0].position;//1 
//        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);

//        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium);
//        bullet2.position = ListFirepoint[1].position;//2
//        bullet2.rotation = Quaternion.Euler(0f, 0f, -10f);

//        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium);
//        bullet3.position = ListFirepoint[3].position;//3
//        bullet3.rotation = Quaternion.Euler(0f, 0f, -20f);

//        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium);
//        bullet4.position = ListFirepoint[4].position;//4
//        bullet4.rotation = Quaternion.Euler(0f, 0f, 10f);

//        Transform bullet5 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium);
//        bullet5.position = ListFirepoint[6].position;//5
//        bullet5.rotation = Quaternion.Euler(0f, 0f, 20f);

//        bullet1.GetComponent<Bullet>().Activate();
//        bullet2.GetComponent<Bullet>().Activate();
//        bullet3.GetComponent<Bullet>().Activate();
//        bullet4.GetComponent<Bullet>().Activate();
//        bullet5.GetComponent<Bullet>().Activate();
//    }
//}
