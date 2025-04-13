using UnityEngine;

public class First_Person_Movement : MonoBehaviour
{
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private bool Sneaking = false;
    private float xRotation;

    [Header("Components Needed")]
    [SerializeField] public Transform PlayerCamera;
    [SerializeField] public CharacterController Controller;
    [SerializeField] public Transform Player;
    [Space]
    [Header("Movement")]
    [SerializeField] public float Speed;
    [SerializeField] public float JumpForce;
    [SerializeField] public float Sensetivity;
    [SerializeField] public float Gravity = 9.81f;
    [Space]
    [Header("Sneaking")]
    [SerializeField] public bool Sneak = false;
    [SerializeField] public float SneakSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MoveCamera();

        if (Input.GetKey(KeyCode.RightShift) && Sneak)
        {
            Player.localScale = new Vector3(1f, 0.5f, 1f);
            Sneaking = true;
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            Player.localScale = new Vector3(1f, 1f, 1f);
            Sneaking = false;
        }
    }
    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);


        if (Controller.isGrounded)
        {
            Velocity.y = -1f;

            if (Input.GetKeyDown(KeyCode.Space) && Sneaking == false)
            {
                Velocity.y = JumpForce;
            }
        }
        else
        {
            Velocity.y += Gravity * -2f * Time.deltaTime;
        }
        if (Sneaking)
        {
            Controller.Move(MoveVector * SneakSpeed * Time.deltaTime);
        }
        else
        {
            Controller.Move(MoveVector * Speed * Time.deltaTime);
        }
        Controller.Move(Velocity * Time.deltaTime);

    }
    private void MoveCamera()
    {
        xRotation -= PlayerMouseInput.y * Sensetivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, PlayerMouseInput.x * Sensetivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
