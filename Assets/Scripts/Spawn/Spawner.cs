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
    public Transform Spawn()
    {
        return ReuseOrCreateNew();
    }
    protected virtual Transform ReuseOrCreateNew()
    {
        try
        {
            //tìm gobj chưa active
            Transform searching = (from p in spawnList where !p.gameObject.activeSelf select p).FirstOrDefault();
            //tìm được thì active
            if (searching != null)
            {
                searching.gameObject.SetActive(true);
                return searching;
            }
            //nếu không tìm đc thì tạo game obj mới
            GameObject popGameObject = Instantiate(prefab, transform);
            popGameObject.SetActive(true);
            spawnList.Add(popGameObject.transform);
            return popGameObject.transform;
        }
        catch (Exception e)
        {
            Debug.Log("Lỗi tái sử dụng và tạo mới: " + e);
            return null;
        }
        
    }

    
}
