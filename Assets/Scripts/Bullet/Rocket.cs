using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Rocket : Bullet
{
    public Transform Target;
    public float RotSpeed;
    public bool isMoveToTarget;
    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            Target = null;
        }
    }
    private void FixedUpdate()
    {
        if (Target != null)
        {
            if (isMoveToTarget)
            {
                Vector2 direction = Target.position - transform.position;
                direction.Normalize();
                float rotateAmount = Vector3.Cross(direction, transform.up).z;
                _rigidbody2D.angularVelocity = -rotateAmount * RotSpeed;
            }
            else
            {
                _rigidbody2D.angularVelocity = 0;
            }
        }
        _rigidbody2D.velocity = transform.up * speed;
    }
    public override void  Activate()
    {
        gameObject.SetActive(true);
        isMoveToTarget = false;
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        yield return new WaitForSeconds(0.3f);
        isMoveToTarget = true;
        yield return new WaitForSeconds(3f);
        isMoveToTarget = false;
    }
}
