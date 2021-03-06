using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip dead, tran, jump, apple, slimeMovement, unknownMovement, unknownShot, playerAttack, unknownBossRotate,
        spawnGrapplingHook;
    public static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dead = Resources.Load<AudioClip>("DeadEffect");
        tran = Resources.Load<AudioClip>("transitionSoundEffect");
        jump = Resources.Load<AudioClip>("JumpSoundEffect");
        apple = Resources.Load<AudioClip>("appleSound");
        slimeMovement = Resources.Load<AudioClip>("slime_movement");
        unknownMovement = Resources.Load<AudioClip>("unknown_movement");
        unknownShot = Resources.Load<AudioClip>("unknown_shot");
        playerAttack = Resources.Load<AudioClip>("player_attack");
        unknownBossRotate = Resources.Load<AudioClip>("unknownBoss_rotate");
        spawnGrapplingHook = Resources.Load<AudioClip>("SpawnGrapplingHook");
    }

    public static void PlaySound(string clip, float distance)
    {
        audioSource.volume = 1f;
        switch (clip)
        {
            case "Jump":
                audioSource.PlayOneShot(jump);
                break;
            case "Dead":
                audioSource.PlayOneShot(dead);
                break;
            case "TranEffect":
                audioSource.PlayOneShot(tran);
                break;
            case "Apple":
                audioSource.PlayOneShot(apple);
                break;
            case "SlimeMovement":
                audioSource.volume = distance;
                audioSource.PlayOneShot(slimeMovement);
                break;
            case "UnknownMovement":
                audioSource.volume = distance;
                audioSource.PlayOneShot(unknownMovement);
                break;
            case "UnknownShot":
                audioSource.PlayOneShot(unknownShot);
                break;
            case "PlayerAttack":
                audioSource.PlayOneShot(playerAttack);
                break;
            case "UnknownBossRotate":
                audioSource.volume = 0.05f;
                audioSource.PlayOneShot(unknownBossRotate);
                break;
            case "SpawnGrapplingHook":
                audioSource.PlayOneShot(spawnGrapplingHook);
                break;

        }
    }
}
