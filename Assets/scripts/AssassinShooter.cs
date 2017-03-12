using UnityEngine.Networking;
using UnityEngine;

public class AssassinShooter : NetworkBehaviour {

    [SerializeField]
    float gunCooldown=0.3f;

    [SerializeField]
    Camera shootingPoint;

    [SerializeField]
    GameObject blastPrefab;


    float elapsedTime;
    bool gunChooser=true;
  [SerializeField]  ParticleSystem gun1;
   [SerializeField] ParticleSystem gun2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        elapsedTime += Time.deltaTime;
      //  Debug.Log(elapsedTime);
        if(elapsedTime>=gunCooldown)
        {
            if(Input.GetButton("Fire1"))
            {
              //  Debug.Log("shoot");
                elapsedTime = 0;
                Cmdshoot(shootingPoint.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0f)), shootingPoint.transform.forward);
            }
        }
		
	}
    [Command]
    void Cmdshoot(Vector3 point, Vector3 direction)
    {
        RaycastHit hit;
        Ray ray = new Ray(point,direction);
        Debug.DrawRay(point,direction,Color.red);
        if (Physics.Raycast(ray,out hit, 50))
        {

            if (hit.collider.gameObject.tag == "Player")
               Debug.Log("hitPlayer");
                RpcShotEffects(hit.point);
                
        }
    }

    [ClientRpc]
    void RpcShotEffects(Vector3 pos)
    {
        if (gunChooser)
            gun1.Play();
        else
            gun2.Play();
        gunChooser = !gunChooser;
        Instantiate(blastPrefab,pos,Quaternion.identity);
    }
}
