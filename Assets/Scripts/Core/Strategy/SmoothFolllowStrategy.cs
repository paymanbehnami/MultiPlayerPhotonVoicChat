using UnityEngine;

public class SmoothFolllowStrategy : ICameraFollowStrategy
{
    private float smoothSpeed;
    private Vector3 offset;

    public SmoothFolllowStrategy(float smoothSpeed, Vector3 offset)
    {
        this.smoothSpeed = smoothSpeed;
        this.offset = offset;
    }

    public void Follow(Transform camera, Transform target)
    {
        if (target == null) return;

        // Position behind player based on its rotation
        Vector3 desiredPosition = target.position +
                                  target.transform.rotation * offset;

        camera.position = Vector3.Lerp(
            camera.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // Rotate camera to face target direction
        Quaternion targetRotation = Quaternion.LookRotation(target.forward);
        camera.rotation = Quaternion.Lerp(
            camera.rotation,
            targetRotation,
            smoothSpeed * Time.deltaTime
        );
    }
}
