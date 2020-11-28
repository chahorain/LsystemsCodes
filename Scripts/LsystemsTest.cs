using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;


public class TransformInfo1
{
    public Vector3 position;
    public Quaternion rotation;
}

public class LsystemsTest : MonoBehaviour
{
    [SerializeField] private int iteration = 4;
    [SerializeField] private float length = 10;
    [SerializeField] private float angle = 30;
    [SerializeField] private GameObject Branch;
    private const string axiom = "X";
    private Stack<TransformInfo> transformStack;
    private Dictionary<char, string> rules;
    private string currentString = string.Empty;

    private void Start()
    {
        transformStack = new Stack<TransformInfo>();

        rules = new Dictionary<char, string>
        {
            {'X', "[F][+X][F][-X][+X]" },
            {'F',"[FF]" }
        };

        Generate();

    }

    private void Generate()
    {
        currentString = axiom;
        StringBuilder sb = new StringBuilder();
        for(int i=0; i<iteration; i++)
        {
            foreach (char c in currentString)
            {
                sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());
            }
            currentString = sb.ToString();
            sb = new StringBuilder();
        }
        
        


        foreach(char c in currentString)
        {
            switch (c)
            {
                case 'F':
                    Vector3 initialPosition = transform.position;
                    transform.Translate(Vector3.up * length);
                    GameObject treeSegment = Instantiate(Branch);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(0, initialPosition);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(1, transform.position);

                    break;
                case 'X':
                    break;
                case '+':
                    transform.Rotate(Vector3.right * angle);
                    break;
                case '-':
                    transform.Rotate(Vector3.left * angle);
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
                

            }
        }
    }


}
