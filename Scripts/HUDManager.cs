using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour
{
    public LsystemsFinal lsystems;
    public InputField axiom;
    public InputField generations;
    public InputField length;
    public InputField angles;
    public InputField width;
    public InputField rule1;
    public InputField rule2;
    public Toggle wantLeaf;



    public Text txt;


    private string tempRule1;
    private char tempRule1k;
    private string tempRule2;
    private char tempRule2k;

    private string t1;
    private string t1k;
    private string t2;
    private string t2k;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private bool isLock;
    private void Start()
    {
        isLock = false;
        resetValues();
    }
    private void resetValues()
    {
        axiom.text = "";
        generations.text = "";
        length.text = "";
        angles.text = "";
        width.text = "";
        rule1.text = "";
        rule2.text = "";
        wantLeaf.isOn = false;
        isLock = false;
    }
    public void Generate()
    {
        int tint;
        float tfloat1;
        float tfloat2;

        if (axiom.text == "" ||
        generations.text == "" || int.Parse(generations.text) <= 0 || !int.TryParse(generations.text, out tint) ||
        length.text == "" || float.Parse(length.text) > 5 || float.Parse(length.text) < 1 || !float.TryParse(length.text, out tfloat1) ||
        angles.text == "" ||
        width.text == "" || float.Parse(width.text) > 1 || float.Parse(width.text) < 0 || !float.TryParse(width.text, out tfloat2))
        {
            isLock = true;
            //resetValues();
        }

        if (isLock == false)
        {
            
            lsystems.n = int.Parse(generations.text);
            lsystems.length = float.Parse(length.text);
            lsystems.width = float.Parse(width.text);
            lsystems.angle = float.Parse(angles.text);
            lsystems.axiom = axiom.text;
            tempRule1Input();
            tempRule2Input();
            if(isLock == false)
            {
                lsystems.Generate();
                txt.text = "Generated";
            }
            else
            {
                txt.text = "Please input correct format value";
                resetValues();
            }
            
        }
        else
        {
            txt.text = "Please input correct format value";
            resetValues();

        }
        
        

        

    }

    public void GenerateStep()
    {
        int tint;
        float tfloat1;
        float tfloat2;

        if (axiom.text == "" ||
        generations.text == "" || int.Parse(generations.text) <= 0 || !int.TryParse(generations.text, out tint)||
        length.text == "" || float.Parse(length.text)>5|| float.Parse(length.text)<1|| !float.TryParse(length.text, out tfloat1)||
        angles.text == "" || 
        width.text == "" || float.Parse(width.text)>1 || float.Parse(width.text) <0 || !float.TryParse(width.text, out tfloat2))
        {
            isLock = true;
            //resetValues();
        }


        if (isLock == false)
        {

            lsystems.n = int.Parse(generations.text);
            lsystems.length = float.Parse(length.text);
            lsystems.width = float.Parse(width.text);
            lsystems.angle = float.Parse(angles.text);
            lsystems.axiom = axiom.text;
            tempRule1Input();
            tempRule2Input();
            lsystems.GenerateStep();
            //txt.text = "Generated";
        }
        else
        {
            txt.text = "Please input correct format value";
            resetValues();

        }
    }

    public void ResetPress()
    {
        txt.text ="";
        resetValues();
        lsystems.ResetTree();
    }

    void tempRule1Input()
    {
        if(rule1.text!="")
        {
            for (int i = 0; i < rule1.text.Length; i++)
            {
                if (rule1.text[i].ToString() != "=")
                {

                    t1k += rule1.text[i];
                    if (t1k.Length >= 2 || t1k != "F")
                    {
                        isLock = true;
                    }
                    
                }
                else
                {
                    for (int o = i + 1; o < rule1.text.Length; o++)
                    {
                        t1 += rule1.text[o].ToString();

                    }
                    break;
                }

            }
            if (wantLeaf.isOn)
            {
                for (int i=0; i<t1.Length; i++)
                {
                    if(t1[i].ToString()=="[")
                    {
                        t1 = t1.Insert(i + 1, "A");
                        i++;
                        if(i==t1.Length)
                        {
                            break;
                        }
                        
                    }
                    if(t1[i].ToString() == "]")
                    {
                        t1 = t1.Insert(i + 1, "A");
                        i++;
                        if (i == t1.Length)
                        {
                            break;
                        }
                    }
                }
            }
            tempRule1 = t1;
            tempRule1k = t1k[0];
            lsystems.tempRule1 = tempRule1;
            lsystems.tempRule1k = tempRule1k;
            t1k = null;
            t1 = null;
        }
        



    }
    void tempRule2Input()
    {
        if(rule2.text!="")
        {
            for (int i = 0; i < rule2.text.Length; i++)
            {
                if (rule2.text[i].ToString() != "=")
                {
                    t2k += rule2.text[i];
                    if (t2k.Length >= 2 || t2k!="X")
                    {
                        isLock = true;
                    }
                }
                else
                {
                    for (int o = i + 1; o < rule2.text.Length; o++)
                    {

                        t2 += rule2.text[o].ToString();

                    }
                    break;
                }

            }
            if (wantLeaf.isOn)
            {
                for (int i = 0; i < t2.Length; i++)
                {
                    if (t2[i].ToString() == "[")
                    {
                        t2 = t2.Insert(i + 1, "A");
                        i++;
                        if (i == t2.Length)
                        {
                            break;
                        }

                    }
                    if (t2[i].ToString() == "]")
                    {
                        t2 = t2.Insert(i + 1, "A");
                        i++;
                        if (i == t2.Length)
                        {
                            break;
                        }
                    }
                }
            }
            tempRule2 = t2;
            tempRule2k = t2k[0];
            lsystems.tempRule2 = tempRule2;
            lsystems.tempRule2k = tempRule2k;
            t2k = null;
            t2 = null;
        }
        


    }

    public void tmp1Press()
    {
        axiom.text = "F";
        generations.text = "5";
        length.text = "1";
        angles.text = "25.7";
        width.text = "0.5";
        rule1.text = "F=F[+F]F[-F]F";
        rule2.text = "";
    }
    public void tmp2Press()
    {
        axiom.text = "F";
        generations.text = "5";
        length.text = "1";
        angles.text = "20";
        width.text = "0.5";
        rule1.text = "F=F[+F]F[-F][F]";
        rule2.text = "";
    }
    public void tmp3Press()
    {
        axiom.text = "F";
        generations.text = "4";
        length.text = "1";
        angles.text = "22.5";
        width.text = "0.5";
        rule1.text = "F=FF-[-F+F+F]+[+F-F-F]";
        rule2.text = "";
    }
    public void tmp4Press()
    {
        axiom.text = "X";
        generations.text = "7";
        length.text = "1";
        angles.text = "20";
        width.text = "0.5";
        rule1.text = "F=FF";
        rule2.text = "X=F[+X]F[-X]+X";
    }
    public void tmp5Press()
    {
        axiom.text = "X";
        generations.text = "7";
        length.text = "1";
        angles.text = "25.7";
        width.text = "0.5";
        rule1.text = "F=FF";
        rule2.text = "X=F[+X][-X]FX";
    }
    public void tmp6Press()
    {
        axiom.text = "X";
        generations.text = "5";
        length.text = "1";
        angles.text = "22.5";
        width.text = "0.5";
        rule1.text = "F=FF";
        rule2.text = "X=F-[[X]+X]+F[+FX]-X";
    }
    public void tmp7Press()
    {
        axiom.text = "F";
        generations.text = "3";
        length.text = "1";
        angles.text = "25";
        width.text = "0.2";
        rule1.text = "F=FFF[+FFA][-F-FA]F[-FFFF-FFA][+FFA]";
        rule2.text = "";
    }
    public void tmp8Press()
    {
        axiom.text = "FF";
        generations.text = "3";
        length.text = "1";
        angles.text = "120";
        width.text = "0.5";
        rule2.text = "X=XXXXX";
        rule1.text = "F=AF+F+F-FFXF+FXF-FFXF+FF";
    }


}
