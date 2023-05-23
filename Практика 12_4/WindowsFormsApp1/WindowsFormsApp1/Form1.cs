using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		// 5 вариант

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Car car = new Car();

			car.TankCapacity = (double)numericUpDown1.Value;
			car.AmountCapacity = (double)numericUpDown2.Value;
			car.GasolineConsumption = (double)numericUpDown3.Value;
			car.Mileage = (double)numericUpDown4.Value;
			if (car.TankCapacity < car.AmountCapacity) return;

			
			MessageBox.Show(car.GetInfo(), "Информация об автомобиле");
			
			double remainingAmount = car.Refuel(20.0);
			if (remainingAmount == 0.0)MessageBox.Show("Машина была успешно заправлена.", "Результат заправки");			
			else MessageBox.Show($"Весь заправочный объем не влез в бак. Оставшийся объем: {remainingAmount} л.", "Результат заправки");
			MessageBox.Show(car.GetInfo(), "Информация об автомобиле");			
			car.Drive(1000.0);
			MessageBox.Show(car.GetInfo(), "Информация об автомобиле");
			if (car.NeedRefuel())
				MessageBox.Show("Нужно заправить машину", "Информация об дозаправке");
			else
				MessageBox.Show("Можно продолжать ехать", "Информация об дозаправке");
		}
	}
}
