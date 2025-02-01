using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cinematics : MonoBehaviour
{
    public Image cinematicImage;
    public float displayTime = 2f;
    public string nextScene;

    [Header("Start Cinematics")]
    public Sprite[] startImages;

    [Header("Middle Cinematics")]
    public Sprite[] middleImages;

    [Header("End Cinematics")]
    public Sprite[] endImages;

    private int currentStartIndex = 0;
    private int currentMiddleIndex = 0;
    private int currentEndIndex = 0;

    void Start()
    {
        if (startImages.Length > 0)
        {
            StartCoroutine(ShowNextImageStart());
        }
    }
    public void MiddleCinematic()
    {
        if (middleImages.Length > 0)
        {
            Time.timeScale = 0;
            cinematicImage.gameObject.SetActive(true);
            StartCoroutine(ShowNextImage());
        }
    }

    public void EndCinematics()
    {
        if (endImages.Length > 0)
        {
            Time.timeScale = 0;
            cinematicImage.gameObject.SetActive(true);
            StartCoroutine(ShowNextImageEnd());
        }
    }

    private IEnumerator ShowNextImageStart()
    {
        while (currentStartIndex < startImages.Length)
        {
            cinematicImage.sprite = startImages[currentStartIndex];
            currentStartIndex++;
            yield return new WaitForSeconds(displayTime);
        }
        cinematicImage.gameObject.SetActive(false);
    }
    private IEnumerator ShowNextImage()
    {
        while (currentMiddleIndex < middleImages.Length)
        {
            cinematicImage.sprite = middleImages[currentMiddleIndex];
            currentMiddleIndex++;
            yield return new WaitForSecondsRealtime(displayTime);
        }
        cinematicImage.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    private IEnumerator ShowNextImageEnd()
    {
        while (currentEndIndex < endImages.Length)
        {
            cinematicImage.sprite = endImages[currentEndIndex];
            currentEndIndex++;
            yield return new WaitForSecondsRealtime(displayTime);
        }
        cinematicImage.gameObject.SetActive(false);
        Time.timeScale = 1;
        EndScene();
    }
    void EndScene()
    {
        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}

