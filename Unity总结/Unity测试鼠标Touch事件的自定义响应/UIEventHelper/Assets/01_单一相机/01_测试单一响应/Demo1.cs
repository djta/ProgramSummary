﻿using UnityEngine;
using UnityEngine.UI;

public class Demo1 : MonoBehaviour
{

    private Image ui1;
    private Image ui2;
    private GameObject cube;
    private GameObject sprite;
    private Image img;
    private void Start()
    {
        ui1 = GameObject.Find("Canvas/ui1").GetComponent<Image>();
        ui2 = GameObject.Find("Canvas/ui2").GetComponent<Image>();
        cube = GameObject.Find("cube");
        sprite = GameObject.Find("sprite");
        //// 绑定自定义委托
        // 点击
        EventTriggerListener.Bind(ui1.gameObject).onClick = OnClickHandler;
        //EventTriggerListener.Bind(ui2.Go).onClick = OnClickHandler;
        EventTriggerListener.Bind(cube.gameObject).onClick = OnClickHandler;
        EventTriggerListener.Bind(sprite.gameObject).onClick = OnClickHandler;
        // 拖动
        EventTriggerListener.Bind(ui1.gameObject).onDrag = OnDragHandler;
        //EventTriggerListener.Bind(ui2.Go).onDrag = OnDragHandler;
        EventTriggerListener.Bind(cube.gameObject).onDrag = OnDragHandler;
        EventTriggerListener.Bind(sprite.gameObject).onDrag = OnDragHandler;
        // 进入
        EventTriggerListener.Bind(ui1.gameObject).onEnter = OnEnterHandler;
        //EventTriggerListener.Bind(ui2.Go).onEnter = OnEnterHandler;
        EventTriggerListener.Bind(cube.gameObject).onEnter = OnEnterHandler;
        EventTriggerListener.Bind(sprite.gameObject).onEnter = OnEnterHandler;
        // 离开
        EventTriggerListener.Bind(ui1.gameObject).onExit = OnExitHandler;
        //EventTriggerListener.Bind(ui2.Go).onExit = OnExitHandler;
        EventTriggerListener.Bind(cube.gameObject).onExit = OnExitHandler;
        EventTriggerListener.Bind(sprite.gameObject).onExit = OnExitHandler;
        // 按下
        EventTriggerListener.Bind(ui1.gameObject).onDown = OnDownHandler;
        //EventTriggerListener.Bind(ui2.Go).onDown = OnDownHandler;
        EventTriggerListener.Bind(cube.gameObject).onDown = OnDownHandler;
        EventTriggerListener.Bind(sprite.gameObject).onDown = OnDownHandler;
        // 弹起
        EventTriggerListener.Bind(ui1.gameObject).onUp = OnUpHandler;
        //EventTriggerListener.Bind(ui2.Go).onUp = OnUpHandler;
        EventTriggerListener.Bind(cube.gameObject).onUp = OnUpHandler;
        EventTriggerListener.Bind(sprite.gameObject).onUp = OnUpHandler;
    }


    private void OnClickHandler(EventTriggerListener.PointerDataStruct obj)
    {
        Debug.Log("点击了： " + obj.Go.name);
        Debug.Log("点击的位置： " + obj.PointerEventData.position);
    }

    private void OnDragHandler(EventTriggerListener.PointerDataStruct obj)
    {
        print(obj.PointerEventData.position);
        if (obj.IsUi)
            obj.RectTransform.anchoredPosition += obj.PointerEventData.delta;
        else
            obj.Move3D2DonDistance(Camera.main,false);// 屏幕的 X,Y 坐标，以及物体相对相机的距离
    }
    private void OnEnterHandler(EventTriggerListener.PointerDataStruct obj)
    {
        Debug.Log("进入了： " + obj.Go.name);
    }
    private void OnExitHandler(EventTriggerListener.PointerDataStruct obj)
    {
        Debug.Log("离开了： " + obj.Go.name);
    }
    private void OnDownHandler(EventTriggerListener.PointerDataStruct obj)
    {
        Debug.Log("按下了： " + obj.Go.name);
    }
    private void OnUpHandler(EventTriggerListener.PointerDataStruct obj)
    {
        Debug.Log("弹起了： " + obj.Go.name);
    }
}
