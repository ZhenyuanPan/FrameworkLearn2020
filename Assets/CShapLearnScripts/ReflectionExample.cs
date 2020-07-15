using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ReflectionExample : MonoBehaviour
{
    public class SomeClass
    {
        public void SayHello()
        {
            Debug.Log("Say Hello");
        }

        public string NumberToString(int number)
        {
            return number.ToString();
        }
    }

    void Start()
    {
        // 通过对象的 GetType 获取对象
        var someObj = new SomeClass();

        Type type = someObj.GetType();

        // 获取 SayHello 的 MethodInfo
        MethodInfo sayHelloMethodInfo = type.GetMethod("SayHello");

        // 调用 someObj 的 SayHello 方法
        // null 是指没有参数的意思
        sayHelloMethodInfo.Invoke(someObj, null);

        // 获取 NumberToString 的 MethodInfo
        MethodInfo numberToStringMethodInfo = type.GetMethod("NumberToString");

        // 调用 someObj 的 NumberToString 方法
        // 参数为 100
        // 返回值用 numberString 接收,返回的是 object 类型的对象
        object numberString = numberToStringMethodInfo.Invoke(someObj, new object[] { 100 });

        // 输出 numberString
        Debug.Log(numberString);
    }
}
