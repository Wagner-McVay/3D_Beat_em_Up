using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject Left_Bullet_Emitter;
    public GameObject Right_Bullet_Emitter;

    public GameObject Big_Bullet;

    //public GameObject Left_Bullet;
    //public GameObject Right_Bullet;

    public float Bullet_Forward_Force;
    public float BulletDecay;


    //int bulletdelay;


    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*if (Input.GetKey(KeyCode.Mouse0))
            {

                bulletdelay++;


                if (bulletdelay >= 10)
                {
                    GameObject Left_Temporary_Bullet_Handler;
                    Left_Temporary_Bullet_Handler = Instantiate(Left_Bullet, Left_Bullet_Emitter.transform.position, Left_Bullet_Emitter.transform.rotation) as GameObject;

                    GameObject Right_Temporary_Bullet_Handler;
                    Right_Temporary_Bullet_Handler = Instantiate(Right_Bullet, Right_Bullet_Emitter.transform.position, Right_Bullet_Emitter.transform.rotation) as GameObject;

                    //Left_Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
                    //Right_Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                    Rigidbody Left_Temporary_RigidBody;
                    Left_Temporary_RigidBody = Left_Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                    Rigidbody Right_Temporary_RigidBody;
                    Right_Temporary_RigidBody = Right_Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                    Left_Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
                    Right_Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

                    //Destroy(Left_Temporary_Bullet_Handler, 3.0f);
                    //Destroy(Right_Temporary_Bullet_Handler, 3.0f);

                    bulletdelay = 0;
                }
            }
            */
 
    }


    //void LeftBullet()
    //{

    //    GameObject Left_Temporary_Bullet_Handler;
    //    Vector3 pos = gameObject.transform.position;
    //    Vector3 rot = gameObject.transform.rotation.eulerAngles;
    //    Left_Temporary_Bullet_Handler = Instantiate(Left_Bullet, pos, Quaternion.Euler(rot)) as GameObject;
    //    Left_Temporary_Bullet_Handler.AddComponent<BulletData>();
    //    //Left_Bullet_Emitter.transform.position
    //    Left_Temporary_Bullet_Handler.transform.position += new Vector3(.1f,.45f,0);

    //    Rigidbody Left_Temporary_RigidBody;
    //    Left_Temporary_RigidBody = Left_Temporary_Bullet_Handler.GetComponent<Rigidbody>();

    //    Left_Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);


    //    Destroy(Left_Temporary_Bullet_Handler, 3.0f);
    //}

    //void RightBullet()
    //{
    //    GameObject Right_Temporary_Bullet_Handler;
    //    Vector3 pos = gameObject.transform.position;
    //    Vector3 rot = gameObject.transform.rotation.eulerAngles;
    //    Right_Temporary_Bullet_Handler = Instantiate(Left_Bullet, pos, Quaternion.Euler(rot)) as GameObject;
    //    Right_Temporary_Bullet_Handler.AddComponent<BulletData>();
    //    //Left_Bullet_Emitter.transform.position
    //    Right_Temporary_Bullet_Handler.transform.position += new Vector3(.1f,.45f,0);

    //    Rigidbody Left_Temporary_RigidBody;
    //    Left_Temporary_RigidBody = Right_Temporary_Bullet_Handler.GetComponent<Rigidbody>();

    //    Left_Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);


    //    Destroy(Right_Temporary_Bullet_Handler, 3.0f);
    //}

    void BigBullet()
    {
        GameObject Big_Temp_Bullet_Handle;
        Vector3 pos = gameObject.transform.position;
        Vector3 rot = gameObject.transform.rotation.eulerAngles;
        Big_Temp_Bullet_Handle = Instantiate(Big_Bullet, pos, Quaternion.Euler(rot)) as GameObject;
        Big_Temp_Bullet_Handle.AddComponent<BulletData>();

        Big_Temp_Bullet_Handle.transform.position += new Vector3(0, .45f, 0);

        Rigidbody Left_Temporary_RigidBody;
        Left_Temporary_RigidBody = Big_Temp_Bullet_Handle.GetComponent<Rigidbody>();

        Rigidbody Right_Temporary_RigidBody;
        Right_Temporary_RigidBody = Big_Temp_Bullet_Handle.GetComponent<Rigidbody>();

        Left_Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);


        Destroy(Big_Temp_Bullet_Handle, 3.0f);
    }

}

