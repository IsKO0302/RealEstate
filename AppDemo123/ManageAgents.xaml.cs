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
using System.Collections.ObjectModel;

namespace AppDemo123
{
    public partial class ManageAgents : Window
    {
        // Коллекции для хранения отфильтрованных данных
        public ObservableCollection<agents> FilteredAgents { get; set; }
        public ObservableCollection<lands> FilteredDemands { get; set; }
        public ObservableCollection<supplies> FilteredSupplies { get; set; }

        public ManageAgents()
        {
            InitializeComponent();

            // Загрузка данных из контекста
            var agentsList = Entities1.GetContext().agents.ToList();
            var landsList = Entities1.GetContext().lands.ToList();
            var suppliesList = Entities1.GetContext().supplies.ToList();

            // Инициализация ObservableCollection для использования в DataGrid
            FilteredAgents = new ObservableCollection<agents>(agentsList);
            FilteredDemands = new ObservableCollection<lands>(landsList);
            FilteredSupplies = new ObservableCollection<supplies>(suppliesList);

            // Установка ItemsSource для DataGrid
            DGridAgents.ItemsSource = FilteredAgents;
            DGridDemands.ItemsSource = FilteredDemands;
            DGridSupplies.ItemsSource = FilteredSupplies;
        }

        // Обработчик изменения видимости окна
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                // Обновление данных при отображении окна
                Entities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

                var agentsList = Entities1.GetContext().agents.ToList();
                var landsList = Entities1.GetContext().lands.ToList();
                var suppliesList = Entities1.GetContext().supplies.ToList();

                // Обновление ObservableCollections
                UpdateCollection(FilteredAgents, agentsList);
                UpdateCollection(FilteredDemands, landsList);
                UpdateCollection(FilteredSupplies, suppliesList);
            }
        }

        // Метод для обновления коллекций
        private void UpdateCollection<T>(ObservableCollection<T> collection, List<T> list)
        {
            collection.Clear();
            foreach (var item in list)
            {
                collection.Add(item);
            }
        }

        // Обработчик нажатия на кнопку для создания нового агента
        private void Button_New_Click(object sender, RoutedEventArgs e)
        {
            AgentEdit agentEdit = new AgentEdit(null);
            agentEdit.Show();
            Hide();
        }

        // Обработчик нажатия на кнопку для удаления агента
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var agentsForRemoving = DGridAgents.SelectedItems.Cast<agents>().ToList();

            if (MessageBox.Show($"Вы уверены что хотите удалить следующие {agentsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    // Удаление агентов из контекста
                    Entities1.GetContext().agents.RemoveRange(agentsForRemoving);
                    Entities1.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалены!");

                    // Обновление коллекции после удаления
                    var agentsList = Entities1.GetContext().agents.ToList();
                    UpdateCollection(FilteredAgents, agentsList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        // Обработчик изменения текста в поле поиска
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            var agentsList = Entities1.GetContext().agents.ToList();
            var filteredList = agentsList.Where(a =>
                a.FirstName.ToLower().Contains(searchText) ||
                a.MiddleName.ToLower().Contains(searchText) ||
                a.LastName.ToLower().Contains(searchText)).ToList();

            // Обновление коллекции в соответствии с результатами поиска
            UpdateCollection(FilteredAgents, filteredList);
        }

        // Обработчик нажатия на кнопку для перехода на главное окно
        private void Button_MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        // Обработчик нажатия на кнопку для редактирования выбранного агента
        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            AgentEdit agentEdit = new AgentEdit((sender as Button).DataContext as agents);
            agentEdit.Show();
            Hide();
        }
    }
}

//  using: Импорт необходимых пространств имен.
//  ManageAgents: Класс окна управления агентами, наследует класс Window.
//  FilteredAgents, FilteredDemands, FilteredSupplies: Коллекции, используемые для отображения данных в DataGrid.
//  /ManageAgents(): Конструктор, инициализирующий компоненты окна и загружающий данные.
//  Window_IsVisibleChanged: Метод, обновляющий данные при изменении видимости окна.
//  UpdateCollection: Универсальный метод для обновления ObservableCollection.
//  Button_New_Click: Обработчик для создания нового агента.
//  Button_Delete_Click: Обработчик для удаления выбранных агентов.
//  SearchBox_TextChanged: Обработчик для фильтрации агентов по введенному тексту в поле поиска.
//  Button_MainWindow_Click: Обработчик для перехода на главное окно.
//  Button_Edit_Click: Обработчик для редактирования выбранного агента.