using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    [SerializeField] private Node parent;
    [SerializeField] private List<Node> child = new List<Node>();
    [SerializeField] private Node chosenChild;

    public int status;
    private Color[] colors;
    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        colors = new Color[4];
        colors[0] = Color.red;
        colors[1] = Color.magenta;
        colors[2] = Color.blue;
        colors[3] = Color.black;
        
        spriteRenderer.color = colors[status];
    }

    public void AddChild(Node c){
        child.Add(c);
    }

    public void setParent(Node p) { parent = p; }
    public void recursivelyChangeStatus(int stat){
        ChangeStatus(stat);
        if (stat == 3){
            foreach (Node n in child){
                if (n != chosenChild)
                    n.recursivelyChangeStatus(0);
            }
        }
        else{
            foreach (Node n in child){
                n.recursivelyChangeStatus(stat - 1);
            }
        }

        if (stat == 2){
            if (parent){
                parent.chosenChild = this;
                parent.recursivelyChangeStatus(3);
            }
        }
            
    }

    public void ChangeStatus(int stat) {
        status = stat;
        status = Mathf.Clamp(status, 0, 3);
        spriteRenderer.color = colors[status];
    }

    void OnMouseDown(){
        if(status == 1)
            recursivelyChangeStatus(2);
    }
}
