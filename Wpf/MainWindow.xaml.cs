using System.Windows;

namespace WPFdeneme18kasım
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Dashboard_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Dashboard ekranı açılacak.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void Data_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Veri ekranı açılacak.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void Reports_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Rapor ekranı açılacak.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void Settings_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Ayarlar ekranı açılacak.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}
