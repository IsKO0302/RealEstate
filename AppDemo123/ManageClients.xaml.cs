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
    /// Interaction logic for ManageClients.xaml
    /// </summary>
    public partial class ManageClients : Window
    {

        //  Вызов InitializeComponent: Метод InitializeComponent инициализирует компоненты интерфейса.
        //  Обычно он вызывается один раз при создании окна или страницы.
        // DGridClients.ItemsSource устанавливает источник данных для таблицы клиентов, получая их из контекста данных Entities1 и преобразуя в список.
        // DgridSuplies.ItemsSource устанавливает источник данных для таблицы поставок аналогичным образом.
        public ManageClients()
        {
            InitializeComponent();
            DGridClients.ItemsSource = Entities1.GetContext().clients.ToList();
            DgridSuplies.ItemsSource = Entities1.GetContext().supplies.ToList();
        }

        // Метод Window_IsVisibleChanged обрабатывает событие изменения видимости окна.
        // Он принимает два параметра: объект sender и объект DependencyPropertyChangedEventArgs.
        // Если окно становится видимым (Visibility == Visibility.Visible), выполняется следующий код.  
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridClients.ItemsSource = Entities1.GetContext().clients.ToList();
                // ChangeTracker.Entries().ToList().ForEach(p => p.Reload()) обновляет все отслеживаемые записи в контексте данных, вызывая метод Reload для каждой записи.
                // DGridClients.ItemsSource снова устанавливает источник данных для таблицы клиентов.
            }
        }
        // Этот код описывает обработчик событий для нажатия на кнопку ButtonNewClick.

        private void Button_New_Click(object sender, RoutedEventArgs e)
        { 
            ClientEdit clientEdit = new ClientEdit(null);
            clientEdit.Show();
            Hide();
        }

        // Этот код представляет собой обработчик событий для кнопки удаления клиентов.

        // Метод Button_Delete_Click обрабатывает событие нажатия на кнопку удаления.
        // Он принимает два параметра: объект sender и объект RoutedEventArgs.
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var clientsForRemoving = DGridClients.SelectedItems.Cast<clients>().ToList();

            if (MessageBox.Show($"Вы уверены что хотите удалить следующие {clientsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    // RemoveRange удаляет выбранных клиентов из контекста данных.
                    Entities1.GetContext().clients.RemoveRange((IEnumerable<clients>)clientsForRemoving);
                    // SaveChanges сохраняет изменения в базе данных.
                    Entities1.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалены!");

                    DGridClients.ItemsSource = Entities1.GetContext().clients.ToList();
                    // DGridClients.SelectedItems.Cast<clients>().ToList() преобразует выбранные элементы в таблице клиентов в список объектов clients.

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    // MessageBox.Show отображает диалоговое окно с подтверждением удаления, указывая количество элементов для удаления.
                }
            }
        }


        // Этот код описывает обработчик событий для нажатия на кнопку ButtonMainWindowClick.

        private void Button_MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        // Этот код описывает обработчик событий для нажатия на кнопку ButtonEditClick.

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

            ClientEdit clientEdit = new ClientEdit((sender as Button).DataContext as clients);
            clientEdit.Show();
            Hide();
        }
    }
}
