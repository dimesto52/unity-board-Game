using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class boardShapeEditor : EditorWindow
{

    [MenuItem("board/board Shape")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        boardShapeEditor window = (boardShapeEditor)EditorWindow.GetWindow(typeof(boardShapeEditor));
        window.Show();
    }

    public void OnInspectorUpdate()
    {
        Repaint();
    }

    public const int cursorSize = 20;
    public int midcursorSize
    {
        get
        {
            return cursorSize / 2;
        }
    }
    boardShape board
    {
        get
        {
            return (boardShape)Selection.activeObject;
        }
    }
    public Vector2 center
    {
        get
        {
            return new Vector2
                (
                        (position.width / 2.0f) - (position.width / 2.0f) % cursorSize + midcursorSize,
                        (position.height / 2.0f) - (position.height / 2.0f) % cursorSize + midcursorSize
                );
        }
    }
    public Vector2 mousseFloor
    {
        get
        {
            return new Vector2
                (
                        (Event.current.mousePosition.x - Event.current.mousePosition.x % cursorSize),
                        (Event.current.mousePosition.y - Event.current.mousePosition.y % cursorSize)
                );
        }
    }

    Vector2 drag = Vector2.zero;

    void drawActivCursor()
    {
        Vector2 vCenter = (mousseFloor - center + new Vector2(midcursorSize, midcursorSize));
        Vector2 vreform = (new Vector2(vCenter.x, -vCenter.y));
        Vector2 vcreat = (vreform / cursorSize);

        bool c = board.getcell((int)vcreat.x, (int)vcreat.y);

        if (c == false)
            board.addcell((int)vcreat.x, (int)vcreat.y);
        else
            board.remove((int)vcreat.x, (int)vcreat.y);

        EditorUtility.SetDirty(board);
    }

    void drawCursor()
    {
        /*
        if (Event.current.type == EventType.MouseDown)
            Debug.Log(Event.current.button);
            */
        if (Event.current.mousePosition.y > 40)
            if (Event.current.type == EventType.MouseDrag)
            {
                if (Vector2.Distance(mousseFloor, drag) > 19.0f)
                {
                    drawActivCursor();
                    drag = mousseFloor;
                }
            }
            else if (Event.current.type == EventType.MouseDown)
            {
                drawActivCursor();
                drag = mousseFloor;
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                drag = Vector2.zero;
            }

        EditorGUI.DrawRect(
            new Rect(
                mousseFloor.x,
                mousseFloor.y,
                cursorSize,
                cursorSize),
            Color.yellow);
    }

    void drawActivBoard()
    {
        if(board != null)
        if (board.rows != null)
            foreach (int x in board.rowsIndex)
            {
                int indexX = board.rowsIndex.IndexOf(x);
                foreach (int y in board.rows[indexX].cols)
                {
                    OnGUINode(x, y, center);
                }
            }
    }
    void OnGUINode(int x, int y, Vector2 center)
    {

        EditorGUI.DrawRect(
            new Rect(
                x * 20 + center.x - 10,
                -y * 20 + center.y - 10,
                20,
                20),
                Color.green);
    }

    void drawLineBoard()
    {
        EditorGUI.DrawRect(new Rect(
                    center.x,
                    40,
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

        int iStart = (int)(-center.x / cursorSize);
        int iEnd = (int)(center.x / cursorSize + 2);
        for (int i = iStart; i < iEnd; i++)
        {

            EditorGUI.DrawRect(new Rect(
                        center.x - midcursorSize + cursorSize * i,
                        40,
                        1,
                        position.height),
                        Color.white);
        }



        //-----------------------------------------------------------------------------

        iStart = (int)(-center.y / cursorSize) + 2;
        iEnd = (int)(center.y / cursorSize + 2);
        for (int i = iStart; i < iEnd; i++)
        {
            EditorGUI.DrawRect(new Rect(
                        0,
                        center.y + midcursorSize + cursorSize * i,
                        position.width,
                        1),
                        Color.white);
        }
    }


    void drawMenu()
    {

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

    void OnGUI()
    {
        if (Selection.activeObject is boardShape)
        {
            drawCursor();
            drawActivBoard();
            drawLineBoard();
            drawMenu();
        }
        else
        {

            GUILayout.Label("no board selected");
        }
    }
}