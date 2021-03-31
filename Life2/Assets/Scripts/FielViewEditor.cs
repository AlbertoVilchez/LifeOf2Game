using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FielViewEditor : Editor
{
	void OnSceneGUI()
	{
		FielViewMaster foE = (FielViewMaster)target;
		Handles.color = Color.yellow;
		Handles.DrawWireArc(foE.transform.position, Vector3.up, Vector3.forward, 360, foE.viewRadius);
		Vector3 viewAngleA = foE.DirFromAngle(-foE.viewAngle / 2, false);
		Vector3 viewAngleB = foE.DirFromAngle(foE.viewAngle / 2, false);

		Handles.DrawLine(foE.transform.position, foE.transform.position + viewAngleA * foE.viewRadius);
		Handles.DrawLine(foE.transform.position, foE.transform.position + viewAngleB * foE.viewRadius);

		Handles.color = Color.red;
		foreach (GameObject visibleTarget in foE.visibleTargets)
		{
			Handles.DrawLine(foE.transform.transform.position, visibleTarget.transform.position);
		}
	}
}
