using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerScript : MonoBehaviour
{
    public static AudioClip playerMovement, playerPickup;
    static AudioSource audioSrc;

    private void Start()
    {
        playerMovement = Resources.Load<AudioClip>("movement");
        playerPickup = Resources.Load<AudioClip>("pickup");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "movement":
                audioSrc.PlayOneShot(playerMovement);
                break;

            case "pickup":
                audioSrc.PlayOneShot(playerPickup);
                break;
        }
    }
}
