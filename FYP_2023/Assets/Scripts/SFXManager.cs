using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance { get; private set; }

    [SerializeField] private AudioClip damaged, thrusters, ionWave, harpoonHit, equipSwap, gameOver; //Audio clips
    private AudioSource audioSrc; //Audio Source

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSrc = GetComponent<AudioSource>();
    }
    public void playDamaged() //When damaged by debris
    {
        audioSrc.PlayOneShot(damaged);
    }
    public void playThrusters() //Thruster flame sfx
    {
        audioSrc.PlayOneShot(thrusters);
    }
    public void playIonWave(bool isOn) //Ion energy sound
    {
        audioSrc.loop = true;
        audioSrc.clip = ionWave;
        //If ion wave is on, play the clip
        if (isOn)
        {
            audioSrc.Play();
        }
        else //Else stop playing clip
        {
            audioSrc.Stop();
        }
    }
    public void playHarpoonHit() //Harpoon hits a debris
    {
        audioSrc.PlayOneShot(harpoonHit);
    }
    public void playSwap() //Swap equipment
    {
        audioSrc.PlayOneShot(equipSwap);
    }
    public void playGameOver() //Game Over music
    {
        audioSrc.PlayOneShot(gameOver);
    }
}
