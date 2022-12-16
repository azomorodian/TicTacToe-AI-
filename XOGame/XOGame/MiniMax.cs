using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGame
{
    class MiniMax
    {
        public int WhomDecision;
        public XOProblem MinmaxDecision(XOProblem StateNode)
        {
            int v = MaxValue(StateNode, -1000, 1000);
            XOProblem Result = null;
            foreach(XOProblem s in StateNode.successors)
                if (s.Value == v) { Result = s; break; } 
            return Result;
        }
        public int MaxValue(XOProblem StateNode,int Alpha,int Beta)
        {         
            if (StateNode.TermianlTest()) 
            {
                return StateNode.Value = StateNode.Utility(WhomDecision);                
            }
            int v = -1000;
            StateNode.CreateSuccessors();
            foreach (XOProblem node in StateNode.successors)
            {
                v= Math.Max(v,MinValue(node, Alpha, Beta));
                StateNode.Value = v;
                if (v >= Beta) return v ;                 
                Alpha = Math.Max(Alpha, v);
            }            
            return v;
        }
        public int MinValue(XOProblem StateNode, int Alpha, int Beta)
        {
            if (StateNode.TermianlTest()) return StateNode.Value = StateNode.Utility(WhomDecision);
                         
            int v = 1000;
            StateNode.CreateSuccessors();            
            foreach (XOProblem node in StateNode.successors)
            {
                v = Math.Min(v , MaxValue(node, Alpha, Beta));
                StateNode.Value = v;
                if (v <= Alpha) return v;
                Beta = Math.Min(Beta, v);
            }
            return v;
        }
    }
}
