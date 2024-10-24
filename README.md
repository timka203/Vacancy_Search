# Vacancy_Search
Vacancy_Search - программа для получения вакансий с сайта http://vacancy.kharkov.ua/widgets/rssfeeds
В приложении есть следующие пункты меню:
а. Категории вакансий
б. Поиск работы
c. Настройки

Категории вакансий

В этом пункте меню есть обычный каталог, в котором вы можете ввести название категории и ссылку на ее RSS-контент.
После того, как пользователь заполнил все поля и нажал кнопку «Сохранить», информация по ссылке выгружается и загружается в базу данных.

Поиск работы

В этом пункте меню вы можете искать по следующим критериям:
1. Категория вакансий
2. Дата публикации
3. По электронной почте автора
4. Фраза, содержащаяся в описании должности.
После того, как пользователь выбрал все критерии поиска и нажал кнопку «Поиск», список вакансий загружается в таблицу ниже. Таблица содержит следующие столбцы:
1. Название
2. Ссылка на вакансию
3. Описание
4. Дата публикации
5. Электронная почта автора

Настройки

Содержит информацию о категориях и количестве сообщений в этой категории.


Vacancy_Search - a program for obtaining vacancies from the site http://vacancy.kharkov.ua/widgets/rssfeeds
The application has the following menu items:
a. Job Categories
b. Job search
c. Settings

Job Categories

This menu item has a regular directory where you can enter a category name and a link to its RSS content.
After the user has filled in all the fields and pressed the "Save" button, the information on the link is unloaded and loaded into the database.

Job search

In this menu item you can search by the following criteria:
1. Category of vacancies
2. Date of publication
3. By email to the author
4. The phrase contained in the job description.
After the user has selected all the search criteria and clicked the "Search" button, the list of vacancies is loaded into the table below.
The table contains the following columns:
1. Title
2. Link to vacancy
3. Description
4. Date of publication
5. Email of the author
Settings
Contains information about the categories and the number of posts in this category.




Task_1- консольное приложение, которое выгружает данные с базы данных, каждые 5 минут.
Приложение подключаеться по ссылке - http://www.nationalbank.kz/rss/rates.xml, получает курсы валют и загружает их в таблицу TableExchangeRate.
 При этом происходит проверка произошло ли изменение в курсах валют.
 Если изменения есть то данные загружаются.
 Если изменений нет, то запись в таблицу не делается.
 Так же делается проверка на наличие записи на сегодняшний день.
  В случае неуспешной загрузки данных в таблицу, или же отсутствие курса по ссылке, приложение уведомлет администратора письмом на его почту, 
в котором  полное описание проблемы, которая возникла.



Task_1 is a console application that unloads data from the database every 5 minutes.
The application is connected via the link - http://www.nationalbank.kz/rss/rates.xml, receives exchange rates and loads them into the TableExchangeRate table.
 In this case, a check is made whether there has been a change in the exchange rates.
 If there are changes, then the data is loaded.
 If there are no changes, then no entry is made in the table.
 It also checks for the presence of a record to date.
  In case of unsuccessful loading of data into the table, or the absence of a course by reference, the application will notify the administrator 
by a letter to his mail, in which a full description of the problem that arose.  




Vacancy_info- классы для работы Vacancy_Search.
  Для работы базы данных стоит изменить connectionString  в файле App.config в Vacancy_Search и в Vacancy_info
 

 Потом открыть файл Vacancy_Model.edmx.sql и запустить написанный там скрипт в нужной вам базе данных 
Vacancy_info- classes for Vacancy_Search to work.
   For the database to work, it is worth changing the connectionString in the App.config file in Vacancy_Search and in Vacancy_info
   Then open the Vacancy_Model.edmx.sql file and run the script written there in the database you need

