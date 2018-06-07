using System;
using System.Collections.Generic;

namespace QuickGraph.Petri
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    public sealed class AllwaysTrueConditionExpression<Token> : IConditionExpression<Token>
    {
		public bool IsEnabled(IList<Token> tokens)
		{
			return true;
		}
	}
}
