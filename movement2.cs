using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{
    public CharacterController characterController;

  public float speed = 200f;
  public float gravity = -9.82f;
  Vector3 velocity;

  public Animator anim;

  private void Awake()
  {
      characterController = GetComponent<CharacterController>();
      anim = GetComponent<Animator>();
  }

  private void Update()
  {
      float xmov = Input.GetAxis("Horizontal");
      float zmov = Input.GetAxis("Vertical");

      Vector3 move = transform.right*xmov + transform.forward*zmov;
      characterController.Move(move*speed*Time.deltaTime);

      velocity.y += gravity*Time.deltaTime;
      characterController.Move(velocity*Time.deltaTime);


      if(move.sqrMagnitude != 0){
          anim.SetBool("run",true);
      }
      else{
          anim.SetBool("run",false);
      }


  }
  

}
