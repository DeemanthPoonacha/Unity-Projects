using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_Controller : MonoBehaviour
{
    private LineRenderer line;
    public Transform pos1;
    public Transform pos2;
    public Transform panel;
    // Start is called before the first frame update
    void Start()
    {
        line=GetComponent<LineRenderer>();
        line.positionCount=2;
        pos2=Camera.main.transform.GetChild(0);
        // pos2.position.x=pos2.position.x/Screen.width;
        // pos2.position.y=pos2.position.y/Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 pos2a= new Vector3(pos2.position.x/Screen.width,pos2.position.y/Screen.height,pos2.position.z);
        // var pos2a= (pos2.position);
        line.SetPosition(0,(pos1.position));
        line.SetPosition(1,(pos2.position));
        // Debug.Log(Camera.main.ScreenToWorldPoint(pos1.position));
        // Debug.Log(Camera.main.WorldToScreenPoint(pos1.position));
        panel.position=Camera.main.WorldToScreenPoint(pos2.position);
    }
}
