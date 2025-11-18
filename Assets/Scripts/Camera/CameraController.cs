using UnityEngine;
using Photon.Pun;
[RequireComponent (typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float smoothspeed = 7f;
    [SerializeField] private Vector3 offset = new Vector3(0, -5f, 8f);

    private Transform target;
    private ICameraFollowStrategy followStrategy;
    private void Awake()
    {
        followStrategy=new SmoothFolllowStrategy(smoothspeed, offset);
    }
    private void OnEnable()
    {
        CameraEvents.OnCameraTargetSet += SetTarget;
    }

    private void OnDisable()
    {
        CameraEvents.OnCameraTargetSet -= SetTarget;
    }
    private void LateUpdate()
    {
        followStrategy.Follow(transform,target);
    }
    private void SetTarget(Transform newtarget)
    {
        if(newtarget.GetComponent<PhotonView>().IsMine)
          target = newtarget;
    }
}
