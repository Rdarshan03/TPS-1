using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class user : MonoBehaviour
{

    CharacterController character;
    public float speed;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var hAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        var vAxis = CrossPlatformInputManager.GetAxis ("Vertical");

        var movement = hAxis * transform.right + vAxis * transform.forward;
        movement *= speed * Time.deltaTime;

        if(character.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jump",true);
                movement.y = 10;
            }
        }

        movement.y *= Physics.gravity.y * Time.deltaTime * speed;
        character.Move(movement);

        animator.SetFloat("Walk",vAxis);
    }
}
