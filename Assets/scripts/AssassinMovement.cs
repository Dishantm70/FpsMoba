using UnityEngine;
using UnityEngine.Networking;

public class AssassinMovement : NetworkBehaviour {

    public float moveSpeed;

    Animator anim;
    CharacterController cc;

    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {

        float movef, mover;

        if(isLocalPlayer)
        {
            movef= Input.GetAxisRaw("Vertical");
            mover = Input.GetAxisRaw("Horizontal");
            CmdMoveAndANimate(movef, mover);
        }

	
	}

    [Command]
    void CmdMoveAndANimate(float movef, float mover)
    {
        if (mover == 0)
        {
            if (movef == 1 || movef == -1)
                anim.SetInteger("walking", 1);
            else
                anim.SetInteger("walking", 0);
        }
        if (mover == 1)
            anim.SetInteger("walking", 2);
        if (mover == -1)
            anim.SetInteger("walking", 3);
        cc.SimpleMove(new Vector3(moveSpeed * mover / 2, 0, moveSpeed * movef));
    }
}
