using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerScript : MonoBehaviour
{
    public static AudioClip playerMovement, playerPickup;
    static AudioSource audioSource;

    private void Start()
    {
        playerMovement = Resources.Load<AudioClip>("movement");
        playerPickup = Resources.Load<AudioClip>("pickup");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "movement":
                audioSource.PlayOneShot(playerMovement);
                break;

            case "pickup":
                audioSource.PlayOneShot(playerPickup);
                break;
        }
    }
}
