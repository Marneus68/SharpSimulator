using System;
using System.Reflection;

namespace SharpSimulator
{
	public abstract class Characteristic {
		public static readonly uint MinValue = 0;
		public static readonly uint MaxValue = 100;

		protected uint _value = 0;
		public uint Value {
			get { 
				return _value;
			}
			set { 
				_value = Limit (value);
			}
		}

		public Characteristic() {}

		public Characteristic(System.Object obj = null) {
			_value = Limit(Characteristic.ObjectToUInt (obj));
		}

		// This makes the class behave like an uint when it's implicitely or expliciterly casted
		public static implicit operator uint(Characteristic bc) {
			return bc.Value;
		}

		public static implicit operator int(Characteristic bc) {
			return Convert.ToInt32(bc.Value);
		}

		protected static uint Limit(System.Object obj = null) {
			uint ret = ObjectToUInt (obj);
			if (ret > MaxValue)
				return MaxValue;
			else if (ret < MinValue)
				return MinValue;
			return ret;
		}

		protected static uint ObjectToUInt(System.Object obj) {
			uint val = 0;
			if (obj == null)
				return 0;
			if (obj is Characteristic) {
				val = ((Characteristic)obj).Value;
			} else if (obj is int) {
				if (((int)obj) < 0)
					val = 0;
				else 
					val = Convert.ToUInt32 (obj);
			} else if (obj is uint) {
				val = ((uint)obj);
			} else {
				val = Convert.ToUInt32 (obj);
			}
			return val;
		}

		public override string ToString ()
		{
			return string.Format ("{0}", Value);
		}

		/*
		public uint Value = 0;

		protected static uint ObjectToUInt(System.Object obj) {
			uint val = 0;
			if (obj == null)
				return 0;
			if (obj is BaseCaracteristic) {
				val = ((BaseCaracteristic)obj).Value;
			} else if (obj is int) {
				val = Convert.ToUInt32 (obj);
			} else if (obj is uint) {
				val = ((uint)obj);
			} else {
				val = Convert.ToUInt32 (obj);
			}
			return val;
		}

		public BaseCaracteristic() {
			Value = 0;
		}

		public BaseCaracteristic (System.Object obj = null) {
			Value = ObjectToUInt(obj);
		}

		public bool Equals(BaseCaracteristic bc) {
			if (bc.Value == Value)
				return true;
			else
				return false;
		}

		public bool Equals(int val) {
			if (val == Value)
				return true;
			else
				return false;
		}

		public bool Equals(uint val) {
			if (val == Value)
				return true;
			else
				return false;
		}

		public static bool operator==(BaseCaracteristic bc, System.Object obj) {
			if (bc.Value == ObjectToUInt(obj))
				return true;
			else
				return false;
		}

		public static bool operator!=(BaseCaracteristic bc, System.Object obj) {
			if (bc.Value != ObjectToUInt(obj))
				return true;
			else
				return false;
		}

		public static BaseCaracteristic operator+(BaseCaracteristic bc, System.Object obj) {
			return new BaseCaracteristic(Limit(bc.Value + ObjectToUInt(obj)));
		}

		public static BaseCaracteristic operator*(BaseCaracteristic bc, System.Object obj) {
			return new BaseCaracteristic(Limit(bc.Value * ObjectToUInt (obj)));
		}

		public static BaseCaracteristic operator/(BaseCaracteristic bc, System.Object obj) {
			return new BaseCaracteristic(Limit(bc.Value / ObjectToUInt (obj)));
		}

		public static BaseCaracteristic operator%(BaseCaracteristic bc, System.Object obj) {
			return new BaseCaracteristic(Limit(bc.Value % ObjectToUInt (obj)));
		}

		public static BaseCaracteristic operator++(BaseCaracteristic bc) {
			return new BaseCaracteristic(Limit(bc.Value = bc.Value + 1));
		}

		public static BaseCaracteristic operator--(BaseCaracteristic bc) {
			if (bc.Value == 0)
				return new BaseCaracteristic(0);
			else
				return new BaseCaracteristic(Limit(bc.Value - 1));
		}
			
		public static BaseCaracteristic operator+(BaseCaracteristic bc) {
			return bc;
		}

		public static BaseCaracteristic operator-(BaseCaracteristic bc) {
			return new BaseCaracteristic(0);
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		public override bool Equals(System.Object obj) {
			if (obj == null)
				return false;

			if (ObjectToUInt (obj) == Value)
				return true;
			return false;
		}

		// This makes the class behave like an uint when it's implicitely or expliciterly casted
		public static implicit operator uint(BaseCaracteristic bc)
		{
			return bc.Value;
		}

		public override string ToString ()
		{
			return string.Format ("[Caracteristic: " + Name + " (" + Description + ") = " + Value + "]");
		}
		*/
	}
}

