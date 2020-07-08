using System;
using System.Collections.Generic;
using DG.Tweening;

[Serializable]
public class Orbit
{
    public float timeStart;

    public float timeDelay;

    public EnemyType enemyType;

    public int enemyNum;

    public bool isRotateToPath;

    public DOTweenPath mainPath;

    public DOTweenPath additionPath;
}
