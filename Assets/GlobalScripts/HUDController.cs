using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    /// <summary>
    /// ////////////////// TOP LEFT VALUES
    /// </summary>
    public GameObject TL;
    public GameObject TLItem1;
    public GameObject TLItem2;

    [SerializeField]
    private bool showTL = true;
    [SerializeField]
    private bool showTLItem2 = true;

    [SerializeField]
    private string TLitemOneName = "Score: ";
    [SerializeField]
    private string TLitemTwoName = "Time Left: ";

    private float TLitem1Num = 0;
    private float TLitem2Num = 0;

    /// <summary>
    /// ////////////////// TOP RIGHT VALUES
    /// </summary>
    public GameObject TR;
    public GameObject TRItem1;

    [SerializeField]
    private bool showTR = true;
    [SerializeField]
    private bool showTRItem1 = true;


    [SerializeField]
    private string TRitemOneName = "Target: ";

    // Start is called before the first frame update
    void Start()
    {
        if(showTL == false)
        {
            TL.SetActive(false);
        }
        else if(showTLItem2 == false)
        {
            TLItem2.SetActive(false);
        }

        if(showTR == false)
        {
            TR.SetActive(false);
        }
        if(showTRItem1 == false)
        {
            TRItem1.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(showTL)
        {
            GameObject textField = TLItem1.transform.GetChild(1).gameObject;
            TextMeshProUGUI mesh = textField.GetComponent<TextMeshProUGUI>();
            mesh.text = TLitemOneName + TLitem1Num;

            if (showTLItem2)
            {
                textField = TLItem2.transform.GetChild(1).gameObject;
                mesh = textField.GetComponent<TextMeshProUGUI>();
                mesh.text = TLitemTwoName + TLitem2Num;

            }
        }

        if(showTR)
        {
            GameObject TRI1Text = TRItem1.transform.GetChild(1).gameObject;
            TextMeshProUGUI mesh = TRI1Text.GetComponent<TextMeshProUGUI>();
            mesh.text = TRitemOneName;
        }
        
    }

    public void set_TLitem_2_number(float num)
    {
        TLitem2Num = Mathf.Round(num * 1000f) / 1000f;
    }

    public void set_TLitem_1_number(float num)
    {
        TLitem1Num = Mathf.Round(num * 100f) / 100f;
    }

    public void set_TL_active(bool val)
    {
        TL.SetActive(val);
    }

    public void set_TR_active(bool val)
    {
        TR.SetActive(val);
    }
}