using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
