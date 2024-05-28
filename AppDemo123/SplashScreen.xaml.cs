using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class SplashScreen : Window
    {
        // Конструктор SplashScreen() вызывает метод InitializeComponent(), который инициализирует компоненты окна (создает элементы интерфейса, описанные в XAML).
        public SplashScreen()
        {
            InitializeComponent();
        }

        // Сначала мы создали экземпляр фонового рабочего процесса для индикатора выполнения для оброботки фоновой работы <summary>
        // WorkerReportsProgress = true — позволяет BackgroundWorker сообщать о прогрессе.
        // DoWork привязывается к методу worker_DoWork, который выполняет основную работу.
        // ProgressChanged привязывается к методу worker_ProgressChanged, который обновляет индикатор выполнения.
        // Метод RunWorkerAsync() запускает фоновую работу.

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DeWorks;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        // Затем мы назначили метод work для увеличения значения прогресса индикатора выполнения с помощью цикла for
        // Чтобы симулировать работу, которая постепенно продвигается от 0 до 100%.
        // В каждом цикле вызывает ReportProgress(i), чтобы сообщить текущий прогресс.
        // Thread.Sleep(80) замедляет цикл, чтобы прогресс был видимым и обновлялся каждые 80 миллисекунд.
        void worker_DeWorks(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(80);
            }
        }

        // Наконец, мы создали и назначили метод для отслеживания значения индикатора выполнения, и если значение равно 99 то будет отображено следующие окно
        // Устанавливает значение progressBar.Value в соответствии с текущим процентом прогресса e.ProgressPercentage.

        // Когда значение прогресса превышает 99, создается экземпляр основного окна MainWindow,
        // Текущее окно-заставка закрывается, и основное окно отображается.
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;

            if (progressBar.Value > 99)
            {
                MainWindow mainWindow = new MainWindow();
                Close();
                mainWindow.ShowDialog();
            }
        }
    }
}
