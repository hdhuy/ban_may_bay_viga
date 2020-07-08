using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet_Wave_Boss : Bullet
{
    public float MaxScale;
    public float ChangePerFrame;
    private void Update()
    {
        if (transform.localScale.x<MaxScale)
        {
            Vector3 scale = transform.localScale;
            scale.x += ChangePerFrame;
            scale.y += ChangePerFrame;
            transform.localScale = new Vector3(scale.x, scale.y, 1);
        }
    }
    public override void Activate()
    {
        gameObject.SetActive(true);
        transform.localScale = new Vector3(.5f,.5f, 1);
        _rigidbody2D.velocity = transform.up * speed;
    }
}
