using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class FormLifeGame : Form
    {

        public const int INDEX0 = 0;
        public const int INDEX1 = 1;
        public const int INDEX2 = 2;       

        public const int DEFAULTSEED = 0;

        public const int CELL_ROW = 240;
        public const int CELL_COLUMN = 320;
        public const int SQUARE_SIDE = 2;

        public const int STATENB0 = 0;
        public const int STATENB1 = 1;
        public const int STATENB2 = 2;
        public const int STATENB3 = 3;
        public const int STATENB4 = 4;
        public const int STATENB5 = 5;
        public const int STATENB6 = 6;
        public const int STATENB7 = 7;

        public const int BRUSHES = 8;

        public const int BRUSH0 = 0;
        public const int BRUSH1 = 1;
        public const int BRUSH2 = 2;
        public const int BRUSH3 = 3;
        public const int BRUSH4 = 4;
        public const int BRUSH5 = 5;
        public const int BRUSH6 = 6;
        public const int BRUSH7 = 7;
        
        private int iPalette;
        private int iRule;
        private int iGens;
        private int iSeed;
        private uint iHash;
        private int iGenNb = 0;
        private bool bReady = false;

        Bitmap buffer = null;
        Graphics panelGraphics = null;
        Graphics bufferGraphics = null;

        Brush aquaBrush;
        Brush redBrush;
        Brush yellowBrush;
        Brush blueBrush;
        Brush greenBrush;
        Brush purpleBrush;
        Brush orangeBrush;
        Brush greenYellowBrush;
        Brush pinkBrush;
        Brush skyBlueBrush;
        Brush chartreuseBrush;
        Brush peachPuffBrush;
        Brush plumBrush;
        Brush blackBrush;
        Brush maroonBrush;
        Brush darkRedBrush;
        Brush brownBrush;
        Brush firebrickBrush;

        Rectangle[,] squares;

        Brush[] BrushOfPalette00;
        Brush[] BrushOfPalette01;
        Brush[] BrushOfPalette02;



        public FormLifeGame()
        {
            InitializeComponent();
            createGraphicResourses();

            comboBoxRules.SelectedIndex = 0;
            iPalette = 0;
            comboBoxColors.SelectedIndex = 0;
            iRule = 0;
            textBoxSeed.Text = string.Format("{0}", DEFAULTSEED);
            textBoxGens.Text = "100";
            bReady = true;

            CellArray myCellArray = CellArray.getMyCellArray();
            iSeed = DEFAULTSEED;

            // initialise squares array
            squares = new Rectangle[CELL_ROW, CELL_COLUMN];

            //create brushes
            aquaBrush = new SolidBrush(Color.Aqua);
            redBrush = new SolidBrush(Color.Red);
            yellowBrush = new SolidBrush(Color.Yellow);
            blueBrush = new SolidBrush(Color.Blue);
            greenBrush = new SolidBrush(Color.Green);
            purpleBrush = new SolidBrush(Color.Purple);
            orangeBrush = new SolidBrush(Color.Orange);
            greenYellowBrush = new SolidBrush(Color.GreenYellow);
            pinkBrush = new SolidBrush(Color.Pink);
            chartreuseBrush = new SolidBrush(Color.Chartreuse);
            peachPuffBrush = new SolidBrush(Color.PeachPuff);
            plumBrush = new SolidBrush(Color.Plum);
            skyBlueBrush = new SolidBrush(Color.SkyBlue);
            blackBrush = new SolidBrush(Color.Black);
            maroonBrush = new SolidBrush(Color.Maroon);
            darkRedBrush = new SolidBrush(Color.DarkRed);
            firebrickBrush = new SolidBrush(Color.Firebrick);
            brownBrush = new SolidBrush(Color.Brown);

            //create arrays to store brushes for every palette
            //to make the program run faster
            BrushOfPalette00 = new Brush[BRUSHES];
            BrushOfPalette00[BRUSH0] = redBrush;
            BrushOfPalette00[BRUSH1] = orangeBrush;
            BrushOfPalette00[BRUSH2] = yellowBrush;
            BrushOfPalette00[BRUSH3] = greenYellowBrush;
            BrushOfPalette00[BRUSH4] = greenBrush;
            BrushOfPalette00[BRUSH5] = aquaBrush;
            BrushOfPalette00[BRUSH6] = blueBrush;
            BrushOfPalette00[BRUSH7] = purpleBrush;

            BrushOfPalette01 = new Brush[BRUSHES];
            BrushOfPalette01[BRUSH0] = blackBrush;
            BrushOfPalette01[BRUSH1] = maroonBrush;
            BrushOfPalette01[BRUSH2] = darkRedBrush;
            BrushOfPalette01[BRUSH3] = brownBrush;
            BrushOfPalette01[BRUSH4] = firebrickBrush;
            BrushOfPalette01[BRUSH5] = redBrush;
            BrushOfPalette01[BRUSH6] = blackBrush;
            BrushOfPalette01[BRUSH7] = blackBrush;

            BrushOfPalette02 = new Brush[BRUSHES];
            BrushOfPalette02[BRUSH0] = blueBrush;
            BrushOfPalette02[BRUSH1] = skyBlueBrush;
            BrushOfPalette02[BRUSH2] = pinkBrush;
            BrushOfPalette02[BRUSH3] = plumBrush;
            BrushOfPalette02[BRUSH4] = chartreuseBrush;
            BrushOfPalette02[BRUSH5] = greenBrush;
            BrushOfPalette02[BRUSH6] = yellowBrush;
            BrushOfPalette02[BRUSH7] = peachPuffBrush;


            generateSquares();

            //paint default gen using default seed and calculate hash
            PaintFirstGens();

            iHash = myCellArray.CalHash();
            labelHash.Text = string.Format("{0}", iHash);
            labelGens.Text = string.Format("{0}", iGenNb);

        }


        private void createGraphicResourses()
        {

            if (panelGraphics != null) panelGraphics.Dispose();
            if (bufferGraphics != null) bufferGraphics.Dispose();
            if (buffer != null) buffer.Dispose();

            panelGraphics = panelPaint.CreateGraphics();

            buffer = new Bitmap(panelPaint.Width, panelPaint.Height);
            bufferGraphics = Graphics.FromImage(buffer);
        }

        //create array of squares
        private void generateSquares()
        {
            for (int i = 0; i <= (CELL_ROW - 1); i++)
            {
                for (int j = 0; j <= (CELL_COLUMN - 1); j++)
                {
                    squares[i, j] =
                        new Rectangle(j * SQUARE_SIDE, i * SQUARE_SIDE, SQUARE_SIDE, SQUARE_SIDE);
                }
            }
        }

        //using the states of cells to paint panel
        private void paintPanel()
        {
            bufferGraphics.Clear(panelPaint.BackColor);
            DrawSquares();
            panelGraphics.DrawImageUnscaled(buffer, 0, 0);
        }


        //draw squares
        private void DrawSquares()
        {
            CellArray myCellArray = CellArray.getMyCellArray();

            for (int i = 0; i <= CELL_ROW - 1; i++)
            {
                for (int j = 0; j <= CELL_COLUMN - 1; j++)
                {

                    int state;

                    if (!myCellArray.GetCellsState(i, j, out state))
                    {
                        return;
                    };

                    Brush squareColorBrush = SetSquareColorBrush(state);
                    bufferGraphics.FillRectangle(squareColorBrush, squares[i, j]);
                }
            }
        }

        //using palette to set color brushes
        private Brush SetSquareColorBrush(int iState)
        {
            Brush squareColorBrush = redBrush;

            if (iPalette == 0) //rainbow
            {
                squareColorBrush = BrushOfPalette00[iState];
            }
            else if (iPalette == 1) //vampire
            {
                squareColorBrush = BrushOfPalette01[iState];
            }
            else //spring
            {
                squareColorBrush = BrushOfPalette02[iState];
            }

            return squareColorBrush;
        }


        //combo box of rules
        private void comboBoxRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRules.SelectedIndex == INDEX0)
            {
                iRule = INDEX0; //orthogonal
            }
            else if (comboBoxRules.SelectedIndex == INDEX1)
            {
                iRule = INDEX1; //diaogonal
            }
            else
            {
                iRule = INDEX2; //alternating
            }
        }


        //combo box of palettes
        private void comboBoxColors_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxColors.SelectedIndex == INDEX0)
            {
                iPalette = INDEX0;  //rainbow
            }
            else if (comboBoxColors.SelectedIndex == INDEX1)
            {
                iPalette = INDEX1;  //vampire
            }
            else
            {
                iPalette = INDEX2;  //spring
            }

            if (bReady == true)
            {    
                paintPanel();
            }
        }


        //reset button
        private void btnReset_Click(object sender, EventArgs e)
        {
            CellArray myCellArray = CellArray.getMyCellArray();

            if (!CheckSeed(out iSeed))
            {
                return;
            }

            iGenNb = 0;
            PaintFirstGens();

            iHash = myCellArray.CalHash();
            labelHash.Text = string.Format("{0}", iHash);
            labelGens.Text = string.Format("{0}", iGenNb);
        }


        //start button
        private void btnStart_Click(object sender, EventArgs e)
        {
            CellArray myCellArray = CellArray.getMyCellArray();

            if (!CheckSeed(out iSeed))
            {
                return;
            }

            if (!CheckGens(out iGens))
            {
                return;
            }

            panelControl.Enabled = false;
            PaintFollowingGens();

            iHash = myCellArray.CalHash();
            labelHash.Text = string.Format("{0}", iHash);
            panelControl.Enabled = true;
        }


        //paint first gen using seed
        //which is not counted into gen number
        private void PaintFirstGens()
        {
            CellArray myCellArray = CellArray.getMyCellArray();
            myCellArray.GenerateFirstGen(iSeed);
            paintPanel();
        }


        //paint following gens using the state of first gen
        //applying rules
        //iGenNb count the total number of gens before reset
        private void PaintFollowingGens()
        {
            CellArray myCellArray = CellArray.getMyCellArray();
            int i;
            
            if (iRule == INDEX0) //orthogonal rule
            {
                for (i = iGenNb + 1; i <= (iGens + iGenNb); i++)
                {
                    myCellArray.GenerateNextGenOrthogonal();
                    paintPanel();
                    labelGens.Refresh();
                    labelGens.Text = string.Format("{0}", i);
                }                
            }

            else if (iRule == INDEX1) //diagonal rule
            {
                for (i = iGenNb + 1; i <= (iGens + iGenNb); i++)
                {
                    myCellArray.GenerateNextGenDiagonal();
                    paintPanel();
                    labelGens.Refresh();
                    labelGens.Text = string.Format("{0}", i);
                }               
            }

            else //alternating rule
            {                
                for (i = iGenNb + 1; i <= (iGens + iGenNb); i++)
                {
                    myCellArray.GenerateNextGenOrthogonal();
                    myCellArray.GenerateNextGenDiagonal();
                    paintPanel();
                    labelGens.Refresh();
                    labelGens.Text = string.Format("{0}", i);
                }                
            }
            iGenNb = i - 1;
        }


        //check if the seed is valid
        private bool CheckSeed(out int iSeed)
        {
            string strSeed = textBoxSeed.Text;

            if (strSeed.Length == 0)
            {
                MessageBox.Show("Error: Seed value cannot be empty.");
                iSeed = 0;
                return false;
            }

            bool result = int.TryParse(strSeed, out iSeed);

            if (!result)
            {
                MessageBox.Show("Error: Invalid seed value. Seed should be an integer.");
                return false;
            }

            else
            {
                return true;
            }
        }


        //check if the gen number is valid
        private bool CheckGens(out int iGens)
        {
            string strGens = textBoxGens.Text;

            if (strGens.Length == 0)
            {
                MessageBox.Show("Error: Gens value cannot be empty.");
                iGens = 0;
                return false;
            }

            bool result = int.TryParse(strGens, out iGens);

            if (!result)
            {
                MessageBox.Show("Error: Invalid gens value. Gens should be an positive integer.");
                return false;
            }

            else
            {
                if (iGens < 1)
                {
                    MessageBox.Show(
                        "Error: Invalid gens value. Generations to run must be greater than 0.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //paint event handler
        private void panelPaint_Paint(object sender, PaintEventArgs e)
        {
            panelGraphics.DrawImageUnscaled(buffer, 0, 0);
        }

    }
}
