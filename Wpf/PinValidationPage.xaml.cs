using System.Windows;

namespace WPFdeneme18kasım
{
	public partial class PinValidationPage : Window
	{
		public PinValidationPage()
		{
			InitializeComponent();
		}

		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtPin.Password) || string.IsNullOrWhiteSpace(txtUsername.Text))
			{
				MessageBox.Show("Lütfen kullanıcı adı ve PIN'i giriniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (txtPin.Password == "1234" && txtUsername.Text == "user")
			{
				UpdateProgress(66);
				MessageBox.Show("PIN doğrulandı! Şimdi yüz tanıma ekranına geçilecek.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
				NavigateToFaceValidationPage();
			}
			else
			{
				MessageBox.Show("Geçersiz PIN veya kullanıcı adı.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnHelp_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Yardım: PIN doğrulamak için geçerli kullanıcı adı ve PIN girin.", "Yardım", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void UpdateProgress(double progress)
		{
			progressBar.Value = progress;
		}

		private void NavigateToFaceValidationPage()
		{
			FaceValidationPage facePage = new FaceValidationPage();
			facePage.Show();
			this.Close();
		}

		private void SignUpRedirect_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			SignUpPage signUpPage = new SignUpPage();
			signUpPage.Show();
			this.Close();
		}
	}
}
