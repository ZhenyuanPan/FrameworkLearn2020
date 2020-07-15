using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ReflectionExampleFieldInfo : MonoBehaviour
{
    public class SomeClass
    {
        public string FieldA;
    }

    void Start()
    {
        // 通过对象的 GetType 获取对象
        var someObj = new SomeClass();

        var type = someObj.GetType();

        FieldInfo fieldAInfo = type.GetField("FieldA");

        Debug.LogFormat("(信息)Field Name:{0}", fieldAInfo.Name);

        Debug.LogFormat("(检测)是否是公开的 ?:{0}", fieldAInfo.IsPublic);

        Debug.LogFormat("(检测)是否是 Readonly 的 ?:{0}", fieldAInfo.IsInitOnly);

        Debug.LogFormat("(结构)Field 类型:{0}", fieldAInfo.FieldType);

        // 设置值
        fieldAInfo.SetValue(someObj, "小班");

        // 获取值
        var fieldAValue = fieldAInfo.GetValue(someObj);

        Debug.Log(fieldAValue);

        Debug.Log(someObj.FieldA);
    }
}
