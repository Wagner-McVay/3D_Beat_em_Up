using UnityEngine;
using System.Collections;

public class BulletData : MonoBehaviour {

    int Damage;
    float Decay;
    float LastDecay;

    // Use this for initialization
    void Start ()
    {
        Decay = GameObject.FindGameObjectWithTag("Player").GetComponent<Bullet>().BulletDecay;
        LastDecay = Decay + Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > LastDecay)
        { Destroy(); }
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Terrain")
        {
            Destroy();
        }
    }

    void Destroy()
    { Destroy(this.gameObject); }
}
