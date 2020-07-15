using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    private Camera m_camera;

    private float speedMove = 0.5f;

    private Vector2 delta_position = Vector2.up * 0.5f;
    public bool isWin;
    public bool isMove=true;
    void Start()
    {
        m_camera = Camera.main;
    }
    private void Update()
    {
        if (isWin)
        {
            if (isMove)
            {
                StartCoroutine(WhenWin());
                isMove = false;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                transform.position = Vector3.MoveTowards(transform.position,
                (Vector2)m_camera.ScreenToWorldPoint(Input.mousePosition) + delta_position, speedMove);
            }
        }
    }
    IEnumerator WhenWin()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * 4;
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody2D>().velocity = transform.up * 0;
    }
}
