using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] List<EnemyCount> enemyCounts;

    private List<GameObject> spawnedEnemies = new List<GameObject>();   // �����ς݂̓G�̃��X�g

    // Start is called before the first frame update
    void Start()
    {
        // �����z�u
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
                // �G�𐶐����ă��X�g�ɒǉ�����
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
            // ���ꂪ���x���ɂȂ�
        }

        public ENEMY enemy;
        public List<Vector3> pos;
        public GameObject enemyPrefabs;
        public bool isSpawn;
    }
}
