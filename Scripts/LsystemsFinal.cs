using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class LsystemsFinal : MonoBehaviour
{
    public string axiom;
    public string currentString;
    public GameObject branchPrefab;
    public GameObject root;
    public GameObject leafPrefab;
    public GameObject flowerPrefab;

    private GameObject Tree = null;
    private GameObject treeSegment;
    private GameObject leaf;
    private GameObject flower;

    public Dictionary<char, string> rules;
    private Stack<TransformInfo> transformStack = new Stack<TransformInfo>();

    private Vector3 iniPos;
    private Vector3 iniRot;

    public float angle;
    public float length;
    public float width;
    public int n;
    
    //for step generate
    private int stepN;
    public bool isMax;
    public Text messageTxt;


    public string tempRule1;
    public char tempRule1k;
    public string tempRule2;
    public char tempRule2k;

    private void Start()
    {
        iniPos = transform.position;
        iniRot = transform.eulerAngles;
        isMax = false;
        stepN = 1;

    }


    public void ResetTree()
    {
        currentString = "";
        transform.position = iniPos;
        transform.eulerAngles = iniRot;
        Destroy(Tree);
    }


    public void Generate()
    {
        
        currentString = axiom;
        transform.position = iniPos;
        transform.eulerAngles = iniRot;

        Destroy(Tree);

        Tree = Instantiate(root);
        rules = new Dictionary<char, string>();
        
        rules.Add(tempRule1k, tempRule1);
        rules.Add(tempRule2k, tempRule2);
        Debug.Log(rules.Keys.Count);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            foreach (char c in currentString)
            {
                sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());

            }
            currentString = sb.ToString();
            sb = new StringBuilder();
        }
        //currentString = newString;
        //Debug.Log(currentString);
        foreach (char c in currentString)
        {
            switch (c)
            {
                case 'F':
                    Vector3 initialPos = transform.position;
                    //Move up
                    transform.Translate(Vector3.up * length);
                    treeSegment = Instantiate(branchPrefab);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(0, initialPos);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    treeSegment.GetComponent<LineRenderer>().startWidth = width;
                    treeSegment.GetComponent<LineRenderer>().endWidth = width;
                    treeSegment.transform.SetParent(Tree.transform);
                    
                    break;
                case '+':
                    transform.Rotate(Vector3.forward * angle);
                    break;
                case '-':
                    transform.Rotate(Vector3.back * angle);
                    break;
                case 'X':
                    break;
                case '[':
                    transformStack.Push(new TransformInfo()
                    {
                        position = transform.position,
                        rotation = transform.rotation
                    });

                    break;
                case ']':
                    TransformInfo ti = transformStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                    break;
                case 'A':
                    leaf = Instantiate(leafPrefab, transform.position, Quaternion.identity);
                    flower = Instantiate(flowerPrefab, transform.position, Quaternion.identity);
                    leaf.transform.SetParent(Tree.transform);
                    flower.transform.SetParent(Tree.transform);
                    break;


            }
        }
        

        
    }

    public void GenerateStep()
    {
        currentString = axiom;
        transform.position = iniPos;
        transform.eulerAngles = iniRot;

        Destroy(Tree);

        Tree = Instantiate(root);
        rules = new Dictionary<char, string>();
        rules.Add(tempRule1k, tempRule1);
        rules.Add(tempRule2k, tempRule2);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < stepN; i++)
        {
            foreach (char c in currentString)
            {
                sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());

            }
            currentString = sb.ToString();
            sb = new StringBuilder();
        }
        //currentString = newString;
        Debug.Log(currentString);
        foreach (char c in currentString)
        {
            switch (c)
            {
                case 'F':
                    Vector3 initialPos = transform.position;
                    //Move up
                    transform.Translate(Vector3.up * length);
                    treeSegment = Instantiate(branchPrefab);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(0, initialPos);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    treeSegment.GetComponent<LineRenderer>().startWidth = width;
                    treeSegment.GetComponent<LineRenderer>().endWidth = width;
                    treeSegment.transform.SetParent(Tree.transform);

                    break;
                case '+':
                    transform.Rotate(Vector3.forward * angle);
                    break;
                case '-':
                    transform.Rotate(Vector3.back * angle);
                    break;
                case 'X':
                    break;
                case '[':
                    transformStack.Push(new TransformInfo()
                    {
                        position = transform.position,
                        rotation = transform.rotation
                    });

                    break;
                case ']':
                    TransformInfo ti = transformStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                    break;
                case 'A':
                    leaf = Instantiate(leafPrefab, transform.position, Quaternion.identity);
                    flower = Instantiate(flowerPrefab, transform.position, Quaternion.identity);
                    leaf.transform.SetParent(Tree.transform);
                    flower.transform.SetParent(Tree.transform);
                    break;


            }
        }

        if(stepN>=n)
        {
            messageTxt.text = "You reached the maxinum generations.";
            stepN = 1;
        }
        else
        {
            messageTxt.text = "Current generation: "+ stepN;
            stepN++;
        }

    }

}
