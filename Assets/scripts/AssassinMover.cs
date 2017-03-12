using UnityEngine.Networking;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AssassinMover : NetworkBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            GetComponent<FirstPersonController>().enabled = false;
            return;
        }
        else
        {
            float movef = Input.GetAxis("Vertical");
          //  Debug.Log(movef);
            if (movef != 0f)
            {
                anim.SetBool("IsWalking", true);
           //     Debug.Log("Set");
            }
            else
                anim.SetBool("IsWalking", false);
        }
    }
}
