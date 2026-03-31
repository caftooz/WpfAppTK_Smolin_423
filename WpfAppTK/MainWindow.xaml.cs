using System;
using System.Windows;
using System.Windows.Controls;
using WpfAppTK;

namespace WpfAppTK
{
    public partial class MainWindow : Window
    {
        private readonly OhmCalculator _calculator = new OhmCalculator();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (LabelParam1 == null) return;
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            if (RadioCurrent.IsChecked == true)
            {
                LabelParam1.Content = "Напряжение (Вольт):";
                LabelParam2.Content = "Сопротивление (Ом):";
                LabelResult.Content = "Сила тока =";
            }
            else if (RadioVoltage.IsChecked == true)
            {
                LabelParam1.Content = "Сила тока (Ампер):";
                LabelParam2.Content = "Сопротивление (Ом):";
                LabelResult.Content = "Напряжение =";
            }
            else if (RadioResistance.IsChecked == true)
            {
                LabelParam1.Content = "Напряжение (Вольт):";
                LabelParam2.Content = "Сила тока (Ампер):";
                LabelResult.Content = "Сопротивление =";
            }

            LabelResultValue.Content = "";
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TextParam1.Text, out double p1))
            {
                MessageBox.Show("Введите корректное числовое значение в первое поле.", "Ошибка ввода",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(TextParam2.Text, out double p2))
            {
                MessageBox.Show("Введите корректное числовое значение во второе поле.", "Ошибка ввода",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                CalculationType type;
                if (RadioCurrent.IsChecked == true)
                    type = CalculationType.Current;
                else if (RadioVoltage.IsChecked == true)
                    type = CalculationType.Voltage;
                else
                    type = CalculationType.Resistance;

                double result = _calculator.Calculate(type, p1, p2);
                LabelResultValue.Content = result.ToString("G6");
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка вычисления",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}