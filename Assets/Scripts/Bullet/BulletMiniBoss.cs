using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMiniBoss : Bullet
{
    public override void Activate()
    {
        gameObject.SetActive(true);
        _rigidbody2D.velocity = transform.up * speed;
       StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(.5f);
        if (GameObject.FindGameObjectsWithTag("Player").Length>0)
        {
            Transform t = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 dir = t.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            _rigidbody2D.velocity = transform.up * 0;
            yield return new WaitForSeconds(.5f);
            //đẩy về phía player
            _rigidbody2D.velocity = transform.up * speed;
        }
    }
}
