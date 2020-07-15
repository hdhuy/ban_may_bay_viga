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
    private bool changed;
    public float BulletRotSpeed;
    //
    private bool first;
    private void OnEnable()
    { 
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        rotToPlayer = true;
        first = true;
    }
    IEnumerator firstWait()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(Shoot());
    }
    private void Update()
    {
        if (ReadyToRotate())
        {
            Quaternion q = RotToPlayer();
            if (q.eulerAngles.z > limit_1 && q.eulerAngles.z < limit_2)
            {
                transform.rotation = q;
                if (first)
                {
                    StartCoroutine(firstWait());
                    first = false;
                }
            }
        }
        if (destroyed == 10&&changed==false)
        {
            StartCoroutine(Reset());
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
        if (Player!= null && rotToPlayer)
        {
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
        if (isDead == true && changed == false)
        {
            changed = true;
            Blood = 100;
            isDead = false;
            HealthBar.transform.localScale = new Vector3(1, 1, 1);
            StartCoroutine(Shoot2());
        }
    }
    protected override void enterBullet(int dam)
    {
        if (isDead == false)
        {
            Blood -= dam;
            if (changed == true)
            {
                HealthBarParent.SetActive(true);
            }
            //hieu ung
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion, ObjectType.Effect);
            vfx.position = transform.position;
            if (Blood <= 0)
            {
                destroyed++;
                HealthBarParent.SetActive(false);
                checkBossLevel();
                isDead = true;
                SmokeDead.Play();
                rotToPlayer = false;
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
        if (destroyed < 10 && Blood > 0)
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
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot2()
    {
        if (Blood > 0)
        {
            createRocketCircle();
            yield return new WaitForSeconds(1f);
            StartCoroutine(Shoot2());
        }
    }
    private void createRocketCircle()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet2_Wave_Boss, ObjectType.Bullet);
        bullet1.rotation = transform.localRotation;
        bullet1.position = FirePoint.position;//1
        bullet1.GetComponent<Rigidbody2D>().velocity = transform.up * 5;
        bullet1.GetComponent<Bullet>().Activate();
        bullet1.GetComponent<Bullet2WaveBoss>().RotSpeed = BulletRotSpeed;
    }
    private void createBullet()
    {
        if (Blood > 0)
        {
            try
            {
                Transform a = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Wave_Boss, ObjectType.Bullet);
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
