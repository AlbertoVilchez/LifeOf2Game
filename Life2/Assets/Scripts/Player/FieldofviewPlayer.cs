using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
public class FieldofviewPlayer : MonoBehaviour
{
    public float viewRadius;
    public float ViewAngle;
    [SerializeField] LayerMask TargetMask;

    public List<Transform> VisibleTarget = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        FinVisiblePlayer(); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void FinVisiblePlayer()
    {
        VisibleTarget.Clear();
        Collider[] TargetRadius = Physics.OverlapSphere(transform.position,viewRadius,TargetMask);

        for (int i = 0; i < TargetRadius.Length;i++)
        {
            Transform target = TargetRadius[i].transform;
            Vector3 DirreTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, DirreTarget) < ViewAngle / 2)
            {
                float EnterTarget = Vector3.Distance(transform.position, target.position);

                if (Physics.Raycast(transform.position,DirreTarget,EnterTarget,TargetMask))
                {
                    VisibleTarget.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleDeg, bool global)
    {
        if (!global)
        {
            angleDeg += transform.eulerAngles.z;
        }

        return new Vector3(Mathf.Sin(angleDeg * Mathf.Deg2Rad),0,Mathf.Cos(angleDeg * Mathf.Deg2Rad));
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, viewRadius);

    }*/
}
