using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerJump, playerDeath, playerWin, playerCollision;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerJump = Resources.Load<AudioClip> ("Jumpsfx");
        playerDeath = Resources.Load<AudioClip> ("Byebye");
        playerWin = Resources.Load<AudioClip> ("Yipee");
        playerCollision = Resources.Load<AudioClip> ("Collision");


        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Jumpsfx":
                audioSrc.PlayOneShot(playerJump);
                break;
            case "Byebye":
                audioSrc.PlayOneShot(playerDeath);
                break;
            case "Yipee":
                audioSrc.PlayOneShot(playerWin);
                break;
            case "Collision":
                audioSrc.PlayOneShot(playerCollision);
                break;
        }
    }
}
