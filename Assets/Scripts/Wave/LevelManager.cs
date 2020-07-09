using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelTable levelTable;

    private int currentEnemyDestroy;

    private void Start()
    {
        StartCoroutine(CreateLevel());
    }

    public IEnumerator CreateLevel()
    {
        for (int i = 0; i < levelTable.waveList.Count; i++)
        {
            currentEnemyDestroy = 0;
            LevelTable.Wave wave = levelTable.waveList[i];
            for (int j = 0; j < wave.orbitList.Count; j++)
            {
                StartCoroutine(SpawnEnemyOrbit(wave.orbitList[j]));
            }
            yield return new WaitUntil(() => (currentEnemyDestroy == wave.TotalEnemy));
        }
    }

    public IEnumerator SpawnEnemyOrbit(Orbit orbit)
    {
        yield return new WaitForSeconds(orbit.timeStart);
        for (int i = 0; i < orbit.enemyNum; i++)
        {
            Transform enemy = null;
            switch (orbit.enemyType)
            {
                case EnermyType.LowEnermy:
                    enemy = ObjectPutter.getInstance.PutObject(SpawnerType.LowEnermy,ObjectType.Enermy);
                    break;
                case EnermyType.MediumEnermy:
                    enemy = ObjectPutter.getInstance.PutObject(SpawnerType.MediumEnermy, ObjectType.Enermy);
                    break;
                case EnermyType.HighEnermy:
                    enemy = ObjectPutter.getInstance.PutObject(SpawnerType.HighEnermy, ObjectType.Enermy);
                    break;
            }

            EnermyMove em = enemy.GetComponent<EnermyMove>();
            em.Init(orbit.mainPath,orbit.isRotateToPath);

            EnermyHealth eh = enemy.GetComponent<EnermyHealth>();
            eh.OnEnemyDestroy += OnEnemyDestroyInWave;
            em.OnEnemyDestroy += OnEnemyDestroyInWave;
            yield return new WaitForSeconds(orbit.timeDelay);
        }
    }

    private void OnEnemyDestroyInWave()
    {
        currentEnemyDestroy++;
    }

}