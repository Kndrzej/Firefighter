using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public GameObject player;
    public CharacterController controller;
    public float xRotation = 0f;
    float mouseX;
    float mouseY;
    float xAxis;
    float zAxis;
    Vector3 move;
    Vector3 velocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = this.transform.root.GetComponent<CharacterController>();
    }
    void Update()
    { 
        mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        move = transform.right * xAxis + transform.forward * zAxis;
        transform.localRotation = Quaternion.Euler(xRotation,0,0);
        player.transform.Rotate(Vector3.up * mouseX);
        controller.Move(move*12f*Time.deltaTime);
        velocity.y -= 10f * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
