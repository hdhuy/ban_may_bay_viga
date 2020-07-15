using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public LevelTable levelTable;
    public Text messText;
    public Animator WhenWinGame;
    public GameObject Player;
    private int currentEnemyDestroy;

    private void Start()
    {
        StartCoroutine(CreateLevel());
        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
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
    public IEnumerator CreateLevel()
    {
        for (int i = 0; i < levelTable.waveList.Count; i++)
        {
            currentEnemyDestroy = 0;
            if(i== levelTable.waveList.Count - 1)
            {
                StartCoroutine(setUI("BOSS"));
            }
            else
            {
                int ii = i + 1;
                StartCoroutine(setUI("Wave " + ii));
            }
            LevelTable.Wave wave = levelTable.waveList[i];
            for (int j = 0; j < wave.orbitList.Count; j++)
            {
                StartCoroutine(SpawnEnemyOrbit(wave.orbitList[j]));
            }
            yield return new WaitUntil(() => (currentEnemyDestroy == wave.TotalEnemy));
        }
        StartCoroutine(Win());
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(3);
        WhenWinGame.enabled = true;
        WhenWinGame.SetBool("in", true);
        Player.GetComponent<PlayerMove>().isWin = true;
        Player.GetComponent<PlayerHealth>().enabled = false;
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
            case EnermyType.SmallEnermy:
                enemy = ObjectPutter.Instance.PutObject(SpawnerType.SmallEnermy, ObjectType.Enermy);
                break;
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