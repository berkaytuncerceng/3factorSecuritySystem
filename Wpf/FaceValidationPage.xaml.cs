using System.Windows;

namespace WPFdeneme18kasım
{
	public partial class FaceValidationPage : Window
	{
		public FaceValidationPage()
		{
			InitializeComponent();
		}

		// Sayfa yüklendiğinde yapılacak işlemler
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// Kamera açma işlemi burada başlatılabilir
		}

		// Kamera açma ve kapama işlemi
		private void btnToggleCamera_Click(object sender, RoutedEventArgs e)
		{
			// Burada kamera açma / kapama simülasyonu yapılabilir
			if (btnToggleCamera.Content.ToString() == "Kamerayı Aç")
			{
				btnToggleCamera.Content = "Kamerayı Kapat";
				// Gerçek kamera açma kodu burada eklenebilir
			}
			else
			{
				btnToggleCamera.Content = "Kamerayı Aç";
				// Gerçek kamera kapama kodu burada eklenebilir
			}
		}

		// Yüz tanıma işlemini başlat
		private void btnStartFaceRecognition_Click(object sender, RoutedEventArgs e)
		{
			// Yüz tanıma işlemi başlatılabilir
			MessageBox.Show("Yüz tanıma başlatılıyor...", "Başlat", MessageBoxButton.OK, MessageBoxImage.Information);

			// Yüz tanıma tamamlandıktan sonra parmak izi sayfasına geçiş yapılabilir
			// Parmak izi sayfasına yönlendirme
			FingerprintValidationPage fingerprintPage = new FingerprintValidationPage();
			fingerprintPage.Show();
			this.Close();
		}

		// Yardım butonuna tıklama işlemi
		private void HelpButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Yüz tanıma işlemini başlatmak için 'Yüz Tanıma Başlat' butonuna tıklayın.", "Yardım", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}
