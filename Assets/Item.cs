using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string ID;

    public void SetID(string id)
    {
        ID = id;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ItemLogger.Add(ID);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
