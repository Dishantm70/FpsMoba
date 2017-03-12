using UnityEngine;
using UnityEngine.Networking;

public class ArcherMovement : NetworkBehaviour {

    public float moveSpeed;
    CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        float movef, mover;
        movef = Input.GetAxisRaw("Vertical");
        mover = Input.GetAxisRaw("Horizontal");
        CmdMove(movef, mover);
	}

    [Command]
    void CmdMove(float movef, float mover)
    {
        cc.SimpleMove(new Vector3 (mover * moveSpeed / 2, 0, movef * moveSpeed));
    }
}
