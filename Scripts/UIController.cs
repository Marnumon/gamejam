using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject mainUI,levelCompleteUI, quitGameUI, levelFailUI;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }

#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.H))
        {
            levelCompleteUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            levelFailUI.SetActive(true);
        }
#endif
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    //以下为按钮交互
    public void ResetGame()
    {
        Debug.Log("重置");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //退出
    public void QuitGameUI()
    {
        quitGameUI.SetActive(true);

        mainUI.SetActive(false);
    }

    public void QuitGameYes()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGameNo()
    {
        quitGameUI.SetActive(false);

        mainUI.SetActive(true);
    }

    //胜利
    public void LevelCompleteUI()
    {
        levelCompleteUI.SetActive(true);

        mainUI.SetActive(false);
    }

    public void StayGame()
    {
        levelCompleteUI.SetActive(false);

        mainUI.SetActive(true);
    }

    //失败
    public void LevelFailUI()
    {
        levelFailUI.SetActive(true);
    }
}
