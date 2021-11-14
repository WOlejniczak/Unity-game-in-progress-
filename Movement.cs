using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header("Movement")]

    private Rigidbody rb;
    public float movementSpeed = 6f;
    public float moving_multiplayer = 1;
    public float rbDrag = 6f;

    //floats obtaining my input 
    float verticalMovement;
    float horizontalMovement;


    //variable storing our directions ,just vector of x,y,z
    Vector3 movingDirections;

    private void Start()
    {

        //getting rb of "this", means player
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //just taking input every frame
        MyInput();
        DragControl();
    }
    private void FixedUpdate()
    {
        //dealing with rb so we're using FixedUpdate
        MyMovement();
    }


    void MyInput()
    {

        //getting horizontal input
        //return 1 if preesed "d", -1 when pressed "a"
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        //getting vertical input

        verticalMovement = Input.GetAxis("Vertical");

        //using transform.forward and transform.right to move where we're looking
        movingDirections = transform.forward * verticalMovement + transform.right * horizontalMovement;



    }
    void MyMovement()
    {
        //ading force relative to the movement
        //our vector3 stores our movement
        rb.AddForce(movingDirections.normalized * movementSpeed * moving_multiplayer, ForceMode.Acceleration);

    }

    void DragControl()
    {

        rb.drag = rbDrag;

    }
}
