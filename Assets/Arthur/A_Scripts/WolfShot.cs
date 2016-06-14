using UnityEngine;
using System.Collections;

public class WolfShot : MonoBehaviour
{
    public GameObject BlasterShotEmitter;

    public GameObject Bullet;

    public float Bullet_Forward_Force;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, BlasterShotEmitter.transform.position, BlasterShotEmitter.transform.rotation) as GameObject;


            //Left_Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

            Destroy(Temporary_Bullet_Handler, 3.0f);
        }

    }
}
