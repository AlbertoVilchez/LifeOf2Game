using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ControllerEnemy : MonoBehaviour
{
    NavMeshAgent NavEnemy;

    Vector3 DirrecionSpaw;
    public Transform[] ArrayPosition;
    Transform SpawPosition;
    Animator EnemyAnimactorController;
    private void Awake()
    {
        NavEnemy = GetComponent<NavMeshAgent>();

    }

    // Start is called before the first frame update
    void Start()
    {     
        SpawPosition = ArrayPosition[Random.Range(0, 4)];
        
        EnemyAnimactorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento Random del Enemigo
        DirrecionSpaw = SpawPosition.position - transform.position;

        if (DirrecionSpaw.magnitude > 2)
        {
            NavEnemy.destination = SpawPosition.position;
        }
        else
        {
            SpawPosition = ArrayPosition[Random.Range(0, 4)];
        }

    }
   
  
    
}
