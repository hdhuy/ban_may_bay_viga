using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnermyAttack : MonoBehaviour
{
    public Transform Mid;

    public Transform Left_1;

    public Transform Left_2;

    public Transform Left_3;

    public Transform Right_1;

    public Transform Right_2;

    public Transform Right_3;
    //[SerializeField]
    //private List<float> rotZ;
    private void OnEnable()
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
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium,ObjectType.Bullet);
        bullet1.rotation = transform.localRotation;
        bullet1.position = Left_2.position;//1

        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet2.rotation = transform.localRotation;
        bullet2.position = Left_3.position;//2

        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet3.rotation = transform.localRotation;
        bullet3.position = Right_2.position;//3

        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet4.rotation = transform.localRotation;
        bullet4.position = Right_3.position;//4

        bullet1.GetComponent<Bullet>().Activate();
        bullet2.GetComponent<Bullet>().Activate();
        bullet3.GetComponent<Bullet>().Activate();
        bullet4.GetComponent<Bullet>().Activate();
    }
    private void Shoot2()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium,ObjectType.Bullet);
        bullet1.position = Mid.position;//1 
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);

        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet2.position = Left_1.position;//2
        bullet2.rotation = Quaternion.Euler(0f, 0f, -10f);

        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet3.position = Left_3.position;//3
        bullet3.rotation = Quaternion.Euler(0f, 0f, -20f);

        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet4.position = Right_1.position;//4
        bullet4.rotation = Quaternion.Euler(0f, 0f, 10f);

        Transform bullet5 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet5.position = Right_3.position;//5
        bullet5.rotation = Quaternion.Euler(0f, 0f, 20f);

        bullet1.GetComponent<Bullet>().Activate();
        bullet2.GetComponent<Bullet>().Activate();
        bullet3.GetComponent<Bullet>().Activate();
        bullet4.GetComponent<Bullet>().Activate();
        bullet5.GetComponent<Bullet>().Activate();
    }
}
