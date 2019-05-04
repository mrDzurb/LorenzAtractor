using UnityEngine;
using System.Collections;

public class soundSpectrator : MonoBehaviour
{

    public AudioListener listener;
    private int bufSize = 128;
    float[] samples;

    // Use this for initialization
    void Start()
    {
        samples = new float[bufSize];
        //call the function every tenth of a second
        //InvokeRepeating("readSound", 0.0, 1.0 / 10.0);
    }

    // Update is called once per frame
    void Update()
    {        
        AudioListener.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

        float maxF = 0f;
        for (int i = 0; i < bufSize-1; ++i)
        {
            if (samples[i] > maxF)
                maxF = samples[i];
        }



        int zigs = (int)(maxF * 1000);
        //if (zigs < 40)
        //    zigs = 40;
        
        //GameObject.Find("Lightning Emitter1").SendMessage("SetZigsCount", zigs);
        //GameObject.Find("Lightning Emitter2").SendMessage("SetZigsCount", zigs);
        //GameObject.Find("Lightning Emitter3").SendMessage("SetZigsCount", zigs);
        //GameObject.Find("Lightning Emitter4").SendMessage("SetZigsCount", zigs);

        
        //Debug.Log(zigs);

        transform.Translate(0, maxF, 0);      


        /*float[] curValues = new float[8];
        for (int i = 0; i < 8; ++i)
        {
            float average = 0;
            //int sampleCount = (int)Mathf.Pow(2, i) * 2;
            for (int j = 0; j < bufSize-1; ++j)            
                average += samples[j] * (j + 1);                          
            //average /= samples;
            //diff = Mathf.Clamp(average * 10 - curValues[i], 0, 4);
            curValues[i] = average;
        }
        Debug.Log(curValues[0].ToString() + "; " + curValues[1].ToString() + "; " + curValues[2].ToString() + "; " + curValues[3].ToString() + "; " + curValues[4].ToString());
        */
        

        

    }


    //private void readSound() {
    ////0 means left channel in a stereo file
    //AudioListener.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

    //for (int i = 0; i < bufSize; i++) {
    //   Debug.Log("sample: " + i + " value: " + samples[i]);
    //}
    //}
}
