using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

    public static TreeController singleton { get; private set; }

    [SerializeField] private Node root;
    [SerializeField]
    private bool initTree;

    void Awake(){
        singleton = this;
    }
	// Use this for initialization
	void Start () {
        root = transform.GetChild(0).GetComponent<Node>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!initTree){
            root.recursivelyChangeStatus(2);
            initTree = true;
        }
	}
}
