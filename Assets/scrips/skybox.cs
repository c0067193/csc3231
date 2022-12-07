using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox : MonoBehaviour
{
    public float clock; // time
    public Material[] materl;
    public int index;
    public float time;
    public float angle;

    public Camera cam;
    VolumetricFog vf;
    private LensFlare fl;
    public GameObject light;
    public GameObject rain;
    public GameObject flare;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
         vf = cam.GetComponent<VolumetricFog>();
        fl = flare.GetComponent<LensFlare>();
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(clock, 0, 0), 0.05f);

        switch ((int)clock / 10)
        {
            case 0:
                changeSkybox(0);
                break;

            case 2://day
                changeSkybox(1);
                vf.enabled = false;
                Destroy(light);
                
                break;


            case 16: //sunset
                changeSkybox(2);
                Destroy(rain);
                fl.enabled = false;
                break;

            case 20:
                changeSkybox(3);//night
                break;
 
        }
    }
    void changeSkybox(int index)
    {
        RenderSettings.skybox = materl[index];
        index++;
        index %= materl.Length;
    }
}
