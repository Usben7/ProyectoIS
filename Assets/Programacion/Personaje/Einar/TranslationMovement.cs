using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationMovement : MonoBehaviour
{
    enum STATES
    {
        IDDLE,
        IDDLEJUMP,
        WALK,
        WALKJUMP,
        RUN,
        RUNJUMP,
        REVERSE,
        REVERSEJUMP,
    }



    STATES currentState = STATES.IDDLE;

    Animator anim;

    public float speedWalk = 0.18f;
    public float speedRun = 0.27f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkConditions();
        MakeBehaviour();
    }

    void checkConditions()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Para correr y correr girando
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    currentState = STATES.RUNJUMP;
                }
                else
                {
                    currentState = STATES.RUN;
                }
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                currentState = STATES.WALKJUMP;
            }
            else
            {
                currentState = STATES.WALK;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentState = STATES.REVERSEJUMP;
            }
            else
            {
                currentState = STATES.REVERSE;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentState = STATES.IDDLEJUMP;
            }
            else
            {
                currentState = STATES.IDDLE;
            }
        }
    }

    void MakeBehaviour()
    {
        switch (currentState)
        {
            case STATES.IDDLE:
                idle();
                break;
            case STATES.WALK:
                walk();
                break;
            case STATES.RUN:
                run();
                break;
            case STATES.REVERSE:
                reverse();
                break;
            case STATES.IDDLEJUMP:
                iddleJump();
                break;
            case STATES.WALKJUMP:
                walkJump();
                break;
            case STATES.RUNJUMP:
                runJump();
                break;
            case STATES.REVERSEJUMP:
                reverseJump();
                break;

        }
    }
    void idle()
    {
        anim.SetInteger("Estate", 0);
    }
    void iddleJump()
    {
        anim.SetInteger("Estate", 3);
    }


    void walk()
    {
        anim.SetInteger("Estate", 1);
        transform.Translate(0, 0, speedWalk);
    }
    void walkJump()
    {
        anim.SetInteger("Estate", 3);
        transform.Translate(0, 0, speedWalk);
    }


    void run()
    {
        anim.SetInteger("Estate", 2);
        transform.Translate(0, 0, speedRun);
    }
    void runJump()
    {
        anim.SetInteger("Estate", 3);
        transform.Translate(0, 0, speedRun);
    }


    void reverse()
    {
        anim.SetInteger("Estate", 1);
        transform.Translate(0, 0, -speedWalk);
    }
    void reverseJump()
    {
        anim.SetInteger("Estate", 3);
        transform.Translate(0, 0, -speedWalk);
    }
}
