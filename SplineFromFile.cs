using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[ExecuteInEditMode, RequireComponent(typeof(CurvySpline))]
public class SplineFromFile : MonoBehaviour {

    public TextAsset File;

    CurvySpline mSpline;

    void Awake()
    {
        mSpline = GetComponent<CurvySpline>();
    }

    public void ReadFile()
    {
        if (mSpline && File)
        {
            mSpline.Clear();
            string[] lines = File.text.Split('\n');
            List<Vector3> Points = new List<Vector3>();

            foreach (var line in lines)
            {
                string[] coords = line.Split(' ');
				//Debug.Log(coords.Length.ToString);
				if(coords.Length == 3){
					Points.Add(new Vector3(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2])));
				}
			}

            mSpline.Add(Points.ToArray());
        }
    } 

}
