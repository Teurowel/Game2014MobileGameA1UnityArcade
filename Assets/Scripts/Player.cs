//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one of Player");
            return;
        }

        instance = this;
    }
    #endregion

    Camera cam = null;
    [SerializeField] LayerMask rayCastMask; //Which layer do we raycast?

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Left mouse button
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit result;

        //    if (Physics.Raycast(ray, out result, 100.0f))
        //    {
        //        if(result.collider != null)
        //        {
        //            Debug.Log(result.collider.gameObject.name);
        //        }
        //    }
        //}
    }
}
