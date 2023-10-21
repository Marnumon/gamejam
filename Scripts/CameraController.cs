using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [Header("缩放速度")]
    public float zoomSpeed = 2f;
    [Header("最小视野")]
    public float minZoom = 3f;
    [Header("最大视野")]
    public float maxZoom = 10f;

    [Header("背景图")]
    public Transform background;

    private float scrollWheel, newSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获取滚轮滚动的增量
        scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        //控制摄像机缩放
        newSize = Camera.main.orthographicSize - scrollWheel * zoomSpeed;
        newSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        Camera.main.orthographicSize = newSize;

        //保持背景和摄像机同步
        background.localScale = new Vector2(Camera.main.orthographicSize * .2f, Camera.main.orthographicSize * Camera.main.aspect *.12f);
    }
}
