using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float delay = 2.0f;
    public PlaneDataObject planeDataValues;
    public GameObject Dice_Prefab;
    public GameObject gamePlane;

    public List<GameObject> tiles;
    public List<int> neutralTileIds;

    public int rnd;
    public int diceRoll;

    public Sprite[] diceFaces;

    


    void Awake()
    {
        int[] ids = planeDataValues.id;
        Vector2Int[] tilePoses = planeDataValues.tilePos;
        diceFaces = planeDataValues.diceFaces;
        for (int i = 0; i < ids.Length; i++)
        {
            Vector2Int _pos = tilePoses[i];
            GameObject currentInstance = Instantiate(Dice_Prefab, new Vector3Int(_pos.x, _pos.y, 0),Quaternion.Euler(0,0,0));
            currentInstance.transform.parent = gamePlane.transform;
            currentInstance.GetComponent<SpriteRenderer>().sprite = diceFaces[0];
            currentInstance.name = ids[i].ToString() + ".plane";
            tiles.Add(currentInstance);
            neutralTileIds.Add(ids[i]);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FlipNeutral", delay, delay);
    }

    
    public Sprite getDiceFace(int diceRoll)
    {
        Sprite _diceMat;
        switch (diceRoll)
        {
            case 0:
                _diceMat = diceFaces[1];
                    break;
            case 1:
                _diceMat = diceFaces[2];
                break;
            case 2:
                _diceMat = diceFaces[3];
                break;
            case 3:
                _diceMat = diceFaces[4];
                break;
            case 4:
                _diceMat = diceFaces[5];
                break;
            case 5:
                _diceMat = diceFaces[6];
                break;
            default:
                _diceMat = diceFaces[0];
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

            diceRoll = (int)Random.Range(0, 6);

            Sprite diceFace = getDiceFace(diceRoll);

            tileToFlip.GetComponent<SpriteRenderer>().sprite = diceFace;
            tileToFlip.GetComponent<Animator>().SetBool("isFlipped", true);
           
            neutralTileIds.RemoveAt(rnd);
        }
        else
        {
            Debug.Log("All of the Tiles have been Flipped...");
        }
        
        
    }
}


