using UnityEngine;

public interface ICameraFollowStrategy
{
    void Follow(Transform camera, Transform target);
}
