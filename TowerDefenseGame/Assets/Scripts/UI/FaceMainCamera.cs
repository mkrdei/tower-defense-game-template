using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FaceCamera(transform);
    }
    private void FaceCamera(Transform _object)
    {
        _object.rotation = Quaternion.LookRotation((_object.position - Camera.main.transform.position));
    }
}
