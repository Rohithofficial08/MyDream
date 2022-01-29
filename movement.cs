using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    private Vector3 playerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xrot;  
    [SerializeField] private Transform feetTransform;
    [SerializeField] private LayerMask floorMask;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private Rigidbody playerBody;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float sensitivty;
    [SerializeField] private float Jumpforce;
    [SerializeField] private Transform player;
   

    private Animator animator;

    private float maxspeed = 36f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y") * sensitivty);

        MovePlayer();
        MovePlayerCamera();
    }
    
     
     private void MovePlayer()
     {
         Vector3 MoveVector = transform.TransformDirection(playerMovementInput) * Speed;
         playerBody.velocity = new Vector3(MoveVector.x,playerBody.velocity.y,MoveVector.z);

         if(Physics.CheckSphere(feetTransform.position,0.1f,floorMask))
         {
             if(Input.GetKeyDown(KeyCode.Space)){
             playerBody.AddForce(Vector3.up*Jumpforce,ForceMode.Impulse);
             }
         }
         if(Input.GetKey(KeyCode.LeftShift)){
             Speed = maxspeed;
         }else{
             Speed = 18;
         }

         if(MoveVector.magnitude != 0){
               animator.SetBool("run",true);
         }else{
             animator.SetBool("run",false);
         }
     }

     private void MovePlayerCamera(){
         xrot -= playerMovementInput.y * sensitivty;

         transform.Rotate(0f,playerMovementInput.x * sensitivty,0f);

         playerCamera.transform.localRotation = Quaternion.Euler(xrot,0f,0f);
     }

      
   
}
