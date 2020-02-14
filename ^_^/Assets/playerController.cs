using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
CharacterController cc;
    float moveSpeed = 10f;
    float gravity = 0f;
    float jumpVelocity = 0;
    Camera cam;
    public float jumpHeight = 16f;
    string state = "Movement";
                                                     

    
    // Start is called before the first frame update
    void Start() {
        cc = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        if (state == "Movement")
        {
Movement();
        }
        if (state == "Jump")
        {
            Jump();
            Movement();
        }
        

       
       
    }
    void Movement()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0, z).normalized;
        float cameraDirection = cam.transform.localEulerAngles.y;
        direction = Quaternion.AngleAxis(cameraDirection, Vector3.up) * direction;
        Vector3 velocity = direction * moveSpeed * Time.deltaTime;
        if (cc.isGrounded)
        {
            gravity = 0f;
        }
        else
        {
            gravity += 0.25f;
            gravity = Mathf.Clamp(gravity, 1f, 20f);
        }
        Vector3 gravityVector = -Vector3.up * gravity * Time.deltaTime;
        Vector3 jumpVector = Vector3.up * jumpVelocity * Time.deltaTime;
        cc.Move(velocity + gravityVector + jumpVector);
        if (velocity.magnitude > 0){
float yAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0, yAngle, 0);
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
            {
                jumpVelocity = jumpHeight;
            state = "Jump";
            }
    }
    void Jump()
    {
        if (jumpVelocity <0) { return; }
        jumpVelocity -= 1.25f;
    }
}
