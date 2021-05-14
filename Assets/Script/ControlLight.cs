using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLight : MonoBehaviour
{
    public LineRenderer line;
    public bool visible = false;
    private bool big = false;
    // Start is called before the first frame update
    void Start()
    {
        line.enabled = false;
        StartCoroutine(Control());
        //StartCoroutine(ControlSize());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Control()
    {
        while (true)
        {
            if (visible)
            {
                line.enabled = false;
                visible = false;
                yield return new WaitForSeconds(3);
            }
            else
            {
                visible = true;
                line.enabled = true;
                line.SetWidth(0.2f, 0.2f);
                yield return new WaitForSeconds(0.25f);

                line.enabled = false;
                yield return new WaitForSeconds(0.25f);
                line.enabled = true;

                line.SetWidth(0.2f, 0.2f);
                yield return new WaitForSeconds(0.25f);
                line.enabled = false;
                yield return new WaitForSeconds(0.25f);
                line.enabled = true;

                line.SetWidth(1f, 1f);
                yield return new WaitForSeconds(2);
            }

        }
    }
}
