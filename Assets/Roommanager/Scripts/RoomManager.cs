using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;



public class RoomManager : MonoBehaviourPunCallbacks
{
	public static RoomManager Instance;
	public int Playerindex;
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private Vector3 spawnPosition = new Vector3(0, 1, 0);

    void Awake()
	{
		if(Instance)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		Instance = this;
	}

	public override void OnEnable()
	{
		base.OnEnable();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public override void OnDisable()
	{
		base.OnDisable();
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{


		if (scene.buildIndex == 1) // We're in the game scene
		{
			if (Playerindex == 1)
			{
				PhotonNetwork.Instantiate(
			     playerPrefab.name,      // Prefab must be inside Resources folder
			    spawnPosition,
			    Quaternion.identity
			    );
        

            }
			else
			{
				PhotonNetwork.Instantiate(
		        playerPrefab.name,      // Prefab must be inside Resources folder
		        new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z+5),
		        Quaternion.identity
			);
			}
			
		}
	}
}