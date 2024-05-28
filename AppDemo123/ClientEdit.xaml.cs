using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppDemo123
{
    /// <summary>
    /// Логика взаимодействия для ClientEdit.xaml
    /// </summary>
    public partial class ClientEdit : Window
    {
        private clients _currentClient = new clients(); // Текущий клиент

        public ClientEdit(clients selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
                _currentClient = selectedClient; // Инициализация клиента

            DataContext = _currentClient; // Установка контекста данных
        }

        private void Button_Main_Click(object sender, RoutedEventArgs e)
        {
            // Переход к окну управления клиентами
            ManageClients manageClients = new ManageClients();
            manageClients.Show();
            Hide();
        }

        private void button_Reg_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на ошибки ввода
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClient.FirstName))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_currentClient.MiddleName))
                errors.AppendLine("Укажите Фамилию");
            if (_currentClient.Phone == null)
                errors.AppendLine("Укажите Телефон");
            if (_currentClient.Email == null)
                errors.AppendLine("Укажите Почту");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            // Если клиент новый, добавляем его в контекст
            if (_currentClient.Id == 0)
                Entities1.GetContext().clients.Add(_currentClient);

            try
            {
                // Сохранение изменений
                Entities1.GetContext().SaveChanges();
                MessageBox.Show("Информация успешно сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            // Переход к окну управления клиентами
            ManageClients manageClients = new ManageClients();
            manageClients.Show();
            Hide();
        }
    }
}

// ClientEdit: Класс окна редактирования клиента.
// _currentClient: Текущий клиент для редактирования.
// ClientEdit: Конструктор, принимающий выбранного клиента и устанавливающий контекст данных.
// Button_Main_Click: Метод для перехода к окну управления клиентами.
// button_Reg_Click: Метод для сохранения изменений клиента с проверкой на ошибки ввода.