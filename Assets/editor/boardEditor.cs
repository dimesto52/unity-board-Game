using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(m3BoardData))]
public class boardEditor : Editor
{

    m3BoardData board;

    public static Cell selectedCell;

    void OnEnable()
    {
        board = (m3BoardData)target;
        if (board.cells.Length == 0)
            board.generate();
    }


    void OnSceneGUI()
    {
        Draw();
    }

    void Draw()
    {
        for (int i = 0; i < board.cells.Length; i++)
        {
            float size;
            var pos = board.cells[i].position;
            size = HandleUtility.GetHandleSize(pos);
            HandleUtility.GetHandleSize(Vector3.one);

            int controlId = GUIUtility.GetControlID(FocusType.Passive);

            if (selectedCell == board.cells[i])
                Handles.color = Color.red;
            else
                Handles.color = Color.white;

            Handles.FreeMoveHandle(controlId, pos, Quaternion.identity, 0.25f, pos, Handles.SphereHandleCap);

            Handles.Label(pos, board.cells[i].debugName);

            if (controlId == GUIUtility.hotControl)
            {
                //Debug.Log("The button was pressed! at " + board.cells[i].debugName);
                selectedCell = board.cells[i];
            }
        }
        Handles.color = Color.white;
    }
}
