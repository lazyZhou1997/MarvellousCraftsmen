using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ScaleAndRotate : MonoBehaviour
{

    private Touch oldTouch1;  //上次触摸点1(手指1)

    private Touch oldTouch2;  //上次触摸点2(手指2)


    void Update()

    {

        //没有触摸，就是触摸点为0

        if (Input.touchCount <= 0)
        {

            return;

        }

        //单点触摸， 水平上下旋转
        if (1 == Input.touchCount)

        {

            Touch touch = Input.GetTouch(0);

            Vector2 deltaPos = touch.deltaPosition;

            transform.Rotate(Vector3.down * deltaPos.x * 0.9f, Space.World); //绕Y轴进行旋转

            transform.Rotate(Vector3.right * deltaPos.y * 0.9f, Space.World); //绕X轴进行旋转，下面我们还可以写绕Z轴进行旋转

        }

    }

}