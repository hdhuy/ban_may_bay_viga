﻿using System.Collections.Generic;
using UnityEngine;

public class ObjectPutter : SingletonMonoBehaviour<ObjectPutter>
{
    [SerializeField] private SpawnerTable table;//prefabs đã tạo

    private Dictionary<SpawnerType, Spawner> spawnerDict = new Dictionary<SpawnerType, Spawner>();

    private void Awake()
    {
        base.Awake();
        //nếu không có prefabs thì tim trong folders
        if (table == null)
        {
            table = Resources.Load("SpawnerTable") as SpawnerTable;
        }
    }

    public Transform PutObject(SpawnerType type)
    {
        return Spawn(type);
    }

    private Transform Spawn(SpawnerType type)
    {
        //nếu spawner dict không tại type và không có spawner info thì return
        if (!HasSpawner(type) && !CreateSpawner(type))
        {
            return null;
        }
        //tạo transforn mới
        Transform transform = spawnerDict[type].Spawn();
        return transform;
    }

    private bool CreateSpawner(SpawnerType type)//tạo game chứa 
    {
        //lấy spawner info từ prefab
        SpawnerInfo spawnerInfo = table.GetSpawnerInfo(type);
        //kiểm tra null
        if (spawnerInfo == null)
        {
            Debug.LogError("error. hasn't " + type + " in spawner table");
            return false;
        }
        //Tạo game mới để chứa các game obj được tạo theo loại
        GameObject spawnerObject = new GameObject(spawnerInfo.prefab.name + "Spawner");
        //đặt game obj cha
        spawnerObject.transform.SetParent(transform);
        spawnerObject.transform.localPosition = Vector3.zero;
        //add spawner script
        spawnerObject.AddComponent<Spawner>();
        //đặt spawner type và prefabs của các game obj sắp tạo
        spawnerObject.GetComponent<Spawner>().Init(type, spawnerInfo.prefab);
        //thêm vào dictionary
        spawnerDict.Add(type, spawnerObject.GetComponent<Spawner>());
        return true;
    }

    private bool HasSpawner(SpawnerType key)
    {
        return spawnerDict.ContainsKey(key);
    }
}
