using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Transform endGamePopup;

    public Transform[] lightTowers;
    public bool gameOn = true;

    public Transform lifes;
    public SoundManager soundManager;

    public void PlayAgain()
    {
        SceneManager.LoadScene("InGame");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CheckKeys()
    {
        foreach (var tower in lightTowers)
        {
            if (!tower.GetChild(0).gameObject.activeSelf)
                return;
        }

        EndGame();
    }

    public void DestroyKey(Transform key)
    {
        DestroyKey(key);
    }

    public void EndGame(string endGameText = "")
    {
        gameOn = false;
        if (endGameText.Length > 0)
            endGamePopup.GetChild(2).GetComponent<Text>().text = endGameText;

        StartCoroutine(ShowEndGamePopup((endGameText.Length == 0)));

    }
    private IEnumerator ShowEndGamePopup(bool win)
    {
        yield return new WaitForSeconds(2f);
        if (win)
            soundManager.PlayWinSFX();
        else
            soundManager.PlayDefaultSFX();

        endGamePopup.GetComponent<Animator>().SetBool("endGame", true);
    }
}
