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

        }
    }

    // Update is called once per frame
    void OnGUI()
    {

        if (boardEditor.selectedCell != null)
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
                    if(GUILayout.Button("+", GUILayout.Width(20))) addUp(boardEditor.selectedCell);
                    GUILayout.Label(" ", GUILayout.Width(20));
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                    if (GUILayout.Button("+", GUILayout.Width(20))) addLeft(boardEditor.selectedCell);
                    GUILayout.Label(" ", GUILayout.Width(20));
                    if (GUILayout.Button("+", GUILayout.Width(20))) addRight(boardEditor.selectedCell);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                    GUILayout.Label(" ", GUILayout.Width(20));
                    if (GUILayout.Button("+", GUILayout.Width(20))) addDown(boardEditor.selectedCell);
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

    void addUp(Cell c)
    {
        Vector2 vect = new Vector2(c.pos.x, c.pos.y + 1);

        c.boardO.addcell((int)vect.x, (int)vect.y);
        boardEditor.selectedCell = c.boardO.getcell((int)vect.x, (int)vect.y);

        EditorUtility.SetDirty(c.boardO);

        SceneView.RepaintAll();
        EditorWindow.GetWindow<SceneView>().Repaint();
        HandleUtility.Repaint();
    }
    void addDown(Cell c)
    {
        Vector2 vect = new Vector2(c.pos.x, c.pos.y - 1);

        c.boardO.addcell((int)vect.x, (int)vect.y);
        boardEditor.selectedCell = c.boardO.getcell((int)vect.x, (int)vect.y);

        EditorUtility.SetDirty(c.boardO);

        SceneView.RepaintAll();
        EditorWindow.GetWindow<SceneView>().Repaint();
        HandleUtility.Repaint();
    }
    void addLeft(Cell c)
    {
        Vector2 vect = new Vector2(c.pos.x - 1, c.pos.y);

        c.boardO.addcell((int)vect.x, (int)vect.y);
        boardEditor.selectedCell = c.boardO.getcell((int)vect.x, (int)vect.y);

        EditorUtility.SetDirty(c.boardO);

        SceneView.RepaintAll();
        EditorWindow.GetWindow<SceneView>().Repaint();
        HandleUtility.Repaint();
    }
    void addRight(Cell c)
    {
        Vector2 vect = new Vector2(c.pos.x + 1, c.pos.y);

        c.boardO.addcell((int)vect.x, (int)vect.y);
        boardEditor.selectedCell = c.boardO.getcell((int)vect.x, (int)vect.y);

        EditorUtility.SetDirty(c.boardO);

        SceneView.RepaintAll();
        EditorWindow.GetWindow<SceneView>().Repaint();
        HandleUtility.Repaint();
    }
}
