using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : BaseEnemy
{
    private bool isProtected;
    public bool isLastState;
    public GameObject HealthBar;
    public GameObject HealthBarParent;
    public Animator ani;
    //----------------
    public GameObject gv1;
    public GameObject gv2;
    public void SetLevel2()
    {
        StartCoroutine(Level2());
    }
    public void SetLevel3()
    {
        ani.enabled = false;
        isProtected = false;
        isLastState = true;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        HealthBarParent.SetActive(true);
        gv1.SetActive(false);
        gv2.SetActive(false);
    }
    IEnumerator Level2()
    {
        isProtected = true;
        ani.enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(3);
        ani.SetBool("last", true);
        GetComponent<CircleCollider2D>().enabled = false;
    }
    
    public void SetLastFire()
    {
        isProtected = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public override void DecreaHealth(int bulletDamage)
    {
        if (isLastState)
        {
            if (!isProtected)
            {
                currentHealth -= bulletDamage;
            }
            if (currentHealth <= 0)
            {
                Transform explosion = ObjectPutter.Instance.PutObject(SpawnerType.MediumExplosion);
                explosion.position = transform.position;
                gameObject.SetActive(false);
                if (GameObject.Find("UI") != null)
                {
                    GameObject a = GameObject.Find("UI");
                    a.GetComponent<UI>().showPanel(true);
                }
                else
                {
                    Debug.Log("k tim thay");
                }
            }
            else
            {
                float scale = currentHealth * 0.01f;
                HealthBar.transform.localScale = new Vector3(scale / 5, 1, 1);
            }
        }
    }
}
