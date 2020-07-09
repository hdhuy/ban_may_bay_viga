using System;
using System.Collections;
using UnityEngine;

public class Gun_Wave_Boss : BossGun
{
    private bool rotToPlayer;
    public float WaitShoot;
    public float RotSpeed;
    public float limit_1;
    public float limit_2;
    private Transform Player;
    private void Start()
    {
        StartCoroutine(Shoot());
    }
    private void Update()
    {
        if (ReadyToRotate())
        {
            Debug.Log(transform.name+"---"+ transform.eulerAngles.z);
            transform.rotation = RotToPlayer();
        }
    }
    private Quaternion RotToPlayer()
    {
        Vector2 dir = Player.position - transform.position;
        float angle = Mathf.Atan2(dir.x, -dir.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, RotSpeed * Vector3.forward);
        return Quaternion.Slerp(transform.rotation, rotation, RotSpeed * Time.deltaTime);
    }
    private bool ReadyToRotate()
    {
        if (GameObject.Find("Player") != null&& rotToPlayer)
        {
            Player = GameObject.Find("Player").transform;
            if (destroyed < 10 && Blood > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            //Debug.Log("khong tim thay player");
            return false;
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(5);
        if (destroyed == 10)
        {
            Blood = 100;
            isDead = false;
            HealthBarParent.SetActive(true);
            HealthBar.transform.localScale = new Vector3(1, 1, 1);
            StartCoroutine(Shoot2());
        }
        else
        {
            StartCoroutine(Reset());
        }
    }
    protected override void enterBullet(int dam)
    {
        if (isDead == false)
        {
            Blood -= dam;
            //hieu ung
            Transform vfx = ObjectPutter.getInstance.PutObject(SpawnerType.SmallExplosion, ObjectType.Effect);
            vfx.position = transform.position;
            if (Blood <= 0)
            {
                destroyed++;
                HealthBarParent.SetActive(false);
                checkBossLevel();
                Debug.Log(destroyed);
                isDead = true;
                StartCoroutine(Reset());
            }
            else
            {
                float scale = Blood * 0.01f;
                HealthBar.transform.localScale = new Vector3(scale, 1, 1);
            }
        }
    }
    IEnumerator Shoot()
    {
        rotToPlayer = false;
        createBullet();
        yield return new WaitForSeconds(WaitShoot);
        createBullet();
        yield return new WaitForSeconds(WaitShoot);
        createBullet();
        yield return new WaitForSeconds(WaitShoot);
        createBullet();
        rotToPlayer = true;
        yield return new WaitForSeconds(5f);
        if (destroyed < 10)
        {
            if (Blood > 0)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    IEnumerator Shoot2()
    {
        ShootRocket();
        yield return new WaitForSeconds(1f);
        StartCoroutine(Shoot2());
    }
    private void ShootRocket()
    {
        Transform bullet1 = ObjectPutter.getInstance.PutObject(SpawnerType.Bullet2_Wave_Boss,ObjectType.Bullet);
        bullet1.rotation = transform.localRotation;
        bullet1.position = FirePoint.position;//1
        bullet1.GetComponent<Rigidbody2D>().velocity = transform.up * 5;
        bullet1.GetComponent<Bullet>().Activate();
    }
    private void createBullet()
    {
        if (Blood > 0)
        {
            try
            {
                Transform a = ObjectPutter.getInstance.PutObject(SpawnerType.Bullet_Wave_Boss, ObjectType.Bullet);
                a.position = FirePoint.position;
                a.rotation = FirePoint.rotation;
                a.GetComponent<Bullet>().Activate();
            }
            catch (Exception e)
            {
                Debug.Log("Lỗi: " + e);
            }
        }
    }
}
