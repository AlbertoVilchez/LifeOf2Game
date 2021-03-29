using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiArm : MonoBehaviour
{

    public LayerMask targetMask;
    public float viewRadius;
    public Collider[] targetsRadius;

    GameObject Target;
    public GameObject CameraMain;
    public GameObject UIButton;
    // Start is called before the first frame update
    void Start()
    {
        CameraMain = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        targetsRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        

        for (int i = 0; i < targetsRadius.Length;i++)
        {

            if (targetsRadius[i].gameObject.tag == "Player")
            {
                Target = targetsRadius[i].gameObject;

                Target.GetComponent<GetArm>().Arma = gameObject;
                UIButton.SetActive(true);
            }
            
        }


        if (targetsRadius.Length == 0 )
        {
            UIButton.SetActive(false);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,viewRadius);
    }
}
