using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseControls();
    }


    void MouseControls()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 15;
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log("X: " + worldPos.x.ToString() + " Y: " + worldPos.y.ToString());
            transform.position = Vector3.Lerp(transform.position, worldPos, Time.deltaTime);
        }
    }
}
