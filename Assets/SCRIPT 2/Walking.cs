using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Walking : MonoBehaviour
{
    Transform[] objChild;
    public List<Transform> objChildList = new List<Transform>();

    private void Start()
    {
        tileNum();
    }
    void tileNum()
    {
        objChildList.Clear();


        objChild = GetComponentsInChildren<Transform>();

        foreach(Transform child in objChild)
        {
            if(child != this.transform && child.parent == this.transform)
            {
                objChildList.Add(child);
            }
        }
    }
}
