using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldofviewPlayer))]
public class FielOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldofviewPlayer fow = (FieldofviewPlayer)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position,Vector3.up,Vector3.forward,360, fow.viewRadius);
        Vector3 viewAngleA = fow.DirFromAngle(-fow.ViewAngle / 2, false);
        Vector3 ViewAngleB = fow.DirFromAngle(fow.ViewAngle / 2, false);

        Handles.DrawLine(fow.transform.position,fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + ViewAngleB * fow.viewRadius);

        foreach (Transform VisTarget in fow.VisibleTarget)
        {
            Handles.DrawLine(fow.transform.position,VisTarget.position);
        }
    }
}
