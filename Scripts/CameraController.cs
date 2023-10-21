using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [Header("�����ٶ�")]
    public float zoomSpeed = 2f;
    [Header("��С��Ұ")]
    public float minZoom = 3f;
    [Header("�����Ұ")]
    public float maxZoom = 10f;

    [Header("����ͼ")]
    public Transform background;

    private float scrollWheel, newSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��ȡ���ֹ���������
        scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        //�������������
        newSize = Camera.main.orthographicSize - scrollWheel * zoomSpeed;
        newSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        Camera.main.orthographicSize = newSize;

        //���ֱ����������ͬ��
        background.localScale = new Vector2(Camera.main.orthographicSize * .2f, Camera.main.orthographicSize * Camera.main.aspect *.12f);
    }
}
