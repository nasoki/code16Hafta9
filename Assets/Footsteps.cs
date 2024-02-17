using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public AudioSource audioSource;
    public CharacterController characterController;
    PlayerControlScript playerControlScript;

    public float footstepThreshold, footstepRate;
    float lastFootstepTime;
    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GetComponent<PlayerControlScript>();
    }
    private void FixedUpdate()
    {
        if (playerControlScript.isRunning)
        {
            footstepRate = 0.5f;
        }
        else
        {
            footstepRate = 0.7f;
        }
        if (characterController.velocity.magnitude > footstepThreshold)
        {
            if (Time.time - lastFootstepTime > footstepRate)
            {
                lastFootstepTime = Time.time;
                audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
