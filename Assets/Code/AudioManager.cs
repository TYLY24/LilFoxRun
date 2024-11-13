using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

public AudioSource Music;
public AudioSource Sfx;
public AudioClip BgmMain;
public AudioClip BgmRun;
public AudioClip BgmCave;
public AudioClip second;
public AudioClip third;
public AudioClip four;
public AudioClip ShieldBlock;
public AudioClip Attack;
public AudioClip Buy;
public AudioClip BuyDenied;
public AudioClip BgmCaveRunSound;
public AudioClip ButtonBig;
public AudioClip ButtonSmall;
public AudioClip MonsterRoar;
public AudioClip Hurt;
public AudioClip Jump;
public AudioClip Ded;
public AudioClip Jump2;


    void Start()
    {
        Music.clip=BgmMain;
        Music.Play();
    }

    public void PlayBgm(AudioClip clip)
    {
        Music.clip=clip;
        Music.Play();
    }

    public void StopBgm()
    {
        
        Music.Stop();
    }

    // Update is called once per frame
    public void PlayVfx(AudioClip clip)
    {
        Sfx.PlayOneShot(clip);
    }
}
