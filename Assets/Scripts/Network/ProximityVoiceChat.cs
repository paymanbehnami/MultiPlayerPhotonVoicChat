using UnityEngine;
using Photon.Voice.Unity; 

public class ProximityVoiceChat : MonoBehaviour
{
    [SerializeField] private float proximityRadius = 10f;
    [SerializeField] private GameObject speakerIcon;

    private Speaker speaker;
    private Transform playerTransform;

    private void Awake()
    {
        speaker = GetComponent<Speaker>();
        playerTransform = transform;
    }

    private void Update()
    {
        foreach (var other in FindObjectsOfType<ProximityVoiceChat>())
        {
            if (other == this) continue;

            float distance = Vector3.Distance(playerTransform.position, other.playerTransform.position);
            if (distance <= proximityRadius)
            {               
                other.speaker.enabled = true;
                speakerIcon.gameObject.SetActive(true);
            }
            else
            {               
                other.speaker.enabled = false;
                speakerIcon.gameObject.SetActive(false);
            }
        }
    }
}
