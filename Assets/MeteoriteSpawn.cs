using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawn : MonoBehaviour
{

    [SerializeField] List<MeteoriteCount> MeteoriteCounts;

    private List<GameObject> meteorite = new List<GameObject>();   

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置
        SpawnMeteorites();
    }

    private void SpawnMeteorites()
    {
        for (int i = 0; i <= 1; i++)
        {
            EnemyGenerator(MeteoriteCounts[i]);
        }
    }

    private void EnemyGenerator(MeteoriteCount data)
    {
        if (data.isSpawn)
        {
            foreach (Vector3 p in data.pos)
            {
                // 敵を生成してリストに追加する
                GameObject meteoriteObj = Instantiate(data.meteoritePrefabs, p, Quaternion.identity);
                meteorite.Add(meteoriteObj);
                meteoriteObj.SetActive(true);
            }
        }
    }

    public void SpawnEnemy()
    {
        SpawnMeteorites();
    }

    public List<GameObject> GetSpawnedEnemies()
    {
        return meteorite;
    }


    [System.Serializable]
    public class MeteoriteCount
    {
        public enum METEORITE
        {
            Meteorite1,
            Meteorite2,
            Meteorite3,
            Meteorite4,
            Meteorite5,
            Meteorite6,
            // これがラベルになる
        }

        public METEORITE meteorite;
        public List<Vector3> pos;
        public GameObject meteoritePrefabs;
        public bool isSpawn;
    }
}
