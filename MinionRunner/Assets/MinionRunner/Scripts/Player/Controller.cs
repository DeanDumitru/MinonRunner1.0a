using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

   
    public float speed = 6f;
    public float jump;
    public float jumpRate;
 //   public float fireRate;
    public float power;

    [HideInInspector]
    public static bool setActive;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;

    int floorMask;
    float camRayLength = 1000f;

  //  public Rigidbody bullet;
 //   public Transform shotSpawn;

    private float nextJump;
   // private float nextFire;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        //    shot = ball.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
       // Bullet();

        Jumping();

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // if (setActive == true)
        //{
        Move(h, v);
        Animating(h, v);
        // }
    }

    void Move(float h, float v)
    {
        movement.Set(v, 0f, -h);
        movement = movement.normalized * speed * Time.deltaTime; // time between every call
        playerRigidbody.MovePosition(transform.localPosition + movement);
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextJump)
        {
            nextJump = Time.time + jumpRate;
            playerRigidbody.AddForce(transform.up * jump, ForceMode.Impulse);
        }
    }

 /*   public Vector3 angleShot = new Vector3(0, 0, 0);
    public float angles;

    private void Bullet()
    {
        if (Input.GetKeyDown(KeyCode.Y) && Time.time > nextFire)
        {
            Rigidbody clone;
            nextFire = Time.time + fireRate;
            clone = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation) as Rigidbody;
            //clone.velocity = transform.forward * power;
            clone.GetComponent<Rigidbody>().AddForce(angleShot * power, ForceMode.Impulse);
        }
    }
    */
}