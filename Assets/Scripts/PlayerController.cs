using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {
    private PlayerMovement playerMovementInput;
    private Rigidbody2D playerBody;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private TilemapCollider2D wall;
    [SerializeField] private Animator playerAnimation;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");


    private void Awake() {
        playerMovementInput = new PlayerMovement();
    }

    private void OnEnable() {
        playerMovementInput.Enable();
    }

    private void OnDisable() {
        playerMovementInput.Disable();
    }

    private void Start() {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Vector2 movementInput = playerMovementInput.Player.Movement.ReadValue<Vector2>();

        
        playerBody.velocity = movementInput * playerSpeed;
        if (movementInput != Vector2.zero) {
            if (movementInput.x < 0) {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            playerAnimation.SetBool(IsMoving, true);
        }
        else {
            playerAnimation.SetBool(IsMoving, false);
        }
    }
}