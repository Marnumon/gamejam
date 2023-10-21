using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCircle : MonoBehaviour
{
    public GravitationalBody theGB;

    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        theGB = GetComponent<GravitationalBody>();
    }

    // Update is called once per frame
    void Update()
    {
        circle.transform.localScale = new Vector3(theGB.forceRange * .285f, theGB.forceRange * .285f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); ;

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("点到本体");
                    circle.SetActive(true);
                }
                else
                {
                    Debug.Log("没点到本体");
                    circle.SetActive(false);
                }
            }
            else
            {
                Debug.Log("没点到本体");
                circle.SetActive(false);
            }
        }
    }
}
