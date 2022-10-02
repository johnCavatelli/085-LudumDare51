using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    /*//Audio For step noises
    public AudioSource step1;
    public AudioSource step2;
    public AudioSource step3;*/
    public CharacterController controller;//the character controller object
    public Transform groundCheck;//

    //public LayerMask groundMask;//filters out so only some collisions are processed (ex not with player or sky)    
    public float BASE_SPEED;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    public Vector3 velocity;

    bool isGrounded;//to store if the player is grounded
    bool frozen = false;

    void Update()
    {
        if (!frozen)
        {
            isGrounded = controller.isGrounded;
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            if (isGrounded)
            {
                if (velocity.y < 0)
                {
                    velocity.y = -2f;

                    /* Audio Stuff
                    //play audio sounds if grounded and moving
                    if (x != 0 || z!= 0)
                    {

                        if (!step1.isPlaying && !step2.isPlaying && !step3.isPlaying)
                        {
                            int number = Random.Range(0, 3);
                            if(number == 0)
                            {
                                step1.Play();
                            }
                            else if(number == 1)
                            {
                                step2.Play();
                            }
                            else
                            {
                                step3.Play();
                            }
                        }
                    }
                    else
                    {
                        animator.SetBool("Walking", false);
                        step1.Stop();
                        step2.Stop();
                        step3.Stop();
                    }*/
                }
                if (Input.GetButtonDown("Jump"))
                {
                    //using physics equation v = sqrt( -2hg ) to get velocity up
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }



            Vector3 move = (transform.right * x) + (transform.forward * z);//move based on keyboard input
            velocity.y += gravity * Time.deltaTime;//move on the y direction based on gravity
            controller.Move(move * BASE_SPEED * Time.deltaTime);//move based on input
            controller.Move(velocity * Time.deltaTime);//move based on velocity
        }
    }
    
    public void Freeze()
    {
        frozen = true;
    }

    public void UnFreeze()
    {
        frozen = false;
    }

}
