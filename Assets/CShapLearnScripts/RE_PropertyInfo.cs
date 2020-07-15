using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RE_PropertyInfo : MonoBehaviour
{
    public class SomeClass
    {
        public string PropertyA { get; set; }
    }


    private void Start()
    {

        var type = typeof(SomeClass);

        var someObj = new SomeClass();
        var propertyAInfo = type.GetProperty("PropertyA");

        Debug.LogFormat("(信息)Property Name:{0}", propertyAInfo.Name);


        Debug.LogFormat("(检测)是否是可写的（有 setter） ?:{0}", propertyAInfo.CanWrite);
        Debug.LogFormat("(检测)是否是可读的（有 getter） ?:{0}", propertyAInfo.CanRead);

        Debug.LogFormat("(结构)Property 类型:{0}", propertyAInfo.PropertyType);

        // 设置值
        propertyAInfo.SetValue(someObj, "小班");

        // 获取值
        var propertyAValue = propertyAInfo.GetValue(someObj);

        Debug.Log(propertyAValue);

        Debug.Log(someObj.PropertyA);
    }
}
