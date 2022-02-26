using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

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

        //clear
        int controlId = GUIUtility.GetControlID(FocusType.Passive);
        Handles.FreeMoveHandle(controlId, new Vector3(1.0f, 1.0f, 0) * 10.0f, Quaternion.identity, 0.25f, new Vector3(1.0f, 1.0f, 0) * 10.0f, Handles.SphereHandleCap);

        if (controlId == GUIUtility.hotControl)
        {
            board.obj.clearCell();
            Debug.Log(board.obj.rows.Count);
        }

        //add center
        controlId = GUIUtility.GetControlID(FocusType.Passive);
        Handles.FreeMoveHandle(controlId, new Vector3(1.0f, 1.0f, 0) * 10.0f - Vector3.up, Quaternion.identity, 0.25f, new Vector3(1.0f, 1.0f, 0) * 10.0f - Vector3.up, Handles.SphereHandleCap);

        if (controlId == GUIUtility.hotControl)
        {
            board.obj.addcell(0, 0);
            Debug.Log(board.obj.rows.Count);
        }

        for (int x = 0; x < board.obj.rowCount; x++)
            for (int y = 0; y < board.obj.rows[x].colCount; y++)
            {
                float size;
                Cell c = board.obj.getcell(x, y);
                Vector3 pos = c.position;
                size = HandleUtility.GetHandleSize(pos);
                HandleUtility.GetHandleSize(Vector3.one);

                controlId = GUIUtility.GetControlID(FocusType.Passive);

                if (selectedCell == c)
                    Handles.color = Color.red;
                else
                    Handles.color = Color.white;

                Handles.FreeMoveHandle(controlId, pos, Quaternion.identity, 0.25f, pos, Handles.SphereHandleCap);

                Handles.Label(pos, c.pos.ToString());

                if (controlId == GUIUtility.hotControl)
                {
                    //Debug.Log("The button was pressed! at " + board.cells[i].debugName);
                    selectedCell = c;

                }

            }
                if (boardEditor.selectedCell != null)
                {
                    boardEditor.selectedCell.debug();

                    EditorUtility.SetDirty(board);
                    SceneView.RepaintAll();
                }
        Handles.color = Color.white;
    }
}
