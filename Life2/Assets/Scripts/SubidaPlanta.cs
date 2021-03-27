using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubidaPlanta : MonoBehaviour
{
    public GameObject Planta1;
    bool Haspasado;
    // Start is called before the first frame update
    void Start()
    {
        Haspasado = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            
            if (Haspasado)
            {
                Planta1.SetActive(true);
                Haspasado = false;
                Debug.Log(Haspasado);
            }
            else if(!Haspasado)
            {
                Planta1.SetActive(false);
                Haspasado = true;
                Debug.Log(Haspasado);
            }

           
        }
       
    }
}
