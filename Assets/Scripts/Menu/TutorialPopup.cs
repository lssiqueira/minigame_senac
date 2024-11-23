using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    public void TutorialOn()
    {
        gameObject.GetComponent<Animator>().SetBool("endGame", true);
    }

    public void TutorialOff()
    {
        gameObject.GetComponent<Animator>().SetBool("endGame", false);
    }
}
