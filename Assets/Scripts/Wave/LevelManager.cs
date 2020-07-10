using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public LevelTable levelTable;
    public Text messText;
    public GameObject EndPanel;
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
    public int levelIndex=0;
    IEnumerator CreateLevel2()
    {
        yield return new WaitForSeconds(2);
        if (GameObject.FindGameObjectsWithTag("Enermy").Length == 0&& GameObject.FindGameObjectsWithTag("Boss").Length == 0)
        {
            int le = levelIndex + 1;
            string text = "WAVE " + le;
            if (levelIndex == levelTable.waveList.Count - 1)
            {
                text = "BOSS";
            }
            if (levelIndex == levelTable.waveList.Count)
            {
                text = "WIN";
                StartCoroutine(setUI(text));
                EndPanel.SetActive(true);
            }
            else
            {
                StartCoroutine(setUI(text));
                //
                LevelTable.Wave wave = levelTable.waveList[levelIndex];
                for (int j = 0; j < wave.orbitList.Count; j++)
                {
                    StartCoroutine(SpawnEnemyOrbit(wave.orbitList[j]));
                }
                levelIndex++;
            }
        }
        else
        {
            Debug.Log("count: " + GameObject.FindGameObjectsWithTag("Enermy").Length);
        }
        if(levelIndex < levelTable.waveList.Count)
        {
            StartCoroutine(CreateLevel2());
        }
        
    }
    public IEnumerator CreateLevel()
    {
        for (int i = 0; i < levelTable.waveList.Count; i++)
        {
            currentEnemyDestroy = 0;
            Debug.Log("bat dau wave: " + i);
            LevelTable.Wave wave = levelTable.waveList[i];
            for (int j = 0; j < wave.orbitList.Count; j++)
            {
                StartCoroutine(SpawnEnemyOrbit(wave.orbitList[j]));
            }
            Debug.Log("cho ...");
            yield return new WaitUntil(() => (currentEnemyDestroy == wave.TotalEnemy));
            Debug.Log("xong =>");
        }

    }

    public IEnumerator SpawnEnemyOrbit(Orbit orbit)
    {
        yield return new WaitForSeconds(orbit.timeStart);
        for (int i = 0; i < orbit.enemyNum; i++)
        {
            Transform enemy = createEnermy(orbit);

            BaseEnemy baseEnemy = enemy.GetComponent<BaseEnemy>();
            baseEnemy.Init(orbit.mainPath, orbit.additionPath, orbit.isRotateToPath);
            baseEnemy.OnEnemyDestroy += OnEnemyDestroyInWave;

            yield return new WaitForSeconds(orbit.timeDelay);
        }
    }
    private Transform createEnermy(Orbit orbit)
    {
        Transform enemy = null;
        switch (orbit.enemyType)
        {
            case EnermyType.LowEnermy:
                enemy = ObjectPutter.Instance.PutObject(SpawnerType.LowEnermy, ObjectType.Enermy);
                break;
            case EnermyType.MediumEnermy:
                enemy = ObjectPutter.Instance.PutObject(SpawnerType.MediumEnermy, ObjectType.Enermy);
                break;
            case EnermyType.HighEnermy:
                enemy = ObjectPutter.Instance.PutObject(SpawnerType.HighEnermy, ObjectType.Enermy);
                break;
            case EnermyType.Boss:
                enemy = ObjectPutter.Instance.PutObject(SpawnerType.Boss, ObjectType.Enermy);
                break;
        }
        return enemy;
    }
    private void OnEnemyDestroyInWave()
    {
        currentEnemyDestroy++;
    }

}