using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
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
using System.Data.Entity;

namespace ADO_NET_EXAM
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        //string template_with_user = "metadata=res://*/Vacancy_model.csdl|res://*/Vacancy_model.ssdl|res://*/Vacancy_model.msl;" +
        //           "provider=System.Data.SqlClient;" +
        //           "provider connection string=/" +
        //           "data source=;initial catalog=;" +
        //           "Persist Security Info=True;User ID=;Password=;" +
        //           "MultipleActiveResultSets=True;App=EntityFramework&quot;";
        //string template_without_user = "metadata=res://*/Vacancy_Model.csdl|res://*/Vacancy_Model.ssdl|res://*/Vacancy_Model.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=;" +
        //    "initial catalog=;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        //bool isuser=true;

        // string connstr;
        public SettingsWindow()
        {

            InitializeComponent();
            try
            {
                using (Vacancy.Vacancy_ModelContainer db = new Vacancy.Vacancy_ModelContainer())
                {
                    lvSync.ItemsSource = db.CategorySet.ToList().Select(s => new { Category_Name = s.Category_Name, Count = s.Vacancy.Count() });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }



            //connstr = GetConnStr();
            //try
            //{
            //    var connstr_arr = connstr.Substring(connstr.IndexOf("connection string")).Split(';');
            //    server.Text = connstr_arr.Where(a => a.Contains("data source")).Single().Substring(31);
            //    table.Text = connstr_arr.Where(a => a.StartsWith("initial catalog=")).Single().Substring(16);
            //}
            //catch {
            //    var connstr_arr = connstr.Split(';');
            //    server.Text = connstr_arr.Where(a => a.Contains("Data Source")).Single().Substring(12);
            //    table.Text = connstr_arr.Where(a => a.StartsWith("Initial Catalog=")).Single().Substring(16);
            //}
           


            //connectionStringsSection.ConnectionStrings["Vacancy_modelContainer"].ConnectionString 
            //  config.Save();
            //  ConfigurationManager.RefreshSection("connectionStrings");
        }
        //string GetConnStr()
        //{
        //    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
        //    return connectionStringsSection.ConnectionStrings["Vacancy_modelContainer"].ConnectionString;
        //}

        //private void rb_with_user_Click(object sender, RoutedEventArgs e)
        //{
        //    user.IsEnabled = true;
        //    password.IsEnabled = true;
        //    isuser = true;
        //}

        //private void rb_withot_user_Click(object sender, RoutedEventArgs e)
        //{
        //    user.IsEnabled = false;
        //    password.IsEnabled = false;
        //    isuser = false;
        //}

        //private void btn_search_Click(object sender, RoutedEventArgs e)
        //{


        //    if (isuser)
        //    {

        //    }
        //    else
        //    {
        //        // string providerName = "System.Data.SqlClient";
        //        // string serverName = server.Text;
                // string databaseName = table.Text;

                // Initialize the connection string builder for the
                // underlying provider.

                //SqlConnectionStringBuilder sqlBuilder =
                //    new SqlConnectionStringBuilder();

                // Set the properties for the data source.
                //sqlBuilder.DataSource = serverName;
                //sqlBuilder.InitialCatalog = databaseName;
                // sqlBuilder.IntegratedSecurity = true;

                // Build the SqlConnection connection string.
                // string providerString = sqlBuilder.ToString();

                // Initialize the EntityConnectionStringBuilder.
                //EntityConnectionStringBuilder entityBuilder =
                //    new EntityConnectionStringBuilder();

                // Set the provider name.
                // entityBuilder.Provider = providerName;

                // Set the provider - specific connection string.
                //  entityBuilder.ProviderConnectionString = providerString;

                // Set the Metadata location.
                // entityBuilder.Metadata = @"res://*/Vacancy_Model.csdl|
                //             res://*/Vacancy_Model.ssdl|
                //             res://*/Vacancy_Modell.msl";
                // var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                // connectionStringsSection.ConnectionStrings["Vacancy_ModelContainer"].ConnectionString = entityBuilder.ToString();
                // config.Save();
                // ConfigurationManager.RefreshSection("connectionStrings");

                // using (Vacancy.Vacancy_ModelContainer db = new Vacancy.Vacancy_ModelContainer())
                // {
                //     db.Database.Connection.ConnectionString = sqlBuilder.ToString();

                //     MessageBox.Show(db.Database.Connection.ConnectionString);


                // }


                //use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
        //        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //        var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
        //        using (Vacancy.Vacancy_ModelContainer source = new Vacancy.Vacancy_ModelContainer())
        //        {
        //            SqlConnectionStringBuilder sqlCnxStringBuilder;
        //            // add a reference to System.Configuration
        //            try
        //            {
        //                var entityCnxStringBuilder = new EntityConnectionStringBuilder
        //                {
        //                    ProviderConnectionString = new SqlConnectionStringBuilder(System.Configuration.ConfigurationManager
        //          .ConnectionStrings["Vacancy_ModelContainer"].ConnectionString).ConnectionString
        //                };
        //                sqlCnxStringBuilder = new SqlConnectionStringBuilder
        //              (entityCnxStringBuilder.Provider);
        //            }
        //            catch
        //            {



        //                var entityCnxStringBuilder = new EntityConnectionStringBuilder { 
        //                    ProviderConnectionString = new SqlConnectionStringBuilder(System.Configuration.ConfigurationManager
        //                    .ConnectionStrings["Vacancy_ModelContainer"].ConnectionString).ConnectionString };
        //                sqlCnxStringBuilder = new SqlConnectionStringBuilder
        //              (entityCnxStringBuilder.Provider);
        //            }

        //            // init the sqlbuilder with the full EF connectionstring cargo


        //            // only populate parameters with values if added
        //            if (!string.IsNullOrEmpty(table.Text))
        //                sqlCnxStringBuilder.InitialCatalog = table.Text;
        //            if (!string.IsNullOrEmpty(server.Text))
        //                sqlCnxStringBuilder.DataSource = server.Text;


        //            // set the integrated security status
        //            sqlCnxStringBuilder.IntegratedSecurity = true;

        //            // now flip the properties that were changed
        //            source.Database.Connection.ConnectionString
        //                = sqlCnxStringBuilder.ConnectionString;


        //            connectionStringsSection.ConnectionStrings["Vacancy_ModelContainer"].ConnectionString = sqlCnxStringBuilder.ConnectionString;
        //            config.Save();
        //            ConfigurationManager.RefreshSection("connectionStrings");
        //        }
        //        }
        //}



        //    }
           
    }
    

