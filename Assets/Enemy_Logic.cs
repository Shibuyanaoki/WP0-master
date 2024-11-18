using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Logic : MonoBehaviour
{

    public GameObject target;
    public NavMeshAgent agent;
    public float distance;

    // Start is called before the first frame update
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
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
    private void Update()
    {
        distance = Vector3.Distance(transform.position, this.transform.position);
        Debug.Log(distance);

        if(distance < 5)
        {
            agent.destination = target.transform.position;
        }

    }

}
