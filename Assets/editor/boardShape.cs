using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class boardShape : EditorWindow
{

    [MenuItem("board/board Shape")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        boardShape window = (boardShape)EditorWindow.GetWindow(typeof(boardShape));
        window.Show();
    }

    public void OnInspectorUpdate()
    {

        Repaint();
    }

    void OnGUI()
    {
        if (Selection.activeObject is boardObject)
        {
            boardObject board = (boardObject)Selection.activeObject;

            Vector2 center = new Vector2
                (
                        (position.width / 2.0f) - (position.width / 2.0f) % 20 + 10,
                        (position.height / 2.0f) - (position.height / 2.0f) % 20 + 10
                );

            int xFloor = (int)(Event.current.mousePosition.x - Event.current.mousePosition.x % 20);
            int yFloor = (int)(Event.current.mousePosition.y - Event.current.mousePosition.y % 20);

            if (GUI.Button(new Rect(xFloor, yFloor, 20, 20), ""))
            {
                Vector2 vFloor = (new Vector2(xFloor, yFloor));
                Vector2 vCenter = (vFloor - center + new Vector2(10,10)) ;
                Vector2 vreform = (new Vector2(vCenter.x, -vCenter.y));
                Vector2 vcreat = (vreform / 20);

                /*
                Debug.Log("yFloor : " + yFloor + "|" + "center.y :" + center.y);
                Debug.Log("vcreat :" + (vcreat).ToString());
                Debug.Log("vFloor :" + (vFloor).ToString());
                Debug.Log("vCenter :" + (vCenter).ToString());
                Debug.Log("vreform :" + (vreform).ToString());
                */
                Cell c =board.getcell((int)vcreat.x, (int)vcreat.y);

                if (c == null)
                    board.addcell((int)vcreat.x, (int)vcreat.y);
                else
                    board.remove((int)vcreat.x, (int)vcreat.y);

                EditorUtility.SetDirty(board);
            }
            

            EditorGUI.DrawRect(
                new Rect(
                    xFloor,
                    yFloor,
                    20,
                    20),
                Color.yellow);

            if(board.rows != null)
            foreach (int x in board.rows.Keys)
            {
                foreach (int y in board.rows[x].cols.Keys)
                {
                    OnGUINode(x, y, center);
                }
            }


            EditorGUI.DrawRect(new Rect(
                        center.x,
                        0,
                        1,
                        position.height),
                        Color.blue);
            EditorGUI.DrawRect(new Rect(
                        0,
                        center.y,
                        position.width,
                        1),
                        Color.blue);

            //------------------------------------------------------------------------


            int iStart = (int)(-center.x / 20 + 1);
            int iEnd = (int)(center.x / 20 + 1);
            for (int i = iStart; i < iEnd; i++)
            {

                EditorGUI.DrawRect(new Rect(
                            center.x - 10 + 20 * i,
                            0,
                            1,
                            position.height),
                            Color.white);
            }



            //-----------------------------------------------------------------------------

            iStart = (int)(-center.y / 20 + 1);
            iEnd = (int)(center.y / 20 + 1);
            for (int i = iStart; i < iEnd; i++)
            {
                EditorGUI.DrawRect(new Rect(
                            0,
                            center.y + 10 + 20 * i,
                            position.width,
                            1),
                            Color.white);
            }


            GUILayout.BeginHorizontal();
            GUILayout.Label("Board : ", EditorStyles.boldLabel);
            GUILayout.Label(Selection.activeObject.name);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("clear"))
            {
                board.clearCell();
            }
            GUILayout.Label(Event.current.mousePosition.ToString());
            GUILayout.EndHorizontal();
        }
        else
        {

            GUILayout.Label("no board selected");
        }
    }

    void OnGUINode( int x, int y, Vector2 center)
    {

        EditorGUI.DrawRect(
            new Rect(
                x*20+center.x-10,
                -y * 20 + center.y-10,
                20,
                20),
                Color.green);
    }
}