using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

    public MeshRenderer render;
    // Start is called before the first frame update
    void Start () {
        render = GetComponent<MeshRenderer> ();
        render.material.color = Color.green;
    }

    // Update is called once per frame
    void Update () {

    }
}