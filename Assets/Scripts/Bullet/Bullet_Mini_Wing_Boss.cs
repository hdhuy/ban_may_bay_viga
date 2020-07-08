using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mini_Wing_Boss : Bullet
{
    public float rotSpeed;
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
