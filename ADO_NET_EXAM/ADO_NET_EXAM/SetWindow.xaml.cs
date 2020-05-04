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
using Vacancy;

namespace ADO_NET_EXAM
{
    /// <summary>
    /// Логика взаимодействия для SetWindow.xaml
    /// </summary>
    public partial class SetWindow : Window
    {
        public SetWindow()
        {
            InitializeComponent();
            using (Vacancy_ModelContainer db = new Vacancy_ModelContainer())
            {
                lvSync.ItemsSource = db.CategorySet.ToList();
                    }
        }

        private void btn_set_Click(object sender, RoutedEventArgs e)
        {
        using (Vacancy_ModelContainer db = new Vacancy_ModelContainer())
        {
            Work_with_class.setVacancies(tbLink.Text, tbName.Text);
            lvSync.ItemsSource = db.CategorySet.ToList();
        }
        }
    }
}
