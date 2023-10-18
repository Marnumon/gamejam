using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public LSPlayer thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        /*allPoints = FindObjectsOfType<MapPoint>();

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach(MapPoint point in allPoints)
            {
                if(point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position;
                    thePlayer.currentPoint = point;
                }
            }
        }*/
        //��ɾ��
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo()
    {
        AudioManager.instance.PlaySFX(4);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .25f);

        //SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad);
    }
}
