using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float delay = 0;
    public PlaneDataObject planeDataValues;
    public GameObject aPlane;
    public GameObject gamePlane;

    public List<GameObject> tiles;
    public List<int> neutralTileIds;

    public int rnd;
    public int diceRoll;


    public Material[] diceMaterials;

    void Awake()
    {
        int[] ids = planeDataValues.id;
        Vector2Int[] tilePoses = planeDataValues.tilePos;
        diceMaterials = planeDataValues.tileMats;

        for (int i = 0; i < ids.Length; i++)
        {
            Vector2Int _pos = tilePoses[i];
            GameObject currentInstance = Instantiate(aPlane, new Vector3Int(_pos.x, _pos.y, 0),Quaternion.Euler(-90,0,0));
            MeshRenderer mr = currentInstance.GetComponent<MeshRenderer>();
            mr.material = diceMaterials[0];
            currentInstance.transform.parent = gamePlane.transform;
            currentInstance.name = ids[i].ToString() + ".plane";
            tiles.Add(currentInstance);
            neutralTileIds.Add(ids[i]);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FlipNeutral", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    public Material RollDice()
    {
        Material _diceMat;
        diceRoll = (int)Random.Range(0, 6);
        switch (diceRoll)
        {
            case 0:
                _diceMat = diceMaterials[1];
                    break;
            case 1:
                _diceMat = diceMaterials[2];
                break;
            case 2:
                _diceMat = diceMaterials[3];
                break;
            case 3:
                _diceMat = diceMaterials[4];
                break;
            case 4:
                _diceMat = diceMaterials[5];
                break;
            case 5:
                _diceMat = diceMaterials[6];
                break;
            default:
                _diceMat = diceMaterials[0];
                break;
        }
        return _diceMat;
    }


    public void FlipNeutral()
    {
        if (neutralTileIds.Count > 0)
        {
            rnd = (int)Random.Range(0, neutralTileIds.Count);
            string tileRefString = neutralTileIds[rnd].ToString() + ".plane";

            GameObject tileToFlip = GameObject.Find(tileRefString);
            Material diceFace = RollDice();
            tileToFlip.GetComponent<MeshRenderer>().material = diceFace;
            Animator _anim = tileToFlip.GetComponent<Animator>();

            _anim.SetBool("Flip", true);
            Destroy(tileToFlip, _anim.GetCurrentAnimatorStateInfo(0).length + delay);
            neutralTileIds.RemoveAt(rnd);
        }
        else
        {
            Debug.Log("All of the Tiles have been Flipped...");
        }
        
        
    }

}
