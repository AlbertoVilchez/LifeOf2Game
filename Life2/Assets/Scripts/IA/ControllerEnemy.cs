using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ControllerEnemy : MonoBehaviour
{
   

    [Header("Movimiento")]
    Vector3 DirrecionSpaw;
    public Transform[] ArrayPosition;
    Transform SpawPosition;


    [Header("Enemigo")]
    NavMeshAgent NavEnemy;
    Animator EnemyAnimactorController;
    ViewEnemy ObjetivoView;
   
    
    private void Awake()
    {
        NavEnemy = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawPosition = ArrayPosition[Random.Range(0, 4)];
        EnemyAnimactorController = GetComponent<Animator>();
        ObjetivoView = GetComponent<ViewEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        DirrecionObjetivo();

    }
    
    void DirrecionObjetivo()
    {
        if (ObjetivoView.ViewObjetivo == true)
        {
            NavEnemy.destination = ObjetivoView.DirrecionObjetivo.position;
            
        }
       
    }
  
    
}
