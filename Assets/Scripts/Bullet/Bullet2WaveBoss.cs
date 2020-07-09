using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2WaveBoss : Bullet
{
    public Transform Target;
    public float RotSpeed;
    public bool isMoveToTarget;
    public GameObject Image;
    public bool isSpriteRot;
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
        if (isSpriteRot)
        {
            Image.transform.Rotate(0, 0, 3 * Time.deltaTime);
        }
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
    public override void Activate()
    {
        gameObject.SetActive(true);
        isMoveToTarget = false;
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        float s = speed * -1;
        speed = s*2.5f;
        yield return new WaitForSeconds(0.3f);
        speed = -s;
        isMoveToTarget = true;
        yield return new WaitForSeconds(3f);
        isMoveToTarget = false;
    }
}
