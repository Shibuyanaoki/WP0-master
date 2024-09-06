using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] List<ItemCount> enemyCounts;

    private List<GameObject> spawnedItem = new List<GameObject>();   // �����ς݂̓G�̃��X�g

    private Item item;

    // Start is called before the first frame update
    void Start()
    {

        this.item = FindObjectOfType<Item>(); // �C���X�^���X��

        // �����z�u
        SpawnItems();
    }

    private void SpawnItems()
    {
        for (int i = 0; i < 5; i++)
        {
            ItemGenerator(enemyCounts[i]);
        }
    }

    private void ItemGenerator(ItemCount data)
    {
        if (data.isSpawn)
        {
            foreach (Vector3 p in data.pos)
            {
                // �G�𐶐����ă��X�g�ɒǉ�����
                GameObject itemObj = Instantiate(data.itemPrefabs, p, data.rot);
                spawnedItem.Add(itemObj);
                this.item = FindObjectOfType<Item>(); // �C���X�^���X��
                item.SetID(data.ID);
                itemObj.SetActive(true);
            }
        }
    }

    public void SpawnItem()
    {
        SpawnItems();
    }

    public List<GameObject> GetSpawnedItem()
    {
        return spawnedItem;
    }

    [System.Serializable]
    public class ItemCount
    {
        public enum Item
        {
            Item0,
            Item1,
            Item2,
            Item3,
            Item4,
            Item5,
            // ���ꂪ���x���ɂȂ�
        }

        public Item item;
        public List<Vector3> pos;
        public Quaternion rot;
        public GameObject itemPrefabs;
        public string ID;
        public bool isSpawn;
    }
}
