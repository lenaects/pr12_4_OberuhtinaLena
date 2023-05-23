using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	internal class Car
	{
		private double tankCapacity = 0.0; 
		private double amountCapacity = 0.0; 
		private double gasolineConsumption = 0.0; 
		private double mileage = 0.0; 

		public double TankCapacity
		{
			get { return tankCapacity; }
			set { tankCapacity = value; }
		}
		public double AmountCapacity
		{
			get { return amountCapacity; }
			set { amountCapacity = value; }
		}
		public double GasolineConsumption
		{
			get { return gasolineConsumption; }
			set { gasolineConsumption = value; }
		}
		public double Mileage
		{
			get { return mileage; }
			set { mileage = value; }
		}

		public string GetInfo()
		{
			return $"Объем бака: {tankCapacity}\nКоличество бензина: {amountCapacity}" +
				$"\nРасход бензина на 100 км: {gasolineConsumption}\nПробег: {mileage}";
		}

		public double Refuel(double amount)
		{
			double freeSpace = tankCapacity - amountCapacity;
			if (amount <= freeSpace)
			{
				amountCapacity += amount;
				return 0.0;
			}
			else
			{
				amountCapacity += freeSpace;
				return amount - freeSpace;
			}
		}

		public void Drive(double distance)
		{
			double fuelNeeded = distance * gasolineConsumption / 100.0;
			if (fuelNeeded <= amountCapacity)
			{
				amountCapacity -= fuelNeeded;
				mileage += distance;
				CheckMileage();
			}
			else
			{
				double distancePossible = amountCapacity / gasolineConsumption * 100.0;
				amountCapacity = 0.0;
				mileage += Math.Round(distancePossible, 2);
				MessageBox.Show($"Машина проехала {Math.Round(distancePossible, 2)} км, но не доехала {Math.Round(distance - distancePossible, 2)} км из-за нехватки бензина.", "Результат езды.");
			}
		}
		private void CheckMileage()
		{
			int threshold = (int)(mileage / 1000.0);
			if (threshold > 0 && threshold * 1000.0 == mileage)
			{
				gasolineConsumption += 0.1;
				MessageBox.Show($"Расход бензина увеличен до {gasolineConsumption} л/100км.", "Результат езды.");
			}
		}
		public bool NeedRefuel()
		{
			double tankCapacity10Percent = tankCapacity * 0.1;
			return amountCapacity < tankCapacity10Percent;
		}
	}
}
