using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimiter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public bool tooClose = false;
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<DiceObject>() == null)
            CameraManager.tooClose = true;
    }
    private void OnTriggerExit(Collider other)
    {
        CameraManager.tooClose = false;
    }

}
