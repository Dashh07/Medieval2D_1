using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source --------")]

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------Audio Clip--------")]
    public AudioClip Attack;
    public AudioClip GetHit;
    public AudioClip BossDeath;
    public AudioClip PlayerDeath;
    public AudioClip BossAttack;
    public AudioClip walking;
        

}
