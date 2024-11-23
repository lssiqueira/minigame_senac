using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float speed = 25f;
    private SoundManager soundManager;

    public GameObject explosion;

    private void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager").transform.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            other.transform.GetComponent<PlayerControl>().LostLife();
        }

        soundManager.PlayMissileExplosion();
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
