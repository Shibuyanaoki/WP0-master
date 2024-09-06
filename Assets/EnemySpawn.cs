using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] List<EnemyCount> enemyCounts;

    private List<GameObject> spawnedEnemies = new List<GameObject>();   // 生成済みの敵のリスト

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i <= 1; i++)
        {
            EnemyGenerator(enemyCounts[i]);
        }
    }

    private void EnemyGenerator(EnemyCount data)
    {
        if (data.isSpawn)
        {
            foreach (Vector3 p in data.pos)
            {
                // 敵を生成してリストに追加する
                GameObject enemyObj = Instantiate(data.enemyPrefabs, p, Quaternion.identity);
                spawnedEnemies.Add(enemyObj);
                enemyObj.SetActive(true);
            }
        }
    }

    public void SpawnEnemy()
    {
        SpawnEnemies();
    }

    public List<GameObject> GetSpawnedEnemies()
    {
        return spawnedEnemies;
    }

    [System.Serializable]
    public class EnemyCount
    {
        public enum ENEMY
        {
            Enemy1,
            Enemy2,
            Enemy3,
            Enemy4,
            Enemy5,
            Enemy6,
            // これがラベルになる
        }

        public ENEMY enemy;
        public List<Vector3> pos;
        public GameObject enemyPrefabs;
        public bool isSpawn;
    }
}
