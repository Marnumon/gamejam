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
    private Image frogToShow;
    public Text textNumber;
    public RectTransform bottomTop;

    [Header("¿Ø¼þÊýÁ¿")]
    public int widgetNumber;

    // Start is called before the first frame update
    void Start()
    {
        frogToShow = GetComponent<Image>();

        textNumber.text = "Ê£Óà: " + widgetNumber.ToString();
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

            frogToShow.color = new Color(.7f, .7f, .7f, .7f);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        weidgetUI.SetActive(false);

        if (widgetNumber > 0)
        {
            frogToShow.color = new Color(1f, 1f, 1f, 1f);

            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             
            if (offset.y > -3f)
            {
                var newWidgetGameObject = Instantiate(widgetGameObject, offset, transform.rotation);

                widgetNumber--;
            }

            textNumber.text = "Ê£Óà: " + widgetNumber.ToString();
        }

        if(widgetNumber == 0)
        {
            frogToShow.color = new Color(.7f, .7f, .7f, .7f);
        }
    }
}
