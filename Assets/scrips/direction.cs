using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour
{
    public Renderer renderer;
    public Material instanceMaterial;

    public float xDirection;
    public float yDirection;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        instanceMaterial = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 panSpeed = new Vector2(xDirection, yDirection);
        instanceMaterial.SetVector("_PanSpeed", panSpeed);
    }
}
