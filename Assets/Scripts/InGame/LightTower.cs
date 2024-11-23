using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTower : MonoBehaviour
{
    public int index;
    public GameManager gameManager;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (other.transform.GetComponent<PlayerControl>().playerKeys[index] && !transform.GetChild(0).gameObject.activeSelf)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                soundManager.PlayCellConected();
                gameManager.CheckKeys();
            }
        }
    }
}
