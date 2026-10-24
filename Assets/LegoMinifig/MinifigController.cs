using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.Rendering.DebugUI;

public class MinifigController : MonoBehaviour
{
    Animator anim;
    [SerializeField] float CrossFadeSpeed = 2f;
    [SerializeField] string[] AnimationNames = {"Idle", "Run", "Jump", "Wave"};
    int currentIndex = 0;
    private bool isJumping = false;

 
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
            Idle();
        }
        if(Input.GetKeyDown("2"))
        {
            Run();
        } 
        //Extra animations I have added using blender.
        if (Input.GetKeyDown("3")) 
        { 
            anim.Play("Jump", 0);
        }
        if(Input.GetKeyDown("4"))
        {
            Wave();
        } 
  

    }

    public void Run()
    {
        anim.CrossFadeInFixedTime("Run", CrossFadeSpeed);
    }

    public void Idle()
    {
        anim.CrossFadeInFixedTime("Idle", CrossFadeSpeed);
    }

    public void Jump()
    {
        anim.CrossFadeInFixedTime("Jump", CrossFadeSpeed);
    }

    public void Wave()
    {
        anim.CrossFadeInFixedTime("Wave", CrossFadeSpeed);
    }   

    //This function is called when the user clicks on the minifig. It can be used to trigger animations one by one or to trigger a sequence of animations.
    public void OnMouseDown()
    {
        if (AnimationNames.Length == 0) return;
        Debug.Log("Clicked!");
        PlayAnimation((currentIndex + 1) % AnimationNames.Length);
    }

    public void PlayAnimation(int index)
    {
        if (index < 0 || index >= AnimationNames.Length) return;

        if (index == currentIndex)
        {
            if(!isLooping())
            {
                anim.Play(AnimationNames[index], 0, 0f);
            }
            return;
        }

        anim.CrossFadeInFixedTime(AnimationNames[index], CrossFadeSpeed);
        currentIndex = index;
    }

    bool isLooping()
    {
        return anim.GetCurrentAnimatorStateInfo(0).loop;
    }

    //This function is for setting the animation speed of the animator component. It can be used to make the animations play faster or slower.
    public void SetAnimationSpeed(float speed)
    {
        anim.speed = speed;
        Debug.Log("Speed: " + speed);
    }
}
