using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEnemy : FielViewMaster
{

    public bool ViewObjetivo;
    public Transform DirrecionObjetivo;
    // Start is called before the first frame update
    void Start()
    {
        ViewObjetivo = false;
    }

    // Update is called once per frame
    void Update()
    {
        FindVisibleTargets();

        foreach (GameObject obj in visibleTargets)
        {
            if (obj.tag == "Player")
            {              
                TimeView(obj);               
            }
        }

    }

    void TimeView(GameObject ObjArray)
    {

    }
}
