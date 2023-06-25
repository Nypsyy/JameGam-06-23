using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "LevelData", fileName = "ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    public bool showTutorial=true;
    public bool isMusicPlaying=false;
}
