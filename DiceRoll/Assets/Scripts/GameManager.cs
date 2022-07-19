using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float delay = 0;
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
        InvokeRepeating("FlipNeutral", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
    
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

            float timer = 0.0f;
            diceRoll = (int)Random.Range(0, 6);
            Sprite diceFace = getDiceFace(diceRoll);
            //Material diceFace = getDiceFace(diceRoll);
            //tileToFlip.GetComponent<MeshRenderer>().material = diceFace;
            tileToFlip.GetComponent<SpriteRenderer>().sprite = diceFace;
            Animator _anim = tileToFlip.GetComponent<Animator>();
            _anim.SetBool("isFlipped", true);
            //FlipColor(tileToFlip,diceRoll,timer);
            neutralTileIds.RemoveAt(rnd);
        }
        else
        {
            Debug.Log("All of the Tiles have been Flipped...");
        }
        
        
    }

    /*
    public void FlipColor(GameObject _tile, int _diceRoll, float _timer)
    {
        Debug.Log(_timer);
       /* while (_timer <= 12f)
        {
            _timer += Time.deltaTime;
            int seconds = (int)_timer % 60;
            
            /*
            t += Time.deltaTime;
            if (t > 4f && t < 8f)
            {
                _tile.GetComponent<MeshRenderer>().material = ivoryMaterials[_diceRoll];
            }
            if (t > 8f && t < 12f)
            {
                _tile.GetComponent<MeshRenderer>().material = redMaterials[_diceRoll];
            }
        }
        Destroy(_tile, 12f);
        
        
    }
    */


}


