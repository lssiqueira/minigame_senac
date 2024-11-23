using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 initPos;
    Quaternion initRot;

    public GameObject explosion;

    public bool[] playerKeys;

    public int lifes = 3;

    [HideInInspector]
    public GameManager gameManager;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        initRot = transform.rotation;

        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void ResetPosition()
    {
        transform.position = initPos;
    }

    public void ResetRotation()
    {
        transform.rotation = initRot;
    }

    public void LostLife()
    {
        lifes--;
        Destroy(gameManager.lifes.GetChild(lifes).gameObject);
        if (lifes <= 0)
        {
            gameManager.EndGame("GAME OVER!");
            soundManager.PlayTruckExplosion();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
