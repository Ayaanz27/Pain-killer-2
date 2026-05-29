using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;

    [Header("Rotation")]
    public float rotationSpeed = 15f;

    private Rigidbody rb;
    private Animator animator;

    private Vector3 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        rb.freezeRotation = true; // Prevent tipping
    }

    void Update()
    {
        // Get input (ONLY input here)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movementInput = new Vector3(horizontal, 0f, vertical);
        movementInput = Vector3.ClampMagnitude(movementInput, 1f);

        // Update animation
        animator.SetFloat("Speed", movementInput.magnitude);
    }

    void FixedUpdate()
    {
        // Move player using physics
        Vector3 move = movementInput * walkSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        // Rotate toward movement direction
        if (movementInput.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementInput);
            rb.MoveRotation(Quaternion.Slerp(
                rb.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            ));
        }
    }
}
