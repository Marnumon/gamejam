using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{
    public GameObject obj; 

    private bool isRotating;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 2f);

        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
    }

    private void OnMouseDown()
    {
        isRotating = true;
    }

    private void OnMouseDrag()
    {
        if (isRotating)
        {
            angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) * Mathf.Rad2Deg;
        }
    }

    public float GetAngle()
    {
        return angle;
    }
}
