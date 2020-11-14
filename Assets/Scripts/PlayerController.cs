using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public PostWiseEvent postWiseEvent;
    public GameObject displayBoxObject;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        //Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
    }

    void Update()
    {
        // Player and Camera rotation
        if (canMove)
        {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

       
       

    // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
    // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
    // as an acceleration (ms^-2)
    if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

       
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

            RaycastHit hit;
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            bool displayBox = false;
            if (Physics.Raycast(ray, out hit, 2))
            {
                
                GameObject objectHit = hit.collider.gameObject;
                if (objectHit.GetComponentInChildren<PostWiseEvent>() || objectHit.GetComponent<PodScript>() || hit.collider.gameObject.GetComponent<PuzzleObject>())
                {
                    displayBox = true;
                        
                    if (Input.GetKeyDown(KeyCode.F) && characterController.isGrounded)
                    {
                        if (objectHit.GetComponentInChildren<PostWiseEvent>())
                        {
                            objectHit.GetComponentInChildren<PostWiseEvent>().ActivateSound();
                        }
                        if (objectHit.GetComponent<PodScript>())
                        {
                            objectHit.GetComponent<PodScript>().Activate();
                        }
                        if (hit.collider.gameObject.GetComponent<PuzzleObject>())
                        {

                            objectHit.GetComponent<PuzzleObject>().Activate();
                        }
                    }
                }
            }

            displayBoxObject.SetActive(displayBox);
        }
        
    }
}
