using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileVisible : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
    }
}
