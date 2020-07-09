using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public event Action OnEnemyDestroy;
    public virtual void Reset()
    {
        gameObject.SetActive(true);
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
