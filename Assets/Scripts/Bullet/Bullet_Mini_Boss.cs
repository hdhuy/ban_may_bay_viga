using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mini_Boss : Bullet
{
    private Vector3 target;
    
    public override void Activate()
    {
        gameObject.SetActive(true);
        _rigidbody2D.velocity = transform.up * speed;
       StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(1);
        if (GameObject.Find("Player") != null)
        {
            _rigidbody2D.velocity = transform.up * 0;
            Transform t = GameObject.Find("Player").transform;
            target = t.position;
            //
            this.gameObject.transform.rotation = Quaternion.LookRotation(target);
            // and afterward, if you want to constrain the rotation to a particular axis- in this case Y:
            this.gameObject.transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.x + 90f);
            //
            _rigidbody2D.velocity = transform.up * speed;
        }
    }
}
