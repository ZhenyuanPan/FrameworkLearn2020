using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

public class RE_MemberInfo : MonoBehaviour
{
    public class SomeClass
    {
        public string MemberA;
    }


    private void Start()
    {

        var type = typeof(SomeClass);

        var someObj = new SomeClass();

        MemberInfo memberAInfo = type.GetMember("MemberA").First();

        Debug.LogFormat("(信息)Member Name:{0}", memberAInfo.Name);

        // MemberInfo 需要转换成对应的 FieldInfo 或者 PropertyInfo 或者 MethodInfo 才可以获取具体的信息
        var fieldAInfo = memberAInfo as FieldInfo;

        Debug.LogFormat("(检测)是否是公开的 ?:{0}", fieldAInfo.IsPublic);

        Debug.LogFormat("(检测)是否是 Readonly 的 ?:{0}", fieldAInfo.IsInitOnly);

        Debug.LogFormat("(结构)Member 类型:{0}", fieldAInfo.FieldType);

        // 设置值
        fieldAInfo.SetValue(someObj, "小班");

        // 获取值
        var fieldAValue = fieldAInfo.GetValue(someObj);

        Debug.Log(fieldAValue);

        Debug.Log(someObj.MemberA);
    }
}
