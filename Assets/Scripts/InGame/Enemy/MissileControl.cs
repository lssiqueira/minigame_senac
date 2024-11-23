using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    public GameObject missile;

    Transform target;
    Transform head;

    Transform spawPoint;
    float contTimeToSpawn = 0;
    float limitTimeToSpawn;

    private void Start()
    {
        head = transform.GetChild(0);
        spawPoint = head.GetChild(0);

        limitTimeToSpawn = GetRandomSpawnLimit();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;

        head.LookAt(target);

        contTimeToSpawn += Time.deltaTime;
        if (contTimeToSpawn > limitTimeToSpawn)
        {
            Instantiate(missile, spawPoint.position, spawPoint.rotation);

            contTimeToSpawn = 0;
            limitTimeToSpawn = GetRandomSpawnLimit();
        }
    }

    float GetRandomSpawnLimit()
    {
        return Random.Range(0.0f, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            target = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            target = null;
        }
    }
}
