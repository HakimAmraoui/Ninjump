using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] public Rigidbody2D rb;

    public bool enableMovements;

    // private Vector2 movement;
    private Vector2 mousePos;
    private Vector2 lookDir;
    
    public static PlayerMovements instance;

    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogWarning("There is already an instance of PlayerMovements in the scene.");
            return;
        }
        instance = this;
    }
    

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // When the player left click
        if (Input.GetButtonDown("Fire1") && enableMovements)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // By subtracting a vector by another we got a vector that points from one to the other  
        lookDir = mousePos - rb.position;
    }

    void Jump()
    {
        // transform.position = Vector2.MoveTowards(transform.position, lookDir)
        rb.velocity = new Vector2(lookDir.x * jumpForce, lookDir.y * jumpForce);
    }
}