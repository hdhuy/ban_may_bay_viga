using DG.Tweening;
using System;
using UnityEngine;

public class EnermyMove : Enermy
{
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
        MoveByDOTween();
    }
    public virtual void MoveByDOTween()
    {
        //nếu xoay theo path
        if (isRotateToPath)
        {
            //cac thuoc tinh DO
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
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        ContinueAdditionPath();
                    }
                };
            //--cac thuoc tinh DO
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
                        gameObject.SetActive(false);
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
    
    
}
