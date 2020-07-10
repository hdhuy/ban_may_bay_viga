using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public LevelTable levelTable;
    public Text messText;
    private int currentEnemyDestroy;

    private void Start()
    {
        StartCoroutine(CreateLevel());
    }
    IEnumerator setUI(string text)
    {
        messText.gameObject.SetActive(true);
        messText.text = text;
        yield return new WaitForSeconds(0.1f);
        messText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        messText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        messText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        messText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        messText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        messText.gameObject.SetActive(false);
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
                Debug.Log("xong wave " + 1);
            }
            yield return new WaitUntil(() => (currentEnemyDestroy == wave.TotalEnemy));
            int w = i + 1;
            string text = "WAVE " + w;
            if(i== levelTable.waveList.Count - 1)
            {
                text = "BOSS";
            }
            StartCoroutine(setUI(text));
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
                case EnermyType.Boss:
                    enemy = ObjectPutter.getInstance.PutObject(SpawnerType.Boss, ObjectType.Enermy);
                    break;
            }
            Debug.Log("kiem tra orbit"+orbit.enemyNum);
            EnermyMove em = enemy.GetComponent<EnermyMove>();
            em.Init(orbit.mainPath,orbit.isRotateToPath);
            if (enemy.GetComponent<EnermyHealth>() != null)
            {
                Debug.Log("health null");
            }
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