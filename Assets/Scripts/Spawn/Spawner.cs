using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] public SpawnerType SpawnerType;

    [SerializeField] private GameObject prefab;

    protected List<Transform> spawnList = new List<Transform>();

    public void Init(SpawnerType type, GameObject targetPrefab)
    {
        SpawnerType = type;
        prefab = targetPrefab;
    }

    protected virtual Transform Pop()
    {
        try
        {
            //tìm gobj chưa active
            Transform popTransform = (from p in spawnList where !p.gameObject.activeSelf select p).FirstOrDefault();
            //tìm được thì active
            if (popTransform != null)
            {
                popTransform.gameObject.SetActive(true);
                return popTransform;
            }
            //nếu không tìm đc thì tạo game obj mới
            GameObject popGameObject = Instantiate(prefab, transform);
            popGameObject.SetActive(true);
            spawnList.Add(popGameObject.transform);
            return popGameObject.transform;
        }
        catch (Exception e)
        {
            Debug.Log("Loi pop (spawne): " + e);
            return null;
        }
        
    }

    public Transform Spawn()
    {
        return Pop();

    }
}
