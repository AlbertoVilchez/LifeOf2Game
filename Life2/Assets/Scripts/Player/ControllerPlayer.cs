using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControllerPlayer : MonoBehaviour
{
    float Horizontal, Vertical;
    public float SpeedPlayer,SpeedRotation;
    bool Agachado = true;

    Vector3 DirrecionPlayer;
    Vector3 CamForward;
    Vector3 CamRight;
    Vector3 MovePlayer;

  
    [Header("Player")]
    public Camera CameraMain;
    CharacterController ControlPlayer;
    Animator PlayerAnimactorController;
    // Start is called before the first frame update
    void Start()
    {
        ControlPlayer = GetComponent<CharacterController>();
        PlayerAnimactorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {     
        MovementPlayer();
        //JumpPlayer();
    }

    /* void JumpPlayer()
     {
         if (ControlPlayer.isGrounded)
         {
             if (Input.GetButtonDown("Jump"))
             {
                 MovePlayer.y = SpeedJump;
                 Debug.Log("Salto");
             }
         }
     }*/
    void CamDirection() // Posicion personaje relativo a la camara
    {
        CamForward = CameraMain.transform.forward;
        CamRight = CameraMain.transform.right;

        CamForward = CamForward.normalized;
        CamRight = CamRight.normalized;

        CamForward.y = 0;
        CamRight.y = 0;

    }
    void MovementPlayer() // Movimiento del personaje
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        DirrecionPlayer = new Vector3(Horizontal, 0, Vertical).normalized;
        DirrecionPlayer = Vector3.ClampMagnitude(DirrecionPlayer, 1);

        CamDirection();
        MovePlayer = DirrecionPlayer.x * CamRight + DirrecionPlayer.z * CamForward;
        ControlPlayer.transform.LookAt(ControlPlayer.transform.position + MovePlayer);
        //RotationPlayer();
        if (DirrecionPlayer.magnitude > 0.1f)
        {
            ControlPlayer.Move(MovePlayer * Time.deltaTime * SpeedPlayer);
            Runplayer();
        }
        CrouchPlayer();
        PlayerAnimactorController.SetFloat("PlayerWalkVelocity", DirrecionPlayer.magnitude * SpeedPlayer);
    }

    void RotationPlayer()
    {
        Ray MouseRotation = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(MouseRotation,out hit))
        {
            Vector3 TargerPosition = new Vector3(hit.point.x,transform.position.y,hit.point.z);

            Quaternion RotationPlayer = Quaternion.LookRotation(TargerPosition - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation,RotationPlayer,Time.deltaTime * SpeedRotation);
            

        }




    }

    void CrouchPlayer()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Agachado)
            {
                PlayerAnimactorController.SetBool("CouchActivate", true);
                SpeedPlayer = 2f;
                Agachado = false;
                
            }
            else
            {
        
                PlayerAnimactorController.SetBool("CouchActivate", false);
                SpeedPlayer = 4f;
                Agachado = true;
            }

        }
      
    }

    void Runplayer()
    {
        if (Agachado)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SpeedPlayer = 10;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                SpeedPlayer = 4;
            }

        }
       
    }

    

   

}
