using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class BF_BallPlayer : MonoBehaviour
{
    public Camera cam;
    private Rigidbody rb;
    private Quaternion camRot;
    private Vector3 moveDirection;
    private Vector3 inputDirection;
    public Transform empty;

    public AudioClip[] jumpAudios;
    private AudioSource jumpAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        GameObject audioFlute = GameObject.FindWithTag("audioFlute");
        jumpAudioSource = audioFlute.GetComponent<AudioSource>();

        rb = this.GetComponent<Rigidbody>();
        if(cam == null)
        {
            cam = Camera.main;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float strenght = 10f;
            Vector3 vel = rb.velocity;
            vel.y = 0;
            rb.velocity = vel;
            rb.AddForce(Vector3.up * strenght, ForceMode.Impulse);

            int Index = Random.Range(0, jumpAudios.Length);
            AudioClip randomClip = jumpAudios[Index];
            jumpAudioSource.PlayOneShot(randomClip);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputDirection = Vector3.zero;
#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current.qKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            inputDirection += new Vector3(0, 0, 1);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            inputDirection += new Vector3(0, 0, -1);
        }
        if (Keyboard.current.wKey.isPressed || Keyboard.current.zKey.isPressed)
        {
            inputDirection += new Vector3(1, 0, 0);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            inputDirection += new Vector3(-1, 0, 0);
        }
#else
        if (Input.GetKey(KeyCode.Q)|| Input.GetKey(KeyCode.A))
        {
            inputDirection += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputDirection += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            inputDirection += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputDirection += new Vector3(-1, 0, 0);
        }

       
#endif
        MoveBall();
    }

    private void MoveBall()
    {
        camRot = Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
        moveDirection = camRot * new Vector3(Mathf.Clamp(inputDirection.x * 2, -1, 1), 0, Mathf.Clamp(inputDirection.z * 2, -1, 1));
        rb.AddTorque(moveDirection*7.5f);
    }
}
