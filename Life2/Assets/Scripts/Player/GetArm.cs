using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetArm : MonoBehaviour
{
    ControllerPlayer PlayerGetArm;

    [Header("GameObject")]
    public GameObject Arma;
    Animator PlayerAnimactorController;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimactorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Combate();
    }

    void Combate()
    {
        if (Arma)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerAnimactorController.SetLayerWeight(1, 1);
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                PlayerAnimactorController.SetLayerWeight(1, 0);
            }
        }

    }


}
