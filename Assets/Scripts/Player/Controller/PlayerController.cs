using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PhotonView))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSetting setting;

    private PhotonView pv;
    private IMovementStrategy movementStrategy;
    private CharacterController controller;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        controller = GetComponent<CharacterController>();

        movementStrategy = new WalkStrategy();
    }

    private void Start()
    {
        if (pv.IsMine)
        {
            CameraEvents.OnCameraTargetSet?.Invoke(transform);
        }
    }

    private void Update()
    {
        if (!pv.IsMine) return;

        movementStrategy.Move(controller, setting);
    }
}
