using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D _collider2D;

    private float groundVerticalLength; //chieu cao cua 1 background

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        groundVerticalLength = _collider2D.size.y;
    }

    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(0f, groundVerticalLength * 2);
        transform.position = (Vector2)transform.position + groundOffSet;
    }

    private void Update()
    {
        if (transform.position.y < -groundVerticalLength)
        {
            RepositionBackground();
        }
    }

}
