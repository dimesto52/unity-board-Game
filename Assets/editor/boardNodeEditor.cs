using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class boardNodeEditor : EditorWindow
{

    [MenuItem("board/Node m3")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        boardNodeEditor window = (boardNodeEditor)EditorWindow.GetWindow(typeof(boardNodeEditor));
        window.Show();
    }

    //repaint manyTime
    public void OnInspectorUpdate()
    {
        if (boardEditor.selectedCell != null)
        {
            this.Repaint();
            
            boardEditor.selectedCell.debug();
            Debug.Log(boardEditor.selectedCell.up);
        }
    }

    // Update is called once per frame
    void OnGUI()
    {
        
        if(boardEditor.selectedCell != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Node : ", EditorStyles.boldLabel);
            GUILayout.Label(boardEditor.selectedCell.debugName);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("position : ", EditorStyles.boldLabel);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("x : ", GUILayout.Width(20));
            float xtry = boardEditor.selectedCell.position.x;
            float.TryParse(GUILayout.TextField(xtry.ToString()), out xtry);
            GUILayout.Label("y : ", GUILayout.Width(20));
            float ytry = boardEditor.selectedCell.position.y;
            float.TryParse(GUILayout.TextField(ytry.ToString()), out ytry);
            GUILayout.Label("z : ", GUILayout.Width(20));
            float ztry = boardEditor.selectedCell.position.z;
            float.TryParse(GUILayout.TextField(ztry.ToString()), out ztry);
            boardEditor.selectedCell.position = new Vector3(xtry, ytry, ztry);
            GUILayout.EndHorizontal();

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            GUILayout.Label("container : ", EditorStyles.boldLabel);
            if (boardEditor.selectedCell.container == null)
            {
                boardEditor.selectedCell.container = new breakCellContainer();
                boardEditor.selectedCell.container.Set_idObj(-1);
            }

            int idcontaine = boardEditor.selectedCell.container.Get_idObj();
            int.TryParse(GUILayout.TextField(idcontaine.ToString()), out idcontaine);
            boardEditor.selectedCell.container.Set_idObj(idcontaine);

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

                GUILayout.BeginHorizontal();
                    GUILayout.Label("add node : ", EditorStyles.boldLabel);
                GUILayout.EndHorizontal();

                GUILayout.BeginVertical();
                    GUILayout.BeginHorizontal();
                        GUILayout.Label(" ", GUILayout.Width(20));
                        GUILayout.Button("+", GUILayout.Width(20));
                        GUILayout.Label(" ", GUILayout.Width(20));
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                        GUILayout.Button("+", GUILayout.Width(20));
                        GUILayout.Label(" ", GUILayout.Width(20));
                        GUILayout.Button("+", GUILayout.Width(20));
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                        GUILayout.Label(" ", GUILayout.Width(20));
                        GUILayout.Button("+", GUILayout.Width(20));
                        GUILayout.Label(" ", GUILayout.Width(20));
                    GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            GUILayout.EndHorizontal();

        }
        else
        {
            GUILayout.Label("no node selected");
        }
    }
}
