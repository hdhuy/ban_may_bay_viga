using System.Collections.Generic;
using UnityEngine;

public class ObjectPutter : SingletonMonoBehaviour<ObjectPutter>
{
    [SerializeField] private SpawnerTable table;//prefabs đã tạo

    private Dictionary<SpawnerType, Spawner> spawnerDict = new Dictionary<SpawnerType, Spawner>();

    protected override void Awake()
    {
        base.Awake();
        //nếu không có prefabs thì tim trong folders
        if (table == null)
        {
            table = Resources.Load("SpawnerTable") as SpawnerTable;
        }
    }

    public Transform PutObject(SpawnerType type,ObjectType objt)
    {
        return Spawn(type,objt);
    }

    private Transform Spawn(SpawnerType type, ObjectType objt)
    {
        //nếu spawner dict không tại type và không có spawner info thì return
        if (!HasSpawner(type) && !CreateSpawner(type, objt))
        {
            return null;
        }
        //tạo transforn mới
        Transform transform = spawnerDict[type].Spawn();
        return transform;
    }

    private bool CreateSpawner(SpawnerType type,ObjectType objt)//tạo game chứa 
    {
        //lấy spawner info từ prefab
        SpawnerInfo spawnerInfo = table.GetSpawnerInfo(type, objt);
        //kiểm tra null
        if (spawnerInfo == null)
        {
            Debug.LogError("Không tìm thấy " + type + " trong Spawner Table");
            return false;
        }
        //Tạo game obj mới để chứa các game obj được tạo theo loại
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
