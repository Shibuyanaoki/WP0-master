using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Logic : MonoBehaviour
{
    //Player��Transform
    private Transform myTransform;

    //Player��Rigidbody
    public Rigidbody rig = null;

    //�d�͌��ƂȂ�f��
    private GameObject planet;

    //�uPlanet�v�^�O�����Ă���I�u�W�F�N�g���i�[����z��
    private GameObject[] planets;

    //�d�͂̋���
    public float Gravity;

    //�f���ɑ΂���Player�̌���
    private UnityEngine.Vector3 Direction;

    //Ray���ڐG�����f���̃|���S���̖@��
    private UnityEngine.Vector3 Normal_vec = new UnityEngine.Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody>();
        rig.constraints = RigidbodyConstraints.FreezeRotation;
        rig.useGravity = false;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Attract();
        RayTest();
    }

    public void Attract()
    {
        Vector3 gravityUp = Normal_vec;

        Vector3 bodyUp = myTransform.up;

        myTransform.GetComponent<Rigidbody>().AddForce(gravityUp * Gravity);

        Quaternion targetRotation = UnityEngine.Quaternion.FromToRotation(bodyUp, gravityUp) * myTransform.rotation;

        myTransform.rotation = UnityEngine.Quaternion.Lerp(myTransform.rotation, targetRotation, 120 * Time.deltaTime);
    }

    GameObject Choose_Planet()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");

        double[] planet_distance = new double[planets.Length];

        for(int i = 0; i < planets.Length; i++)
        {
            planet_distance[i] = Vector3.Distance(this.transform.position, planets[i].transform.position);
        }

        int min_index = 0;
        double min_distance = Mathf.Infinity;

        for (int j = 0; j < planets.Length; j++)
        {
            if (planet_distance[j] < min_distance)
            {
                min_distance = planet_distance[j];
                min_index = j;
            }
        }

        return planets[min_index];
    }

    void RayTest()
    {
        planet = Choose_Planet();

        Direction = planet.transform.position - this.transform.position;

        Ray ray = new Ray(this.transform.position, Direction);

        //Ray�����������I�u�W�F�N�g�̏������锠
        RaycastHit hit;

        //����Ray�ɃI�u�W�F�N�g���Փ˂�����
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Ray�����������I�u�W�F�N�g��tag��Planet��������
            if (hit.collider.tag == "Planet")
            {
                Normal_vec = hit.normal;
            }
        }
    }
}



