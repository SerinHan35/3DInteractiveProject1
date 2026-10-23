using UnityEngine;

public class MinifigController : MonoBehaviour
{
    Animator anim;
    [SerializeField] float CrossFadeSpeed = 5f;
    [SerializeField] string[] AnimationNames = {"Idle", "Run", "Jump", "Wave"};
    int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //This part is for playing the animations based on the input from the user.
        if (Input.GetKeyDown("1"))
        {
            anim.CrossFade("Idle", CrossFadeSpeed);
        }
        if(Input.GetKeyDown("2"))
        {
            anim.CrossFade("Run", CrossFadeSpeed);
        } 
        //Extra animations I have added using blender.
        if (Input.GetKeyDown("3")) 
        { 
            anim.CrossFade("Jump", CrossFadeSpeed); 
        }
        if(Input.GetKeyDown("4"))
        {
            anim.CrossFade("Wave", CrossFadeSpeed);
        } 
  

    }

    public void StartWalking()
    {
        anim.CrossFade("Run", CrossFadeSpeed);
    }

    public void StopWalking()
    {
        anim.CrossFade("Idle", CrossFadeSpeed);
    }

    //This function is called when the user clicks on the minifig. It can be used to trigger animations one by one or to trigger a sequence of animations.
    public void OnMouseDown()
    {
        Debug.Log("Clicked!");
        PlayAnimation((currentIndex + 1) % AnimationNames.Length);
    }

    public void PlayAnimation(int index)
    {

        if (index >= 0 && index < AnimationNames.Length)
        {
            currentIndex = index;
            anim.CrossFade(AnimationNames[index], CrossFadeSpeed);
        }
    }

    //This function is for setting the animation speed of the animator component. It can be used to make the animations play faster or slower.
    public void SetAnimationSpeed(float speed)
    {
        anim.speed = speed;
    }
}
