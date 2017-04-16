using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class CellArray
    {

        public const int CELL_ROW = 240;
        public const int CELL_COLUMN = 320;
        public const int NBROFSTATES = 8;
        public const int NEIGHBRNUMB = 8;
        public const int NEIGHBIJ=2;
        public const int NEIGHBI = 0;
        public const int NEIGHBJ = 1;
        public const int NEIGHBR0 = 0;
        public const int NEIGHBR1 = 1;
        public const int NEIGHBR2 = 2;
        public const int NEIGHBR3 = 3;
        public const int NEIGHBR4 = 4;
        public const int NEIGHBR5 = 5;
        public const int NEIGHBR6 = 6;
        public const int NEIGHBR7 = 7;

        private Cell[,] Cells, CellsNextGen;
       
        private int[, , ,] NghbCoordinate;

        private static CellArray myCellArray;

        public CellArray()
        {
            //create the array of cells
            Cells = new Cell[CELL_ROW, CELL_COLUMN];

            //create the cells
            for (int i = 0; i <= (CELL_ROW - 1); i++)
            {
                for (int j = 0; j <= (CELL_COLUMN - 1); j++)
                {
                    Cells[i, j] = new Cell();
                }

            }


            //create an array of cells to store the values of states of the next generation
            CellsNextGen = new Cell[CELL_ROW, CELL_COLUMN];

            for (int i = 0; i <= (CELL_ROW - 1); i++)
            {
                for (int j = 0; j <= (CELL_COLUMN - 1); j++)
                {
                    CellsNextGen[i, j] = new Cell();
                }

            }


            //create an array to store the coordinates of the neighbours of every cell
            //So the caculations of neighbours is done one time when the form is initialized 
            //and saved for future used

            NghbCoordinate = new int[CELL_ROW, CELL_COLUMN, NEIGHBRNUMB, NEIGHBIJ];

            for (int i = 0; i <= (CELL_ROW - 1); i++)
            {
                for (int j = 0; j <= (CELL_COLUMN - 1); j++)
                {
                    int jLeft;
                    int jRight;
                    int iUp;
                    int iDown;
                    SetWrapRule(i, j, out jLeft, out jRight, out iUp, out iDown);

                    //four neighbours using orthogonal rule
                    NghbCoordinate[i, j, NEIGHBR0, NEIGHBI] = i;
                    NghbCoordinate[i, j, NEIGHBR0, NEIGHBJ] = jLeft;

                    NghbCoordinate[i, j, NEIGHBR1, NEIGHBI] = i;
                    NghbCoordinate[i, j, NEIGHBR1, NEIGHBJ] = jRight;

                    NghbCoordinate[i, j, NEIGHBR2, NEIGHBI] = iUp;
                    NghbCoordinate[i, j, NEIGHBR2, NEIGHBJ] = j;

                    NghbCoordinate[i, j, NEIGHBR3, NEIGHBI] = iDown;
                    NghbCoordinate[i, j, NEIGHBR3, NEIGHBJ] = j;
                    
                    //four neighbours using diagonal rule
                    NghbCoordinate[i, j, NEIGHBR4, NEIGHBI] = iUp;
                    NghbCoordinate[i, j, NEIGHBR4, NEIGHBJ] = jLeft;

                    NghbCoordinate[i, j, NEIGHBR5, NEIGHBI] = iDown;
                    NghbCoordinate[i, j, NEIGHBR5, NEIGHBJ] = jRight;

                    NghbCoordinate[i, j, NEIGHBR6, NEIGHBI] = iUp;
                    NghbCoordinate[i, j, NEIGHBR6, NEIGHBJ] = jRight;

                    NghbCoordinate[i, j, NEIGHBR7, NEIGHBI] = iDown;
                    NghbCoordinate[i, j, NEIGHBR7, NEIGHBJ] = jLeft;

                }
            }

            myCellArray = this;

        }


        //set wrapping around rule for calculating neighbours
        private void SetWrapRule(
                                  int iCur, int jCur,
                                  out int jLeft, out int jRight, out int iUp, out int iDown)
        {
            
            if (jCur == 0)
            {
                jLeft = CELL_COLUMN - 1;
                jRight = 1;
            }
            else if (jCur == CELL_COLUMN - 1)
            {
                jRight = 0;
                jLeft = (CELL_COLUMN - 1) - 1;
            }
            else
            {
                jLeft = jCur - 1;
                jRight = jCur + 1;
            }

            if (iCur == 0)
            {
                iUp = CELL_ROW - 1;
                iDown = 1;
            }
            else if (iCur == CELL_ROW - 1)
            {
                iDown = 0;
                iUp = (CELL_ROW - 1) - 1;
            }
            else
            {
                iUp = iCur - 1;
                iDown = iCur + 1;
            }

        }

        public static CellArray getMyCellArray()
        {
            return myCellArray;
        }


        //get the current state of a cell
        public bool GetCellsState(int i, int j, out int state)
        {
            try
            {
                state = Cells[i, j].State;
                return true;
            }
            catch (IndexOutOfRangeException e)
            {
                System.Console.WriteLine(
                    "CellArray::GetCellsState:Exception: " + e.ToString());
                System.Console.WriteLine(
                    "CellArray::GetCellsState:Exception: i="
                     + i.ToString() + " , j=" + j.ToString());
                state = 0;
                return false;
            }
        }

        //generate the first generation with the input seed
        public void GenerateFirstGen(int iSeed)
        {

            Random rdm = new Random(iSeed);

            for (int i = 0; i <= (CELL_ROW - 1); i++)
            {
                for (int j = 0; j <= (CELL_COLUMN - 1); j++)
                {
                    int rdmN = NBROFSTATES;
                    Cells[i, j].State = rdm.Next(rdmN);
                }
            }
        }


        //generate next generation using the state of current generation using rules

        //orthogonal rule
        public void GenerateNextGenOrthogonal()
        {
            CalNextGenOrthogonal();
            CopyNextGenToCurGen();
        }

        //diagonal rule
        public void GenerateNextGenDiagonal()
        {
            CalNextGenDiagonal();
            CopyNextGenToCurGen();
        }


        //Using states of neighbours to calculate the states of next generation.
        private void CalNextGenOrthogonal()
        {
            for (int i = 0; i < CELL_ROW; i++)
            {
                for (int j = 0; j < CELL_COLUMN; j++)
                {
 
                   Cell Cellnghb1 =
                        Cells[NghbCoordinate[i, j, NEIGHBR0, NEIGHBI],
                            NghbCoordinate[i, j, NEIGHBR0, NEIGHBJ]];

                   Cell Cellnghb2 =
                        Cells[NghbCoordinate[i, j, NEIGHBR1, NEIGHBI],
                            NghbCoordinate[i, j, NEIGHBR1, NEIGHBJ]];

                   Cell Cellnghb3 =
                        Cells[NghbCoordinate[i, j, NEIGHBR2, NEIGHBI],
                            NghbCoordinate[i, j, NEIGHBR2, NEIGHBJ]];

                   Cell Cellnghb4 =
                        Cells[NghbCoordinate[i, j, NEIGHBR3, NEIGHBI],
                            NghbCoordinate[i, j, NEIGHBR3, NEIGHBJ]];

                    CellsNextGen[i, j].SetState(Cellnghb1, Cellnghb2, 
                                                Cellnghb3, Cellnghb4, Cells[i, j]);
    
                }
            }
        }


        private void CalNextGenDiagonal()
        {
            for (int i = 0; i < CELL_ROW; i++)
            {
                for (int j = 0; j < CELL_COLUMN; j++)
                {
                    
                    Cell Cellnghb1 =
                        Cells[NghbCoordinate[i, j, NEIGHBR4, NEIGHBI], 
                             NghbCoordinate[i, j, NEIGHBR4, NEIGHBJ]];

                    Cell Cellnghb2 =
                         Cells[NghbCoordinate[i, j, NEIGHBR5, NEIGHBI],
                             NghbCoordinate[i, j, NEIGHBR5, NEIGHBJ]];

                    Cell Cellnghb3 =
                         Cells[NghbCoordinate[i, j, NEIGHBR6, NEIGHBI],
                             NghbCoordinate[i, j, NEIGHBR6, NEIGHBJ]];

                    Cell Cellnghb4 =
                         Cells[NghbCoordinate[i, j, NEIGHBR7, NEIGHBI],
                             NghbCoordinate[i, j, NEIGHBR7, NEIGHBJ]];

                    CellsNextGen[i, j].SetState(Cellnghb1, Cellnghb2, 
                                                Cellnghb3, Cellnghb4, Cells[i, j]);
         
                }
            }
        }
       


        //copy back the stored states to cells
        private void CopyNextGenToCurGen()
        {
            for (int i = 0; i <= (CELL_ROW - 1); i++)
            {
                for (int j = 0; j <= (CELL_COLUMN - 1); j++)
                {
                    Cells[i, j].State = CellsNextGen[i, j].State;
                }
            }

        }


        //calculate hash value
        public uint CalHash()
        {
            int state, hash = 0;
            for (int j = 0; j < CELL_COLUMN; j++)
            {
                for (int i = 0; i < CELL_ROW; i++)
                {
                    state = Cells[i, j].State;
                    hash ^= ((i * j + 1) * (state + 1));
                }
            }

            return (uint)hash;
        }


    }
}
