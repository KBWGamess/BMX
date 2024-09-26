using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject road;
    private Vector3 end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTile();
    }

    void SpawnTile()
    {
        GameObject temp = Instantiate(road, end, Quaternion.identity);
        end = temp.transform.GetChild(1).transform.position;
    }
}
