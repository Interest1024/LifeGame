using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    
        class Cell
        {
            public const int STATENUMBER = 8;
            private int state;      
   
            //get current state of a cell
            public int State
            {
                get { return state; }             
                set { state = value; }
            }


            //calculate the next state of a cell
            public int GetNextState()
            {
                int nextState;

                if (state == STATENUMBER - 1)
                {
                    nextState = 0;
                }

                else
                {
                    nextState = state + 1;
                }

                return nextState;
            }

            //apply rule to get next state
            public int SetState(Cell Cellnghb1, Cell Cellnghb2, 
                                Cell Cellnghb3, Cell Cellnghb4, Cell currentCell)
            {
                int nextState = currentCell.GetNextState();

                if (Cellnghb1.State == nextState ||
                    Cellnghb2.State == nextState ||
                    Cellnghb3.State == nextState ||
                    Cellnghb4.State == nextState)                  
                    {
                        state = nextState;
                    }
                    else
                    {
                        state = currentCell.State;
                    }
                return state;
            }

        
        }
    
}
