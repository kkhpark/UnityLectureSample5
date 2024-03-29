using Mirror;
using UnityEngine;
public class PlayerController : NetworkBehaviour
{

    CharacterController characterController;
    public float moveSpeed = 0.5f;
    public float turnSpeed = 150f;

    public float horizontal;
    public float vertical;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0, vertical);
            direction *= moveSpeed;
            characterController.SimpleMove(direction);
        }
    }
}
