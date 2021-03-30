using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public GameObject Player;

    Vector3 DirrecionRelative;
    // Start is called before the first frame update
    void Start()
    {
        DirrecionRelative = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void LateUpdate()
    {
       

        transform.position = Player.transform.position + DirrecionRelative;
    }
}
