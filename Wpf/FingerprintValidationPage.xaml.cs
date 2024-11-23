using System.Diagnostics;
using System.Windows;

namespace WPFdeneme18kasım
{
	public partial class FingerprintValidationPage : Window
	{
		public FingerprintValidationPage()
		{
			InitializeComponent();
		}

		// Yardım butonuna tıklama işlemi
		private void HelpButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Parmak izi doğrulaması için parmağınızı sensöre yerleştirin ve bekleyin.", "Yardım", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		// Parmak izi okuma işlemini simüle etme
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// Parmak izi okuma simülasyonu (gerçek doğrulama burada yapılabilir)
			// Şu an, okuma tamamlandığında başlık ve buton güncellenecek.
			SimulateFingerprintScan();
		}
		private void btnSimulate_Click(object sender, RoutedEventArgs e)
		{
			txtReadingStatus.Text = "Parmak izi başarıyla okundu!";
			btnSuccess.Visibility = Visibility.Visible; // Başarılı doğrulama butonunu göster
		}


		// Parmak izi okuma simülasyonu
		private async void SimulateFingerprintScan()
		{
			Debug.WriteLine("Parmak izi okuma başlatıldı.");
			await Task.Delay(3000); // 3 saniye bekleyin (simülasyon)
			Debug.WriteLine("Parmak izi okuma tamamlandı.");
			txtReadingStatus.Text = "Parmak izi başarıyla okundu!";
			btnSuccess.Visibility = Visibility.Visible;

		}


		// Doğrulama başarıyla tamamlandığında
		private void btnSuccess_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Parmak izi doğrulandı! Şimdi başka bir sayfaya yönlendiriliyorsunuz.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
			// Parmak izi doğrulaması başarılı olduğunda başka bir sayfaya geçiş yapılabilir
			// Örneğin:
			// SuccessPage successPage = new SuccessPage();
			// successPage.Show();
			// this.Close();
		}
	}
}
