using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_HandV2_Boss : BossGun
{
    public ParticleSystem Fire;
    public float firstwait;
    public Transform Gun;
    private void Start()
    {
        StartCoroutine(FirstWait());
        HealthBarParent.SetActive(false);
        //StartCoroutine(FirePlay());
    }
    protected override void enterBullet(int dam)
    {
        if (isDead == false)
        {
            Blood -= dam;
            HealthBarParent.SetActive(true);
            //hieu ung
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion, ObjectType.Effect);
            vfx.position = transform.position;
            if (Blood <= 0)
            {
                destroyed++;
                HealthBarParent.SetActive(false);
                HealthBar.transform.localScale = new Vector3(0, 1, 1);
                checkBossLevel();
                isDead = true;
                GetComponent<Animator>().enabled = false;
                Gun.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                SmokeDead.Play();
            }
            else
            {
                float scale = Blood * 0.01f;
                HealthBar.transform.localScale = new Vector3(scale, 1, 1);
            }
        }
    }
    IEnumerator FirstWait()
    {
        yield return new WaitForSeconds(firstwait);
        StartCoroutine(FirePlay());
    }
    IEnumerator FirePlay()
    {
        Fire.Play();
        yield return new WaitForSeconds(3);
        Fire.Stop();
        yield return new WaitForSeconds(3);
        if (isDead==false)
        {
            StartCoroutine(FirePlay());
        }
    }
}
