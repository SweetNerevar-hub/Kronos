using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSkybox : MonoBehaviour
{
    private Quaternion fixedRotation;
    // Start is called before the first frame update
    void Start()
    {
        fixedRotation = Camera.main.transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RenderSettings.skybox.SetMatrix("_Rotation", Matrix4x4.Rotate(Quaternion.Inverse(Camera.main.transform.rotation) * fixedRotation));
    }
}
