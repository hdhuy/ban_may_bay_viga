using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerScript : MonoBehaviour
{
    public bool isFire;
    private void Start()
    {
        StartCoroutine(fire());
    }
    IEnumerator fire()
    {
        yield return new WaitForSeconds(0.2f);
        if (isFire)
        {
            createBullet();
        }
        StartCoroutine(fire());
    }
    private void createBullet()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Fire_Bullet, ObjectType.Bullet);
        bullet1.position = transform.position;
        bullet1.rotation = transform.localRotation;
        bullet1.GetComponent<Bullet>().Activate();
    }
}