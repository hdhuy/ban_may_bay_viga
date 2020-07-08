﻿using System;
using UnityEngine;

[Serializable]
public class SpawnerInfo
{
    [SerializeField] public string Name;
    [SerializeField] public SpawnerType type;

    [SerializeField] public GameObject prefab;
}
