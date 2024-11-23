using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objetoParaAcompanhar;
    public float offsetX;
    public float offsetZ;


    // Atualiza a posição do objeto que acompanha
    void Update()
    {
        if (objetoParaAcompanhar != null)
        {
            float posicaoX = objetoParaAcompanhar.transform.position.x;
            float posicaoZ = objetoParaAcompanhar.transform.position.z;

            transform.position = new Vector3(posicaoX + offsetX, transform.position.y, posicaoZ + offsetZ);
        }
    }
}
