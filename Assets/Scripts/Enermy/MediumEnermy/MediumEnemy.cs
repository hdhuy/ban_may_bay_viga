//using UnityEngine;

//public class MediumEnemy : EnermyMove
//{
//    [SerializeField]
//    private Transform healthBar;

//    [SerializeField]
//    private Transform currentHealthBar;
//    public override void SpawnCoin()
//    {
//        Transform coin1 = ObjectPutter.Instance.PutObject(SpawnerType.CoinHigh);
//        Transform coin2 = ObjectPutter.Instance.PutObject(SpawnerType.CoinNormal);
//        Transform coin3 = ObjectPutter.Instance.PutObject(SpawnerType.CoinNormal);
//        coin1.transform.position = transform.position;
//        coin2.transform.position = transform.position;
//        coin3.transform.position = transform.position;
//        coin2.GetComponent<Rigidbody2D>().AddForce(new Vector2(15,0));
//        coin3.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15, 0));
//    }
//    public override void DecreaHealth(int bulletDamage)
//    {
//        if (!healthBar.gameObject.activeSelf)
//        {
//            healthBar.gameObject.SetActive(true);
//            currentHealthBar.localScale = Vector3.one;
//        }
//        base.DecreaHealth(bulletDamage);
//        if (currentHealth > 0)
//        {
//            currentHealthBar.localScale = new Vector3((float)currentHealth / health, 1f, 1f);
//        }
//    }

//    private void FixRotation()
//    {
//        healthBar.rotation = Quaternion.Euler(0f, 0f, 0f);
//    }

//    private void Update()
//    {
//        FixRotation();
//    }
//}