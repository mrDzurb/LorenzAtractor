using UnityEngine;
using System.Collections;
using System;

public class LorenzAttractor : MonoBehaviour {

    public LineRenderer lRenderer;
    public GameObject goLorenzObject;

    public AudioListener listener;
    private int bufSize = 256;
    float[] samples;
    float step = 1;

    float h = 0.008f;        // lorenz
    float a = 10.0f;        // sigma
    float b = 28.0f;        
    float x0=0.1f, y0=0, z0=0, x1=0, y1=0, z1=0;


	// Use this for initialization
	void Start () {
        samples = new float[bufSize];


        //lRenderer.SetVertexCount(8000);
        //GenerateLorenz(8000,10f);
       // lRenderer.SetVertexCount(9000);
        //Generate(250, 150, 8000);

	}
	
	// Update is called once per frame
	void Update () {

        AudioListener.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
        float maxF = 0f;
        //for (int i = 0; i < bufSize - 1; ++i)
        //    maxF += samples[i];
        //maxF /= bufSize;
        //int zigs = (int)(maxF * 160000);
        for (int i = 0; i < bufSize - 1; ++i)
            if (samples[i] > maxF)
                maxF = samples[i];
        int zigs = (int)(maxF * 20000);


       

        
        //Debug.Log(zigs);
        //lRenderer = new LineRenderer();
        lRenderer.SetVertexCount(0);
        lRenderer.SetVertexCount(zigs);
        
        //Generate(650, 350, zigs);
       // goLorenzObject.transform.rotation = Quaternion.Euler(0, 90, 0);

        if (Input.GetKeyDown(KeyCode.Q)) h += 0.001f;
        if (Input.GetKeyDown(KeyCode.A)) h -= 0.001f;
        if (Input.GetKeyDown(KeyCode.W)) a += 1f;
        if (Input.GetKeyDown(KeyCode.S)) a -= 1f;
        if (Input.GetKeyDown(KeyCode.E)) b += 1f;
        if (Input.GetKeyDown(KeyCode.D)) b -= 1f;

        if (Input.GetKeyDown(KeyCode.R)) x0 += 0.1f;
        if (Input.GetKeyDown(KeyCode.F)) x0 -= 0.1f;
        if (Input.GetKeyDown(KeyCode.T)) y0 += 1f;
        if (Input.GetKeyDown(KeyCode.G)) y0 -= 1f;
        if (Input.GetKeyDown(KeyCode.Y)) z0 += 1f;
        if (Input.GetKeyDown(KeyCode.H)) z0 -= 1f;


        GenerateLorenz(zigs, h,a,b, x0, y0,z0);


	}


    public void GenerateLorenz(int N, float h = 0.008f, float a = 10.0f, float b = 28.0f,float x0 = 0.1f, float y0=0, float z0=0, float x1=0, float y1=0, float z1=0)
    {
        int i = 0;
        //float x0, y0, z0, x1, y1, z1;
        /*float h = 0.008f;        // lorenz
        float a = 10.0f;        // sigma
        float b = 28.0f;  
         */
        float c = 8.0f / 3.0f;  // betta

        //x0 = 0.1f;
        //y0 = 0;
        //z0 = 0;        
        
        for (i = 200; i < N; i++)
        {
            x1 = x0 + h * a * (y0 - x0);
            y1 = y0 + h * (x0 * (b - z0) - y0);
            z1 = z0 + h * (x0 * y0 - c * z0);

            lRenderer.SetPosition(i, new Vector3(x1*2, y1*2, z1*2));
           // lRenderer.transform.Rotate(new Vector3(0, 1, 0) * 1000*Time.deltaTime);
            x0 = x1;
            y0 = y1;
            z0 = z1;
        }
    }

   

}
