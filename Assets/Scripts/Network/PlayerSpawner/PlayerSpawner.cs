using Photon.Pun;
using UnityEngine;

/// <summary>
/// Spawns the local player when joining a room
/// </summary>
public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 spawnPosition = new Vector3(0, 1, 0);

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room - Spawning Player");

        // Instantiate the player for this client
        PhotonNetwork.Instantiate(
            playerPrefab.name,      // Prefab must be inside Resources folder
            spawnPosition,
            Quaternion.identity
        );
    }
}
