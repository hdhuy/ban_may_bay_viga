using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public virtual void Reset()
    {
        gameObject.SetActive(true);
    }
}
