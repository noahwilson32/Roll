using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlaneDataObject", order = 1)]
public class PlaneDataObject : ScriptableObject
{
    public int[] id;

    public Vector2Int[] tilePos;

    public Material[] tileMats;


}
