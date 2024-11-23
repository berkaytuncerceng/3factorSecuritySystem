using System.Windows;

namespace WPFdeneme18kasım
{
	public partial class SignUpPage : Window
	{
		public SignUpPage()
		{
			InitializeComponent();
		}

		private void btnSignUp_Click(object sender, RoutedEventArgs e)
		{
			// Şimdilik sadece bilgilendirme mesajı gösteriyoruz.
			MessageBox.Show("Thank you for signing up! Your details will be processed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

			// Sign Up işlemi sonrası Pin Validation sayfasına geri yönlendirme
			PinValidationPage pinPage = new PinValidationPage();
			pinPage.Show();

			// Mevcut sayfayı kapat
			this.Close();
		}
	}
}
