using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance { get; private set; }

    [SerializeField] private AudioClip damaged, thrusters, ionWave, harpoonHit, equipSwap, gameOver;
    private AudioSource audioSrc;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSrc = GetComponent<AudioSource>();
    }

    public void playDamaged()
    {
        audioSrc.PlayOneShot(damaged);
    }

    public void playThrusters()
    {
        audioSrc.PlayOneShot(thrusters);
    }
/*    public void playIonWave()
    {
        audioSrc.loop = true;
        audioSrc.clip = ionWave;
        audioSrc.Play();
    }*/
    public void playIonWave(bool isOn)
    {
        audioSrc.loop = true;
        audioSrc.clip = ionWave;
        if (isOn)
        {
            audioSrc.Play();
        }
        else
        {
            audioSrc.Stop();
        }
    }
    public void playHarpoonHit()
    {
        audioSrc.PlayOneShot(harpoonHit);
    }
    public void playSwap()
    {
        audioSrc.PlayOneShot(equipSwap);
    }
    public void playGameOver()
    {
        audioSrc.PlayOneShot(gameOver);
    }
}
