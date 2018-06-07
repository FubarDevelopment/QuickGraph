using System;

namespace QuickGraph.Petri
{
#if !NETSTANDARD_PRE_2_0
    [Serializable]
#endif
    internal sealed class Transition<Token> : ITransition<Token>
    {
		private string name;
		private IConditionExpression<Token> condition = new AllwaysTrueConditionExpression<Token>();

		public Transition(string name)
		{this.name=name;}

		public IConditionExpression<Token> Condition
		{
			get
			{
				return this.condition;
			}
			set
			{
				this.condition=value;
			}
		}

		public string Name
		{
            get{return name;}
        }

		public override string ToString()
		{
			return String.Format("T({0})",this.name);
		}
	}
}
