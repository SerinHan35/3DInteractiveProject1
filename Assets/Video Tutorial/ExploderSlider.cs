using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExploderSlider : MonoBehaviour
{
    Animator anim;
    public Slider slider;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.Play("Explode", -1, slider.value);
    }
}
