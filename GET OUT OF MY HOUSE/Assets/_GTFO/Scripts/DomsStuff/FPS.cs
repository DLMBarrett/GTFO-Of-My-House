using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public Transform playerCam;
    public CharacterController playerCon;

    public float mouseSen = 10f;
    public float moveSpeed = 5f;
    public float grav = -9.81f;

    private Vector3 vel;
    private Vector3 playerMoveInput;
    
    private float camXrotation;
    float mouseX;
    float mouseY;
    [SerializeField] public bool canLook;
    [SerializeField] public bool canMove;
       

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canLook = true;
        canMove = true;
    }
    private void Update()
    {
       
            playerMoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            Move();
            MouseLook();
        

       
    }

    public void Move()
    {
        if (canMove)
        {


            Vector3 moveVect = transform.forward * playerMoveInput.z + transform.right * playerMoveInput.x; // Gets x and z vectors

            if (playerCon.isGrounded)
            {
                vel.y = -3f;
            }

            else
            {
                vel.y -= grav * -2f * Time.deltaTime;
            }

            playerCon.Move(moveVect * moveSpeed * Time.deltaTime);
            playerCon.Move(vel * Time.deltaTime);
        }
    }

    public void MouseLook()
    {
        if (canLook)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;

            camXrotation -= mouseY;
            
           

            camXrotation = Mathf.Clamp(camXrotation, -90, 90);

            playerCam.localRotation = Quaternion.Euler(camXrotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

    }



}
