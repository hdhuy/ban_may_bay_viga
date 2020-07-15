using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    [SerializeField]
    protected float speed = 12f;
    //
    public int damage;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    public virtual void Activate()
    {
        _rigidbody2D.velocity = transform.up * speed;
        //transform.localRotation = Quaternion.Euler(0,0,0);
    }
}
