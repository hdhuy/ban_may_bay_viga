using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    [SerializeField]
    protected float speed = 12f;

    protected Collider2D _collider2D;
    //
    public int damage;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
    }

    public virtual void Activate()
    {
        _rigidbody2D.velocity = transform.up * speed;
    }
    protected void OnTriggerEnter2D(Collider2D enemy)
    {
        if (transform.tag.Equals("PlayerBullet"))
        {
            if (enemy.tag.Equals("Enermy")|| enemy.tag.Equals("Boss"))
            {
                enemy.GetComponent<BaseEnemy>().DecreaHealth(damage);
                Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
                vfx.position = transform.position;
                gameObject.SetActive(false);
            }
        }
    }
}
