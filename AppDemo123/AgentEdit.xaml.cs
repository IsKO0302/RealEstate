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

    //Структура аналогична окну редактирования клиента, с дополнительным полем для доли агента.


    /// <summary>
    /// Interaction logic for AgentEdit.xaml
    /// </summary>
    public partial class AgentEdit : Window
        {

            private agents _currentAgent = new agents();

        
            public AgentEdit(agents celectedagents)
            {

                InitializeComponent();

                if (celectedagents != null ) 
                    _currentAgent = celectedagents;

                DataContext = _currentAgent;    
            }

            private void Button_Main_Click(object sender, RoutedEventArgs e)
            {
                ManageAgents manageAgents = new ManageAgents();
                manageAgents.Show();
                Hide();
            }

            private void button_Reg_Click(object sender, RoutedEventArgs e)
            {           
                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrWhiteSpace(_currentAgent.FirstName))
                    errors.AppendLine("Укажите Имя");
                if (string.IsNullOrWhiteSpace(_currentAgent.MiddleName))
                    errors.AppendLine("Укажите Фамилию");        
                if (_currentAgent.DealShare == null)
                    errors.AppendLine("Укажите Сумму");


                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                if (_currentAgent.Id == 0)
                    Entities1.GetContext().agents.Add(_currentAgent);

                try
                {
                    Entities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация успешно сохранена!");                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                ManageAgents manageAgents = new ManageAgents();
                manageAgents.Show();
                Hide();
            }
        }
    }

// AgentEdit: Класс окна редактирования агента.
// _currentAgent: Текущий агент для редактирования.
// AgentEdit: Конструктор, принимающий выбранного агента и устанавливающий контекст данных.
// Button_Main_Click: Метод для перехода к окну управления агентами.
// button_Reg_Click: Метод для сохранения изменений агента с проверкой на ошибки ввода.