using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PiecesIdentify", menuName = "PiecesIdentify", order = 0)]
public class PiecesIdentify : ScriptableObject {
    public string name;
    public int winCount;

    public void Suma(){
        if (name == "Center"){
             winCount++;
        }
    }

    public void Resta(){
        if (name == "Center"){
             winCount--;
        }
    }
}

