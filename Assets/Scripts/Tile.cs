//SourceFileName : Tile.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Sep.18, 2020
//Program description : fuctions of tile
//Revision History : Sep.18, 2020 Adding OnMouseDOwn funtion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnMouseDown()
    {
        Debug.Log(transform.name);
    }
}
