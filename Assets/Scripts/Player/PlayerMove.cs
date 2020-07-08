using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : Player
{
    private Camera m_camera;

    private float speedMove = 0.5f;

    private Vector2 delta_position = Vector2.up * 0.5f;
    void Start()
    {
        m_camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.MoveTowards(transform.position,
            (Vector2)m_camera.ScreenToWorldPoint(Input.mousePosition) + delta_position, speedMove);
        }
        
    }
}
