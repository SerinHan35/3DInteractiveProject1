using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotatorSlider : MonoBehaviour
{
    public Slider slider;
    //Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, slider.value, 0);   
    }
}
