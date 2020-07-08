using DG.Tweening;
using System;
using UnityEngine;

public class BaseEnemy : HealthManager
{
    [SerializeField]
    private ExplosionEffectType explosionType;
    //path chính
    private DOTweenPath mainPath;
    //path phụ
    private DOTweenPath additionPath;
    //xoay theo path
    private bool isRotateToPath;
    public void Init(DOTweenPath _mainPath, DOTweenPath _additionPath, bool _isRotateToPath)
    {
        mainPath = _mainPath;
        additionPath = _additionPath;
        transform.position = mainPath.wps[0];
        isRotateToPath = _isRotateToPath;
        StartMove();
    }
    public virtual void StartMove()
    {
        //nếu xoay theo path
        if (isRotateToPath)
        {
            transform.DOPath(mainPath.wps.ToArray(), mainPath.duration, mainPath.pathType, PathMode.TopDown2D, mainPath.pathResolution)
                .SetOptions(mainPath.isClosedPath)
                .SetDelay(mainPath.delay)
                .SetLoops(mainPath.loops, mainPath.loopType)
                .SetSpeedBased(mainPath.isSpeedBased)
                .SetLookAt(0f, Vector3.forward, Vector3.left)
                .SetEase(mainPath.easeCurve)
                .onComplete += delegate
                {
                    if (!additionPath)
                    {
                        DeActivate();
                    }
                    else
                    {
                        ContinueAdditionPath();
                    }
                };
        }
        else
        {
            transform.DOPath(mainPath.wps.ToArray(), mainPath.duration, mainPath.pathType, PathMode.TopDown2D, mainPath.pathResolution)
                .SetOptions(mainPath.isClosedPath)
                .SetDelay(mainPath.delay)
                .SetLoops(mainPath.loops, mainPath.loopType)
                .SetSpeedBased(mainPath.isSpeedBased)
                .SetEase(mainPath.easeCurve)
                .onComplete += delegate
                {
                    if (!additionPath)
                    {
                        DeActivate();
                    }
                    else
                    {
                        ContinueAdditionPath();
                    }
                };
        }

    }
    //path bổ sung
    protected void ContinueAdditionPath()
    {
        transform.DOPath(additionPath.wps.ToArray(), additionPath.duration, additionPath.pathType, PathMode.TopDown2D,
                additionPath.pathResolution)
            .SetOptions(additionPath.isClosedPath)
            .SetDelay(additionPath.delay)
            .SetLoops(additionPath.loops, additionPath.loopType)
            .SetSpeedBased(additionPath.isSpeedBased)
            .SetEase(additionPath.easeCurve);
    }
   //spawner
    protected virtual void DeActivate()
    {
        gameObject.SetActive(false);
        OnDeActivate();
    }
    public event Action OnEnemyDestroy;

    protected virtual void OnDeActivate()
    {
        if (OnEnemyDestroy != null)
        {
            OnEnemyDestroy();
            OnEnemyDestroy = null;
        }
    }
    //health manager
    public override void DecreaHealth(int bulletDamage)
    {
        currentHealth -= bulletDamage;
        if (currentHealth <= 0)
        {
            DeActivate();
            Transform explosion = null;
            switch (explosionType)
            {
                case ExplosionEffectType.SmallExplosion:
                    explosion = ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion);
                    break;
                case ExplosionEffectType.MediumExplosion:
                    explosion = ObjectPutter.Instance.PutObject(SpawnerType.MediumExplosion);
                    break;
            }
            explosion.position = transform.position;
            SpawnCoin();
            Reset();
        }
    }
    public override void SpawnCoin()
    {
        Transform coin = ObjectPutter.Instance.PutObject(SpawnerType.CoinNormal);
        coin.transform.position = transform.position;
    }

    protected void Reset()
    {
        currentHealth = 100;
        transform.DOKill();
    }

    

}
