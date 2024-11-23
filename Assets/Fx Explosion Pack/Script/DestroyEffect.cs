using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour
{

	float contTimeDestroy;

	void Update()
	{
		contTimeDestroy += Time.deltaTime;
		if (contTimeDestroy > 10)
			Destroy(transform.gameObject);

	}
}
