using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Create LevelTable", fileName = "LevelTable")]
public class LevelTable : ScriptableObject
{
    [Serializable]
    public class Wave
    {
        [SerializeField]
        public List<Orbit> orbitList;

        public int TotalEnemy
        {
            get { return orbitList.Sum(x => x.enemyNum); }
        }
    }

    [SerializeField]
    public List<Wave> waveList;
}
