using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource truckExplosionSFX;
    public AudioSource missileExplosionSFX;
    public AudioSource cellCollected;
    public AudioSource cellConected;
    public AudioSource winSFX;
    public AudioSource defaultSFX;

    public void PlayMissileExplosion()
    {
        missileExplosionSFX.Play();
    }

    public void PlayTruckExplosion()
    {
        truckExplosionSFX.Play();
    }

    public void PlayCellCollected()
    {
        cellCollected.Play();
    }

    public void PlayCellConected()
    {
        cellConected.Play();
    }

    public void PlayWinSFX()
    {
        winSFX.Play();
    }

    public void PlayDefaultSFX()
    {
        defaultSFX.Play();
    }
}
