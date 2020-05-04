namespace Task_1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model_info_type2 : DbContext
    {
        // Контекст настроен для использования строки подключения "Model_info_type2" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Task_1.Model_info_type2" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model_info_type2" 
        // в файле конфигурации приложения.
        public Model_info_type2()
            : base("name=Model_info_2")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Information> information { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}