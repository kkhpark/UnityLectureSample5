using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class AddressableLoad : MonoBehaviour
{

    public void CreateObj()
    {
        Addressables.InstantiateAsync("Cube", new Vector3(0,0,0), Quaternion.identity); //Adressable�� �̸��� ��ġ
        //ù���� ���ڴ� Ű���ε� name, ��ġ, ��������� ȸ����
        //Quaternion.identity - �� ��ü�� ������ �ִ� �⺻ ȸ����
    }


}
