﻿using DG.Tweening;
using System;
using UnityEngine;

public class BaseEnemy : HealthManager
{
    public event Action OnEnemyDestroy;

    private DOTweenPath mainPath;

    private DOTweenPath additionPath;

    private bool isRotateToPath;
    public ExplosionEffectType explosionType;

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
                    explosion = ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion, ObjectType.Effect);
                    break;
                case ExplosionEffectType.MediumExplosion:
                    explosion = ObjectPutter.Instance.PutObject(SpawnerType.MediumExplosion, ObjectType.Effect);
                    break;
            }
            explosion.position = transform.position;
            SpawnCoin();
            Reset();
        }
    }
    public virtual void SpawnCoin()
    {
        SpawnerType type = SpawnerType.CoinNormal;
        float f = UnityEngine.Random.Range(-25, 25);
        Debug.Log(f);
        Vector2 force = new Vector2(f,0);
        createCoin(type,force);
    }
    protected void createCoin(SpawnerType type,Vector2 force)
    {
        Transform coin = ObjectPutter.Instance.PutObject(type, ObjectType.Coin);
        coin.position = transform.position;
        coin.GetComponent<Rigidbody2D>().AddForce(force);
    }
    public void Reset()
    {
        currentHealth = health;
        transform.DOKill();
    }
    protected virtual void DeActivate()
    {
        gameObject.SetActive(false);
        OnDeActivate();
    }

    protected virtual void OnDeActivate()
    {
        if (OnEnemyDestroy != null)
        {
            OnEnemyDestroy();
            OnEnemyDestroy = null;
        }
    }


}
