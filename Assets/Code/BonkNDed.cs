using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonkNDed : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    //public bool BonkBonk;
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    public void BonkBonk()
    {
        animator.SetBool("Ded",true);

    }
}
