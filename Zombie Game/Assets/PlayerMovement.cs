using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float raycastDistance = 1f;
    public LayerMask raycastMarsk;

    Rigidbody rb;
    
    Vector3 input;
    Camera cachedCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        cachedCamera = Camera.main;
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        input.x = h;
        input.z = v;

        Ray ray = cachedCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(Vector3.zero, Vector3.right, out hit, raycastDistance))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            transform.LookAt(hitPoint);
        }
        Debug.DrawRay(Vector3.zero, Vector3.right * raycastDistance, Color.red);
    }

    private void FixedUpdate()
    {
        Vector3 velocity = input * speed;
        rb.velocity = velocity;
    }
}
