using UnityEngine;
using System.Collections;

public class BulletData : MonoBehaviour {

	PlayerSettings PlayerSet;
    float Damage;
    float Decay;
    float LastDecay;

    // Use this for initialization
    void Start ()
    {
		PlayerSet = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSettings>();
		Damage = PlayerSet.Data[0].PlayerDamage;
		Decay = PlayerSet.Data[0].RangeAttackDecay;
        LastDecay = Decay + Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > LastDecay)
        { Destroy(); }
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Enemy")
		{
			c.gameObject.GetComponent<EnemyActor>().TakeDamage(Damage);
		}
		if (c.gameObject.tag == "Terrain")
        {
            Destroy();
        }
    }

    void Destroy()
    { Destroy(this.gameObject); }
}
