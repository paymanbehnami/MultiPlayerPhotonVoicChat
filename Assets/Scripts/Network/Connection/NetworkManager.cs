using Photon.Pun;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        PhotonNetwork.AutomaticallySyncScene = true;
        //PhotonNetwork.AuthValues = new Photon.Realtime.AuthenticationValues();
        //PhotonNetwork.AuthValues.UserId = System.Guid.NewGuid().ToString();
        //PhotonNetwork.NickName = "Player_" + Random.Range(1000, 9999);

        PhotonNetwork.ConnectUsingSettings();
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
}
