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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDemo123
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Этот код описывает обработчик событий для нажатия на кнопку buttonAgentEdit.
        // Метод button_Agent_Edit_Click является приватным и предназначен для обработки событий нажатия на кнопку.
        // Он принимает два параметра: объект sender (тот, кто вызвал событие) и объект RoutedEventArgs (аргументы события).
        // Создается новый экземпляр класса ManageClients
        // Метод Show отображает это окно.
        // Метод Hide скрывает текущее окно.

        private void button_Agent_Edit_Click(object sender, RoutedEventArgs e)
        {
            ManageAgents manageAgents = new ManageAgents();
            manageAgents.Show();
            Hide();

        }

        // Этот код описывает обработчик событий для нажатия на кнопку buttonManageClient.
        // Метод buttonManageClient_Click является приватным и предназначен для обработки событий нажатия на кнопку.
        // Он принимает два параметра: объект sender (тот, кто вызвал событие) и объект RoutedEventArgs (аргументы события).
        // Создается новый экземпляр класса ManageClients
        // Метод Show отображает это окно.
        // Метод Hide скрывает текущее окно.


        private void buttonManageClient_Click(object sender, RoutedEventArgs e)
        {
            ManageClients manageClients = new ManageClients();
            manageClients.Show();
            Hide();
        }
    }
}
