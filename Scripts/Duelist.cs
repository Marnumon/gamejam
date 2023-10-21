using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duelist : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.layer == LayerMask.NameToLayer("TargetPlanet") || gameObject.layer == LayerMask.NameToLayer("GravitationalPlanet"))
        {
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

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
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}