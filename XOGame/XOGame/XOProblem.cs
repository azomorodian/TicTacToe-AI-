using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGame
{
    class Action
    {
        public int row;
        public int col;
        public int turn;
    }
    class XOProblem    
    {
        public int[,] State = new int[3, 3];
        public int GoalTest(int whom)
        {

          int [,] OC = new int[8,2];            
          for(int i=0;i<3;i++)
          {
              if (State[i,i] !=0)
                  OC[0,State[i,i]-1] +=1;
              if (State[i,2-i] !=0)
                  OC[1,State[i,2-i]-1] +=1;
              if (State[i,0]!=0)
                  OC[2,State[i,0]-1] +=1;
              if (State[i,1]!=0)
                  OC[3,State[i,1]-1] +=1;
              if (State[i,2]!=0)
                  OC[4,State[i,2]-1] +=1; 
              if (State[0,i]!=0)
                  OC[5,State[0,i]-1] +=1;
              if (State[1,i]!=0)
                  OC[6,State[1,i]-1] +=1;
              if (State[2,i]!=0)
                  OC[7,State[2,i]-1] +=1;
          }
          for (int i = 0; i < 8; i++)
          {
              if (OC[i, 0] == 3) return (whom == 1) ? 1 : -1;
              if (OC[i, 1] == 3) return (whom == 2) ? 1 : -1;
          }
          return 0;  
        }
        public int Value;
        public int PathCost;
        public XOProblem Parent;
        public Action action;
        public int depth;
        public int Turn;
        public int Utility(int whom)
        {
            //Console.WriteLine("----------------------------");
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write((State[i, j] == 1) ? "X" : (State[i, j] == 2) ? "O" : " ");
            //    }
            //    Console.WriteLine();
          // }
            int L = GoalTest(whom);
            //Console.WriteLine("who :" + whom.ToString());
            //Console.WriteLine("Goal :" + L.ToString());
            //Console.WriteLine("depth :" + depth );

            //Console.WriteLine("----------------------------");
            return L;
        }
        public void NewGame()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    State[i, j] = 0;
        }
        public bool TermianlTest()
        {
            if (GoalTest(1) != 0) return true;
            int EmptyCell = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (State[i, j] == 0) EmptyCell++;

            if (EmptyCell == 0) return true; else return false;
        }
        public void CopyState(ref int[,] state)
        {
            for(int i=0;i<3;i++)
                for (int j = 0; j < 3; j++)
                {
                    State[i, j] = state[i, j];
                }
        }
        public List<XOProblem> successors = new List<XOProblem>();
        public void CreateSuccessors()
        {
            successors.Clear();        
            for(int i=0;i<3;i++)
                for (int j = 0; j < 3; j++)
                {
                    if (State[i, j] == 0)
                    {
                        XOProblem n = new XOProblem();
                        n.action = new Action();
                        n.action.col = j;
                        n.action.row = i;
                        n.depth = depth + 1;
                        n.Parent = this;
                        n.PathCost = PathCost + 1;
                        n.CopyState(ref State);
                        n.State[i, j] = Turn;
                        n.Turn = 3 - Turn;
                        successors.Add(n);
                    }
                    
                }            
        }

    }
}
