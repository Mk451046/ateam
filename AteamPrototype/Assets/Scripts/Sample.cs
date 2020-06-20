using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    public Animal animal;
}

[System.Serializable]
public class Animal
{
    public string name;
    [Header("年齢")]
    public int age;
    [Header("身長(cm)")]
    public float height;
    [Header("体重(kg)")]
    public float weight;
}