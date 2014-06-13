using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[ExecuteInEditMode, RequireComponent(typeof(CurvySpline))]
public class SplineFromFileAll : MonoBehaviour {
	
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

			List<CurvySpline> allSplines = new List<CurvySpline>();

			foreach (var line in lines)
			{
				
				string[] coords = line.Split(' ');

				if(coords[0] == "newTrack"){
					//mSpline.Clear();
					//mSpline.Add(Points.ToArray());

					// create new spline object, fill/create bz list of vector3 elements
					// add new spline object to gameobject

					//allSplines.Add(mSpline);

					// delete vector3 list after creating spline out of it
					Points.Clear();
				}else if(coords.Length == 3){
					Points.Add(new Vector3(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2])));
				}

			}
		}
	} 
}
