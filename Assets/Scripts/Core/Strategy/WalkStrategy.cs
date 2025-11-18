using UnityEngine;

public class WalkStrategy : IMovementStrategy
{
    private float verticalVelocity;

    public void Move(CharacterController controller, PlayerSetting setting)
    {
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S
        float turn = Input.GetAxisRaw("Horizontal");  // A/D

        // Rotation left / right
        if (Mathf.Abs(turn) > 0.1f)
        {
            controller.transform.Rotate(Vector3.up * turn * setting.turnSpeed * Time.deltaTime);
        }

        // Forward / backward movement relative to character forward
        Vector3 moveDir = controller.transform.forward * moveZ * setting.moveSpeed;

        // Gravity & Jump
        if (controller.isGrounded)
        {
            verticalVelocity = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = setting.jumpForce;
                PlayerEvents.OnPlayerJump?.Invoke();
            }
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        Vector3 finalMovement = new Vector3(moveDir.x, verticalVelocity, moveDir.z);
        controller.Move(finalMovement * Time.deltaTime);
    }
}
