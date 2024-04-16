using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySo : ScriptableObject
{
    //base
    public string enemyId;
    public string nameEnemy;

    //stat
    public float baseHp;
    public float baseMp;
    public float resPhysical;
    public float resEmotion;
    public float rng;

    //ui
    public SkillSo[] listSkill;
   public Image image;
}
