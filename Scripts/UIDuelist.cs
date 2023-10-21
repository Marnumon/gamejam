using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDuelist : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 offset;
    private bool isDragging;

    public GameObject weidgetUI, widgetGameObject;
    private Image pictureToShow;
    public Text textNumber;

    [Header("¿Ø¼þÊýÁ¿")]
    public int widgetNumber;

    // Start is called before the first frame update
    void Start()
    {
        pictureToShow = GetComponent<Image>();

        textNumber.text = "¡Á " + widgetNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            weidgetUI.transform.position = Input.mousePosition;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (widgetNumber > 0)
        {
            isDragging = true;

            weidgetUI.SetActive(true);

            pictureToShow.color = new Color(.7f, .7f, .7f, .7f);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        weidgetUI.SetActive(false);

        if (widgetNumber > 0)
        {
            pictureToShow.color = new Color(1f, 1f, 1f, 1f);

            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             
            if (offset.y > Camera.main.ScreenToWorldPoint(new Vector3(0f, 220f, 0f)).y)
            {
                var newWidgetGameObject = Instantiate(widgetGameObject, offset, transform.rotation);

                widgetNumber--;
            }

            textNumber.text = "¡Á " + widgetNumber.ToString();
        }

        if(widgetNumber == 0)
        {
            pictureToShow.color = new Color(.7f, .7f, .7f, .7f);
        }
    }
}
