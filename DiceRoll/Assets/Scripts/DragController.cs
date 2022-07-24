using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{



    [SerializeField]
    private bool isClicking = false;

    [SerializeField]
    Vector2 mousePos;

    [SerializeField]
    private Vector3 worldCords;

    public Camera mainCamera;
















    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isClicking = true;
            mousePos = Input.mousePosition;
            Debug.Log(mousePos);
            worldCords = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        else 
        {
            isClicking = false;
        }
    }
}
