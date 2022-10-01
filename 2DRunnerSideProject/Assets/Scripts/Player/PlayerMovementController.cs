using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float playerFlySpeed = 10f;

    private Rigidbody2D playerRigidbody;
    private PlayerAnimationController playerAnimationController;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
         playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                playerRigidbody.AddRelativeForce(playerFlySpeed * Time.deltaTime * Vector2.up);
                playerAnimationController.IsGettingInput = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            playerAnimationController.IsGettingInput = false;
        }
    }
}
