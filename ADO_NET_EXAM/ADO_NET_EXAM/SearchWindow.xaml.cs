using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();

       


        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Vacancy_ModelContainer db = new Vacancy_ModelContainer())
                {
                    if (tbtitle.Text != "")
                    {
                        lvSync.ItemsSource = from a in db.CategorySet.ToList() where a.Category_Name == tbtitle.Text select a.Id into id from v in db.VacancySet where v.CategoryId == id select v;  //db.CategorySet.ToList().Where(w => w.Category_Name == tbtitle.Text).Single().Vacancy;



                        if (tbdes.Text != "")
                        {
                            lvSync.ItemsSource = from a in db.CategorySet.ToList() where a.Category_Name == tbtitle.Text select a.Id into id from v in db.VacancySet where v.CategoryId == id && v.description == tbdes.Text select v;

                        }
                        else if (tbauthor.Text != "")
                        {
                            lvSync.ItemsSource = from a in db.CategorySet.ToList() where a.Category_Name == tbtitle.Text select a.Id into id from v in db.VacancySet where v.CategoryId == id && v.author == tbauthor.Text select v;
                        }
                        else if (tbpubDate.Text != "")
                        {
                            lvSync.ItemsSource = from a in db.CategorySet.ToList() where a.Category_Name == tbtitle.Text select a.Id into id from v in db.VacancySet where v.CategoryId == id && v.pubDate == tbpubDate.Text select v;
                        }
                    }


                    else
                    {

                        if (tbdes.Text != "")
                        {
                            lvSync.ItemsSource = from a in db.VacancySet.ToList() where a.description == tbdes.Text select a;

                        }
                        else if (tbauthor.Text != "")
                        {
                            lvSync.ItemsSource = from a in db.VacancySet.ToList() where a.author == tbauthor.Text select a;
                        }
                        else if (tbpubDate.Text != "")
                        {
                            lvSync.ItemsSource = from a in db.VacancySet.ToList() where a.pubDate == tbpubDate.Text select a;
                        }
                        else
                            lvSync.ItemsSource = from v in db.VacancySet.ToList() select v;
                    }


                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());

            }

         
                                 //where a.author == tbauthor.Text || a.description == tbdes.Text || a.pubDate == tbpubDate.Text
                               //  select a;    
        }

        private void tbauthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbauthor.Text != "")
            {
                tbauthor.IsEnabled = true;
                tbdes.IsEnabled = false;
                tbpubDate.IsEnabled = false;
           
            }
            else
            {
                tbauthor.IsEnabled = true;
                tbdes.IsEnabled = true;
                tbpubDate.IsEnabled = true;
                tbtitle.IsEnabled = true;
            }

        }

        private void tbpubDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbpubDate.Text != "")
            {
                tbauthor.IsEnabled = false;
                tbdes.IsEnabled = false;
                tbpubDate.IsEnabled = true;
  
            }
            else
            {
                tbauthor.IsEnabled = true;
                tbdes.IsEnabled = true;
                tbpubDate.IsEnabled = true;
                tbtitle.IsEnabled = true;
            }
        }

        private void tbdes_TextChanged(object sender, TextChangedEventArgs e)
        {if (tbdes.Text != "")
            {
                tbauthor.IsEnabled = false;
                tbdes.IsEnabled = true;
                tbpubDate.IsEnabled = false;
           
            }
            else
            {
                tbauthor.IsEnabled = true;
                tbdes.IsEnabled = true;
                tbpubDate.IsEnabled = true;
                tbtitle.IsEnabled = true;
            }
        }

        private void tbtitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
