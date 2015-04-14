using System;

namespace Adventure
{
	public enum DrugsEffects 
	{
		HIGH,
		BAD,
		PSYCH,
		STONED,
		CONNECTED

	}

	public abstract class Drug
	{
		protected string name;
		protected double value;

		public Drug (string name, double value)
		{
			this.name = name;
			this.value = value;
		}
		public string Name {
			
			get;
			set;
		}
		public double Value {
			get;
			set;
		}
	}
}

