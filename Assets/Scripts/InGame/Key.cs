using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int index;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.gameObject.transform.GetComponent<PlayerControl>().playerKeys[index] = true;
            soundManager.PlayCellCollected();
            Destroy(gameObject);
        }
    }
}
