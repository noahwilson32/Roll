using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public Sprite[] diceFaces;
    public PlaneDataObject planeDataValues;

    public Image diceButton;



    private void Awake()
    {
        diceFaces = planeDataValues.diceFaces;
    }



    public void RollDice()
    {
        int diceRoll = (int)Random.Range(1,7);

        Sprite thisRoll = getDiceFace(diceRoll);
        diceButton.sprite = thisRoll;
        
    }


    public Sprite getDiceFace(int diceRoll)
    {
        Sprite _diceMat;
        switch (diceRoll)
        {
            case 1:
                _diceMat = diceFaces[1];
                break;
            case 2:
                _diceMat = diceFaces[2];
                break;
            case 3:
                _diceMat = diceFaces[3];
                break;
            case 4:
                _diceMat = diceFaces[4];
                break;
            case 5:
                _diceMat = diceFaces[5];
                break;
            case 6:
                _diceMat = diceFaces[6];
                break;
            default:
                _diceMat = diceFaces[0];
                break;
        }

        return _diceMat;
    }
}
