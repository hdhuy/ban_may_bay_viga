using DG.Tweening;
using System;
using UnityEngine;

public class EnermyMove : Enermy
{
    private DOTweenPath mainPath;

    private bool isRotateToPath;

    public void Init(DOTweenPath _mainPath, bool _isRotateToPath)
    {
        mainPath = _mainPath;
        //additionPath = _additionPath;
        transform.position = mainPath.wps[0];
        isRotateToPath = _isRotateToPath;
        //gameObject.AddComponent< DOTweenPath>();
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
                    DeActivate();
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
                    DeActivate();
                };
        }

    }

    protected void ContinueAdditionPath()
    {
        //transform.DOPath(additionPath.wps.ToArray(), additionPath.duration, additionPath.pathType, PathMode.TopDown2D,
        //        additionPath.pathResolution)
        //    .SetOptions(additionPath.isClosedPath)
        //    .SetDelay(additionPath.delay)
        //    .SetLoops(additionPath.loops, additionPath.loopType)
        //    .SetSpeedBased(additionPath.isSpeedBased)
        //    .SetEase(additionPath.easeCurve);
    }

}
