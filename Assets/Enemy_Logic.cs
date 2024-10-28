using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Logic : MonoBehaviour
{

    public GameObject target;

    private NavMeshAgent agent;
   

    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            if (collision.transform.position.y - 1 >= this.transform.position.y)
            {
                Debug.Log("“¥‚Ü‚ê‚½");
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            agent.destination = target.transform.position;
        }
    }
}
