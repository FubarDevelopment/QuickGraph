using System;

namespace QuickGraph.Petri
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    internal sealed class PetriGraph<Token> :
        BidirectionalGraph<IPetriVertex, IArc<Token>>,
        IPetriGraph<Token>
    {
        public PetriGraph()
            :base(true)
        { }
    }
}
