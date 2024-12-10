using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    Animator my_Animator;
    public Boolean isMoving;
    Vector3 v;
    float mult;
   public Collect collect;


    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(38, (float)-5.5, (float).5);
        my_Animator = gameObject.GetComponent<Animator>();
        v = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {

       mult = collect.getNum();

        isMoving = false;

        if (Input.GetKey("w"))
        {
          //  gameObject.transform.Translate(0, 0, (float).1);
            isMoving = true;
            //transform.position = transform.position + Time.deltaTime * v;
            CharacterController controller = GetComponent<CharacterController>();
            controller.Move(v * Time.deltaTime*mult);

        }
        else if (Input.GetKey("s"))
        {
           // gameObject.transform.Translate(0, 0, (float)-.1);
            isMoving = true;
            //transform.position = transform.position + Time.deltaTime * v;
            CharacterController controller = GetComponent<CharacterController>();
            controller.Move(v * -1*Time.deltaTime*mult);

        }


         if (Input.GetKey("a"))
        {
            gameObject.transform.Rotate(0, -1, 0);
            v = Quaternion.Euler(0, -1, 0) * v;


        }
        else if (Input.GetKey("d"))
        {
            gameObject.transform.Rotate(0, 1, 0);
            v = Quaternion.Euler(0, 1, 0)*v;
        }



        if (isMoving == true)
        {
            my_Animator.Play("Base Layer.walk");

        }
        else
            my_Animator.Play("Base Layer.idleA");


        my_Animator.SetBool("isMoving", isMoving);



        // gameObject.transform.Translate(0, 0, movementSpeed * Time.deltaTime);
       

    }

}

