using gamin2.Render;
using SIMp.Render;
using SSSystemGenerator.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamin2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private Color background = Color.DarkGreen;
        private Color foreground = Color.DarkGray;
        private static List<List<Tile>> map = Map.GetMap();// https://www.tutorialsteacher.com/csharp/csharp-jagged-array        
        private static List<Entity> entities = Map.GetEntities();

        public PBRenderer PanelDrawer { get; private set; }

        private void Main_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            int minCoordinate = -15;
            int maxCoordinate = 15;

            for (int r = minCoordinate; r < maxCoordinate; r++) // right+
            { // https://www.redblobgames.com/grids/hexagons/
                map.Add(new List<Tile>());

                for (int q = minCoordinate; q < maxCoordinate; q++) // up+
                {
                    map[r - minCoordinate].Add(new Tile().SetLoc(new PointF(r, q)));
                }

            }

            entities.Add(new Entity("CHAR").SetCharacter('@').SetForegroundColor(Color.YellowGreen) as Entity);

            RefreshPanel();
        }

        public void RefreshPanel()
        {

            if (PanelDrawer == null)
            {
                //https://stackoverflow.com/a/60247726
                PanelDrawer = new PBRenderer(Screen, new PaintEventArgs(Screen.CreateGraphics(), Screen.DisplayRectangle));

                PanelDrawer.rendererValues = new RendererBaseClass();
            }


            AddValuesToRenderer();

            Screen.Invalidate();
        }

        private void AddValuesToRenderer()
        {
            Font ourFont = new Font(FontFamily.GenericSansSerif, 1, FontStyle.Regular);

            SolidBrush brush = new SolidBrush(Color.White);

            //

            int screenHeight = Screen.Height;
            int screenWidth = Screen.Width;
            int tileSize = (int)screenHeight / 10;

            double sqrt3 = Math.Sqrt(3);

            float hexWidth = 3f / 2f * tileSize;
            float hexHeight = (float)(sqrt3 * tileSize);

            PointF xTransform = new PointF(hexWidth, hexHeight / 2f);
            PointF yTransform = new PointF(1f, hexHeight);

            RendererBaseClass values = PanelDrawer.rendererValues;

            map.ForEach(row =>
            {
                row.ForEach(tile =>
                {

                    PointF loc = tile.loc;

                    PointF renderLoc = CoordinateHelper.ReturnRenderLocation(loc, Screen);


                    values.Drawables.Add(
                        new Hex(
                            renderLoc,
                            tileSize,
                            1,
                            tile.foregroundColor
                            ).SetInteriorColor(tile.backgroundColor)
                        );

                    values.Drawables.Add(

                        new Text(tile.Character.ToString(), new Font(FontFamily.GenericMonospace, 20), new SolidBrush(tile.foregroundColor), renderLoc)
                        );

                });
            });

            entities.ForEach(e =>
            {
                PointF renderLoc = CoordinateHelper.ReturnRenderLocation(e.loc, Screen);

                values.Drawables.Add(
                    new Text(e.Character.ToString(), new Font(FontFamily.GenericMonospace, 20), new SolidBrush(e.foregroundColor), renderLoc)
                );
            });

            PanelDrawer.BackgroundColor = Color.Black;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {//https://stackoverflow.com/a/31464086
            int moveAmount = 1;
            switch (keyData)
            {
                #region move

                case Keys.NumPad1://go down left by 100 (not sqrted)
                    Move(-moveAmount, moveAmount);
                    break;
                case Keys.NumPad2://go down
                case Keys.Down:
                    Move(0, moveAmount);
                    break;
                case Keys.NumPad3://go down right
                    Move(moveAmount, 0);
                    break;

               
                //no 4, cope 
                //no 5, cope 
                //no 6, cope 
                

                case Keys.NumPad7://go down left by 100 (not sqrted)
                    Move(-moveAmount, 0);
                    break;
                case Keys.NumPad8://go down
                case Keys.Up:
                    Move(0, -moveAmount);
                    break;
                case Keys.NumPad9://go down right
                    Move(moveAmount, -moveAmount);
                    break;

                #endregion

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void Move(int x, int y)
        {
            Entity entity = entities.FirstOrDefault(e => e.GetID() == "CHAR");

            entity?.Move(x, y);

            RefreshPanel();
        }

    }
}
