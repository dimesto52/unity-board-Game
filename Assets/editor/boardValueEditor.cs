using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class boardValueEditor : EditorWindow
{

    [MenuItem("board/board value Int")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        boardValueEditor window = (boardValueEditor)EditorWindow.GetWindow(typeof(boardValueEditor));
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
    tableIntContainer board
    {
        get
        {
            return (tableIntContainer)((boardValueInt)Selection.activeObject).container;
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
        if (Selection.activeObject is boardValueInt)
        {
            drawCursor();
            drawLineBoard();
            drawActivBoard();
            drawMenu();
        }
        else
        {

            GUILayout.Label("no board selected");
        }
    }

    void drawActivBoard()
    {
        if (board != null)
            if (board.rows != null)
                foreach (int x in board.rowsIndex)
                {
                    int indexX = board.rowsIndex.IndexOf(x);
                    foreach (int y in board.rows[indexX].colsIndex)
                    {
                        int value = board.getcell(x,y);

                        OnGUINode(x, y, center,value);
                    }
                }
    }

    void OnGUINode(int x, int y, Vector2 center,int value)
    {
        GUIStyle s = new GUIStyle(EditorStyles.textField);
        s.normal.textColor = Color.white;
        s.fontSize = (cursorSize / value.ToString().Length)-1;

        EditorGUI.LabelField(
            new Rect(
                x * cursorSize + center.x - midcursorSize,
                -y * cursorSize + center.y - midcursorSize,
                cursorSize,
                cursorSize),
                value.ToString(),s);
    }


    Vector2 drag = Vector2.zero;
    void drawCursor()
    {
        modCursor mod = modCursor.clear;

        if (Event.current.type == EventType.MouseDown)
            if (Event.current.button == 0) mod = modCursor.add;
            else if (Event.current.button == 1) mod = modCursor.remove;
            else if (Event.current.button == 2) mod = modCursor.clear;

        if (Event.current.mousePosition.y > 40)
            if (Event.current.type == EventType.MouseDrag)
            {
                if (Vector2.Distance(mousseFloor, drag) > 19.0f)
                {
                    drawActivCursor(mod);
                    drag = mousseFloor;
                }
            }
            else if (Event.current.type == EventType.MouseDown)
            {
                drawActivCursor(mod);
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

    void drawActivCursor(modCursor cursor)
    {
        Vector2 vCenter = (mousseFloor - center + new Vector2(midcursorSize, midcursorSize));
        Vector2 vreform = (new Vector2(vCenter.x, -vCenter.y));
        Vector2 vcreat = (vreform / cursorSize);

        int c = board.getcell((int)vcreat.x, (int)vcreat.y);

        if(cursor == modCursor.add)
            board.setcell((int)vcreat.x, (int)vcreat.y, c+1);
        else if (cursor == modCursor.remove)
        {
            if (c > -1)
                board.setcell((int)vcreat.x, (int)vcreat.y, c - 1);
            else
                board.remove((int)vcreat.x, (int)vcreat.y);
        }
        else if (cursor == modCursor.clear)
            board.remove((int)vcreat.x, (int)vcreat.y);


        EditorUtility.SetDirty(Selection.activeObject);
    }

    public enum modCursor
    {
        add, remove, clear
    }

}
