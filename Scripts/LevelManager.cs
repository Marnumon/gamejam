using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GravitationalBody[] allTheGB;
    public IsCollider[] allTheC;
    public BlackHole[] allTheBH;

    public string nextLevel;
    private bool isStarted = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.FadeFromBlack();
    }

    // Update is called once per frameS
    void Update()
    {
        if (!isStarted)
        {
            SetObjectState(true);
        }
    }

    public void StartGame()
    {
        isStarted = true;

        Debug.Log("¿ªÊ¼");

        SetObjectState(false);
    }

    public void SetObjectState(bool isEditMode)
    {
        allTheGB = FindObjectsOfType<GravitationalBody>();
        allTheC = FindObjectsOfType<IsCollider>();
        allTheBH = FindObjectsOfType<BlackHole>();

        foreach (GravitationalBody gb in allTheGB)
        {
            gb.GetComponent<GravitationalBody>().enabled = !isEditMode;
        }

        foreach (IsCollider c in allTheC)
        {
            c.GetComponent<Collider2D>().isTrigger = isEditMode;
        }

        foreach (BlackHole bh in allTheBH)
        {
            bh.GetComponent<BlackHole>().enabled = !isEditMode;
        }
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_isPassed", 1);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(1f / UIController.instance.fadeSpeed + 1f);

        SceneManager.LoadScene(nextLevel);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCo());
    }

    public IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(2f);

        UIController.instance.LevelFailUI();
    }
}
