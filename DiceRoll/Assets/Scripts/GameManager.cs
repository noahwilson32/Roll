using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlaneDataObject planeDataValues;
    public GameObject aPlane;
    public GameObject gamePlane;

    void Awake()
    {
        int[] ids = planeDataValues.id;
        Vector2Int[] tilePoses = planeDataValues.tilePos;
        Material[] tileMats = planeDataValues.tileMats;

        for (int i = 0; i < ids.Length; i++)
        {
            Vector2Int _pos = tilePoses[i];
            GameObject currentInstance = Instantiate(aPlane, new Vector3Int(_pos.x, _pos.y, 0),Quaternion.Euler(-90,0,0));
            MeshRenderer mr = currentInstance.GetComponent<MeshRenderer>();
            mr.material = tileMats[0];
            currentInstance.transform.parent = gamePlane.transform;
            currentInstance.name = ids[i].ToString() + ".plane(" + _pos.x.ToString() + ", " + _pos.y.ToString() + ")";
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
