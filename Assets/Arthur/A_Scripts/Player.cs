using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    //float 
    public float speed;

    Transform transform;
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        transform = gameObject.GetComponent<Transform>();

    }

    void FixedUpdate ()
    {

        //Checks to see what the current animation state is
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
            this.animator.GetCurrentAnimatorStateInfo(0).IsName("Move") || 
            this.animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot_Move"))
        {

            float curSpeed = Mathf.Abs(speed * Input.GetAxis("Vertical")) + Mathf.Abs(speed * Input.GetAxis("Horizontal"));
            animator.SetFloat("Speed", curSpeed);

            float angleMedian = 0;
            float arrowsPressed = 0;
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
                //transform.eulerAngles = new Vector3(0,270,0);
                angleMedian += 270;
                arrowsPressed++;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                //transform.eulerAngles = new Vector3(0, 90, 0);
                angleMedian += 90;
                arrowsPressed++;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
                //    transform.eulerAngles = new Vector3(0, 0, 0);
                if (Input.GetKey(KeyCode.A))
                {
                    angleMedian = 315;
                }
                else
                {
                    arrowsPressed++;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
                //transform.eulerAngles = new Vector3(0, 180, 0);

                angleMedian += 180;
                arrowsPressed++;
            }
            if (arrowsPressed > 0)
            {
                Debug.Log(new Vector3(0, angleMedian / arrowsPressed, 0) + " " + angleMedian + " " + arrowsPressed);
                transform.eulerAngles = new Vector3(0, angleMedian / arrowsPressed, 0);
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                animator.SetTrigger("Fire");
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                animator.SetTrigger("Melee");
            }
        }

        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Fire");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("Melee");
        }
    }
}
