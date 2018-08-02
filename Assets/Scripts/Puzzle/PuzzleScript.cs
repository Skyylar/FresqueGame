 using System;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

public class PuzzleScript : MonoBehaviour {

    // Control Timer of games
    public static float TimeG;
    public static bool timerstarted = true;

    // Get Texture of puzzle and material where texture was apply
    public Texture2D tex;
    public Material mat;

    // Set Number of columns
    private int cols = 5;

    // Set Description of Puzzle image
    private string desc = "Symbole architectural de la suprématie athénienne à l'époque classique, le Parthénon est probablement le temple qui a le plus inspiré les architectes néo-classiques. Il a servi de modèle dans de nombreux pays occidentaux";

    // Set Aspect, permit the cut of puzzle piece
    private float aspect = 1f;
	
    // Offset of each pieces
 	private Vector3 offset;

    // Piece one and piece two for swap
    private GameObject piece_pos_1;
    private GameObject piece_pos_2;

    // List of coordinate of piece resolve
    private List<CoOrds> puzzle_coord_v = new List<CoOrds>();

    // Storage of score
    private float score;

    /// <summary>
    ///  structur for get CoOrds 
    /// </summary>
    public struct CoOrds
    {
        public float x, y;

        public CoOrds(float p1, float p2)
        {
            x = p1;
            y = p2;
        }
    }

    /// <summary>
    ///     Start this instance.
    /// </summary>
    void Start() {
        start_desc();
        reset_pos();
        mat.mainTexture = tex;
        set_cadre();
        BuildPieces();
        get_coord_before_start();
        swap_all_pieces();
    }

    /// <summary>
    ///     Update this instance.
    /// </summary>
    void Update()
    {
        // Start timer
        if (timerstarted == true) 
        {
            TimeG += Time.deltaTime;
        }
        // get input of mouse click if score not set
        if (Input.GetMouseButtonDown(0) && score == 0)
        {
            // get first piece
            if (piece_pos_1 == null)
            {
                GameObject target_1 = getTarget();
                if (target_1 != null)
                {
                    piece_pos_1 = target_1;
                    setEmission(piece_pos_1, true);
                }
            }
            // get second piece for swap
            else if (piece_pos_2 == null)
            {
                GameObject target_2 = getTarget();
                if (target_2 != null)
                {
                    piece_pos_2 = target_2;
                    swap_piece();
                }
                setEmission(piece_pos_1, false);
                reset_pos();
                int val = verify_puzzle();
                // game end
                if (val == 1)
                {
                    timerstarted = false;
                    desc_enable();
                    if (score == 0) 
                    {
                        score = Map(TimeG, 300, 25, 0, 20);
                        GameManager.NotePuzzle = (int)score;
                        GameManager.NumberNote += 1;
                    }
                }
            }
        }
    }

    /// <summary>
    ///     Get value between out_min and out_max thanks to another value between in_min and in_max
    /// </summary>
    /// <returns>The map.float</returns>
    /// <param name="x">The x coordinate.</param>
    /// <param name="in_min">In minimum.</param>
    /// <param name="in_max">In max.</param>
    /// <param name="out_min">Out minimum.</param>
    /// <param name="out_max">Out max.</param>
    private float Map(float x, int in_min,int in_max,int out_min,int out_max) 
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    /// <summary>
    ///     Add/Delete light effect on selected piece of puzzle  
    /// </summary>
    /// <param name="go">Go.</param>
    /// <param name="value">If set to <c>true</c> value.</param>
    void setEmission(GameObject go, bool value) 
    {
        Color finalColor = Color.black;
        if (value == true) 
        {
            float emission = Mathf.PingPong (Time.time, 1.0f);
            finalColor = new Color(0.2F, 0.3F, 0.4F, 0.5F) * Mathf.LinearToGammaSpace (emission);
        } else 
        {
            float emission = Mathf.PingPong (Time.time, 1.0f);
            finalColor = Color.black * Mathf.LinearToGammaSpace (emission);
        }
        Material m = go.GetComponent<Renderer>().material;
        m.EnableKeyword ("_EmissionColor");
        m.SetColor ("_EmissionColor", finalColor);
    }

    /// <summary>
    ///    Spawn description of puzzle picture
    ///    Disable display of description
    /// </summary>
    void start_desc() 
    {
        GameObject go = GameObject.Find("desc_canvas");
        Image image = go.GetComponent<Image>();
        image.enabled = false;
        GameObject go1 = GameObject.Find("desc");
        Text Text = go1.GetComponent<Text>();
        Text.text = desc;
        Text.enabled = false;
    }

    /// <summary>
    ///     Activate display of description
    /// </summary>
    void desc_enable() 
    {
        GameObject go1 = GameObject.Find("desc");
        Text text = go1.GetComponent<Text>();
        text.enabled = true;
        GameObject go = GameObject.Find("desc_canvas");
        Image image = go.GetComponent<Image>();
        if (image)
            image.enabled = !image.enabled;
    }

    /// <summary>
    ///     Get coordinate of all puzzle before sort of pieces
    ///     Récupere les coordonnées du tout le puzzle avant le tri de celle-ci
    /// </summary>
    void get_coord_before_start() 
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Puzzle_board");
        foreach (GameObject go in gos) 
        {
            puzzle_coord_v.Add(new CoOrds(go.transform.position.x, go.transform.position.y));
        }
    }

    /// <summary>
    ///     Check if puzzle is valid
    /// </summary>
    /// <returns>The puzzle.int</returns>
    int verify_puzzle() {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Puzzle_board");
        int check = 0;
        for (int i = 0; i < gos.Length; i++) 
        {
            if (gos[i].transform.position.x == puzzle_coord_v[i].x) 
            {
                if (gos[i].transform.position.y == puzzle_coord_v[i].y) 
                {
                    check++;
                }
            }
        }
        if (check == gos.Length) 
        {
            return 1;
        }
        return 0;
    }

    /// <summary>
    ///    Generates a black frame around the image
    /// </summary>
    void set_cadre() 
    {
        for (int p = 0; p < 4; p++) 
        {
            for (int x = 0; x < tex.width; x++)
                tex.SetPixel(x, p, Color.black);
            for (int x = 0; x < tex.width; x++)
                tex.SetPixel(x, tex.height - p, Color.black);
            for (int x = 0; x < tex.height; x++)
                tex.SetPixel(p, x, Color.black);
            for (int x = 0; x < tex.height; x++)
                tex.SetPixel(tex.width - p, x, Color.black);
        }
        tex.Apply();
    }

    void reset_pos() 
    {
        piece_pos_1 = null;
        piece_pos_2 = null;
    }

    /// <summary>
    ///    Check if coordinate of piece is in List
    /// </summary>
    /// <returns>If coord exist</returns>
    /// <param name="coord">Coordinate.</param>
    /// <param name="a">The alpha component.</param>
    /// <param name="b">The blue component.</param>
    int getNewCoord(Dictionary<int, CoOrds> coord, int a, int b) 
    {
        foreach (KeyValuePair<int, CoOrds> array in coord)
            {
                if ((array.Value.x == a && array.Value.y == b)) 
                {
                    return 1;
                }
            }
        return 0;
    }

    /// <summary>
    ///     Mixing puzzle
    /// </summary>
    void swap_all_pieces() 
    {
        int rows = Mathf.RoundToInt(cols * aspect);
        Dictionary<int, CoOrds> coord = new Dictionary<int, CoOrds>();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Puzzle_board");
        int i = 0;
        foreach (GameObject go in gos) 
        {
            int new_row = UnityEngine.Random.Range(-2, rows - 3);
            int new_col = UnityEngine.Random.Range(-2, cols - 3);
            while (getNewCoord(coord, new_row, new_col) == 1) 
            {
                new_row = UnityEngine.Random.Range(-2, rows - 2);
                new_col = UnityEngine.Random.Range(-2, cols - 2);
            }
            coord.Add(i, new CoOrds(new_row, new_col));
            go.transform.position = new Vector3( new_col, new_row, 0);
            i++;
        }

    }

    /// <summary>
    ///     Swap position of two pieces
    /// </summary>
    void swap_piece() 
    {
        String name_1 = piece_pos_1.name;
        String name_2 = piece_pos_2.name;
        String temp = name_1;

        name_1 = name_2;
        name_2 = temp;

        Vector3 Temp_pos = piece_pos_1.transform.position;
        piece_pos_1.transform.position = piece_pos_2.transform.position;
        piece_pos_2.transform.position = Temp_pos;
        Temp_pos = new Vector3(0, 0, 0);
    }

    /// <summary>
    ///     Get GameObject selected
    /// </summary>
    /// <returns>The target.</returns>
    GameObject getTarget() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)) 
        {
            GameObject target = hit.collider.gameObject;
            if (target.tag == "Puzzle_board") 
            {
                return target;
            } else 
            {
                return null;
            }
        }
        return null;
    }

    /// <summary>
    ///     Cut material and create few piece of puzzle
    /// </summary>
    void BuildPieces() 
    {
        int rows = Mathf.RoundToInt(cols * aspect);
        Vector3 offset = Vector3.zero;
        offset.x = -Mathf.RoundToInt ((float)cols / 2.0f - 0.5f);
        offset.y = -Mathf.RoundToInt ((float)rows / 2.0f - 0.5f);
        float startX = offset.x;
        float uvWidth = 1.0f / cols;
        float uvHeight = 1.0f / rows;

        // Generate pieces by lines
        for (int i = 0; i < rows; i++) 
        {
            // Generate pieces by columns
            for (int j = 0; j < cols; j++) 
            {
                // Create GameObject of one piece
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                go.name = "piece_" + i + "_" + j;
                go.tag = "Puzzle_board";
                Transform t = go.transform;
                t.position = offset;
                t.localScale = new Vector3(0.95f, 0.95f, 0.95f);
                go.GetComponent<Renderer>().material = mat;

                // Ajoute la texture découper
                Mesh mesh = go.GetComponent<MeshFilter>().mesh;
                Vector2[] uvs = mesh.uv;
                uvs[0] = new Vector3(j * uvWidth, i * uvHeight);
                uvs[1] = new Vector3((j + 1) * uvWidth, (i + 1) * uvHeight);
                uvs[2] = new Vector3((j + 1) * uvWidth, i * uvHeight);
                uvs[3] = new Vector3(j * uvWidth, (i + 1) * uvHeight);
                mesh.uv = uvs;
                offset.x += 1.0f;
            }
            offset.y += 1.0f;
            offset.x = startX;
        }
    }
}
