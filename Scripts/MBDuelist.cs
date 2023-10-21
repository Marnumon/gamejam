using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBDuelist : MonoBehaviour
{
    public GameObject icon;

    private Vector3 offset;
    private bool isDragging;

    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(true);

        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); ;
           
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    icon.SetActive(true);
                }else if(hit.collider.gameObject == icon)
                {

                }
                else
                {
                    icon.SetActive(false);
                }
            }
            else
            {
                icon.SetActive(false);
            }
        }

        transform.rotation = Quaternion.Euler(0f, 0f, icon.GetComponent<IconController>().GetAngle());
    }

    private void OnMouseDown()
    {
        isDragging = true;

        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
        }

        icon.SetActive(false);
    }

    private void OnMouseUp()
    {
        isDragging = false;

        icon.SetActive(true);
    }
}
