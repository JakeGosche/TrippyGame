using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTest1 : MonoBehaviour
{
    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        Debug.Log("OnPointerDownDelegate called.");
    }
}

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

        CharacterController characterController;
        Vector3 moveDirection = Vector3.zero;
        float rotationX = 0;

        [HideInInspector]
        public bool canMove = true;

        void Start()
        {
            characterController = GetComponent<CharacterController>();

            // Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
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

            // Player and Camera rotation
            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

            if (Input.GetKeyDown(KeyCode.F) && characterController.isGrounded)
            {
                RaycastHit hit;
                Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.GetComponentInChildren<Light>()){

                        hit.collider.gameObject.GetComponentInChildren<Light>().color = Color.green;
                    }
                }
            }
        }
        
    }



    //private CharacterController controller;
    //public float speed = 10.0f;
    //private float translation;
    //private float straffe;
    //private Vector3 playerVelocity;
    //private bool groundedPlayer;
    //private float playerSpeed = 2.0f;
    //private float jumpHeight = 1.0f;
    //private float gravityValue = -9.81f;

    //// Use this for initialization
    //void Start()
    //{
    //    // turn off the cursor
    //    Cursor.lockState = CursorLockMode.Locked;
    //    controller = gameObject.AddComponent<CharacterController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    groundedPlayer = controller.isGrounded;
    //    if (groundedPlayer && playerVelocity.y < 0)
    //    {
    //        playerVelocity.y = 0f;
    //    }

    //    // Input.GetAxis() is used to get the user's input
    //    // You can furthor set it on Unity. (Edit, Project Settings, Input)
    //    translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
    //    straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    //    transform.Translate(straffe, 0, translation);

    //    if (Input.GetKeyDown("escape"))
    //    {
    //        // turn on the cursor
    //        Cursor.lockState = CursorLockMode.None;
    //    }
    //}
}
