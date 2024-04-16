using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSo : MonoBehaviour
{
    //base
    public string skillId;
    public string skillName;
    public string skillDesc;

    //stat
    public int maxCount;
    public int dmgFloat;
    public int emoFloat;
    public float stunRate;
    public float confRate;
    public float accRate;
    public Elements elements;

    //ui
    public Image[] imageData;
}
