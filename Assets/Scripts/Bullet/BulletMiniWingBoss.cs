using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMiniWingBoss : Bullet
{
    public float rotSpeed;
    private void OnEnable()
    {
        transform.localEulerAngles = Vector3.zero;
    }
    void Update()
    {
        try
        {
            transform.Rotate(new Vector3(0, 0, rotSpeed));
        }
        catch (Exception e)
        {
            Debug.Log("Lỗi: " + e);
        }
        
    }
}
