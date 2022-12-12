using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GalkinaKursach
{
    public partial class MainMenu : Form
    {
        FileController fileController; //Контроллеер для работы с файлами
        AnalyzeController analyzeController; //Контроллер для анализа данных
        List<string[]> importData; //Список, в который мы будем записывать входные данные из файла
        public MainMenu()
        {
            InitializeComponent();
            fileController = new FileController(); //Инициализируем контроллеры при старте программы
            analyzeController = new AnalyzeController();
            ClearOldData(); //Вызываем метод для очистки имеющихся данных в таблицах и графиках
        }

        private void ClearOldData()
        {
            ClearInputDataTable(); //Очищаем таблицу с входными данными
            ClearResultDataTable(); //Очищаем таблицы с обычным и средним результатом анализа
            chart.Series.Clear(); //Очищаем график

            int minAverageValue = Constants.DEFAULT_MIN_VALUE * 7; //Заполняем данные в текстовые поля внизу программы:
            int maxAverageValue = Constants.DEFAULT_MAX_VALUE * 7; //7 потому что для каждой станции в файле по 7 измерений

            labelDataInfo.Text = "Нормальными значениями при однократном измерении станции считаются значения от " + Constants.DEFAULT_MIN_VALUE.ToString() + " до " + Constants.DEFAULT_MAX_VALUE.ToString();
            labelAverageDataInfo.Text = "Нормальными суммарными значениями по одной станции считаются значения от " + minAverageValue.ToString() + " до " + maxAverageValue.ToString();
        }
        private void ClearInputDataTable() //Метод для очистки таблицы с входными данными
        {
            importDataTable.Rows.Clear(); //Очищаем строки
            importDataTable.ReadOnly = true; //Указываем параметр readOnly, чтобы нельзя было вручную изменять данные в таблице
            importDataTable.RowCount = 1; //Для старта добавляем в таблицу пустую строку
            //Класс Constants был заведён для более удобного взаимодействия с программой и для большего понимания кода
            importDataTable.ColumnCount = Constants.INPUT_DATA_LIST_COUNT; //Берём из констант количество столбцов для входных данных

            importDataTable.Columns[0].HeaderText = "№ станции"; //Заполняем заголовки
            importDataTable.Columns[1].HeaderText = "Время фиксации";
            importDataTable.Columns[2].HeaderText = "Значение";
            importDataTable.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            importDataTable.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            importDataTable.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ClearResultDataTable()  //Метод для очистки таблиц с результирующими данными. Выше аналогичный пример
        {
            resultDataTable.Rows.Clear();
            resultDataTable.ReadOnly = true;
            resultDataTable.RowCount = 1;
            resultDataTable.ColumnCount = Constants.RESULT_DATA_LIST_COUNT;

            resultDataTable.Columns[0].HeaderText = "№ станции";
            resultDataTable.Columns[1].HeaderText = "Время фиксации";
            resultDataTable.Columns[2].HeaderText = "Значение";
            resultDataTable.Columns[3].HeaderText = "Результат";
            resultDataTable.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resultDataTable.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resultDataTable.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resultDataTable.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            averageResultDataTable.Rows.Clear();
            averageResultDataTable.ReadOnly = true;
            averageResultDataTable.RowCount = 1;
            averageResultDataTable.ColumnCount = Constants.RESULT_AVERAGE_DATA_LIST_COUNT;

            averageResultDataTable.Columns[0].HeaderText = "№ станции";
            averageResultDataTable.Columns[1].HeaderText = "Среднее суточное значение";
            averageResultDataTable.Columns[2].HeaderText = "Результат";
            averageResultDataTable.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            averageResultDataTable.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            averageResultDataTable.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        }

        private void importMenuButton_Click(object sender, EventArgs e) //Код метода кнопки импорт
        {
            importData = fileController.ImportInputFile(); //Вызываем из fileController метод ImportInputFile для того, чтобы считать все данные из входного файла
                                                           //и записываем в importData

            ClearOldData(); //Очищаем таблицы от предыдущих значений

            if (importData == null) //Если данные еще не импортированы
            {
                //Уведомляем об этом пользователя
                MessageBox.Show("Проверьте наличие входного файла и корректность входных данных", "Ошибка при импорте файла...");
                //Прекращаем дальнейшую работу метода
                return;
            }

            for (int i = 0; i < importData.Count; i++) //Проходимся по импортированным данным и заполняем таблицу
            {
                importDataTable.Rows.Add(); //Добавляем новую строку
                importDataTable.Rows[i].Cells[Constants.STATION_NUMBER].Value = importData[i][Constants.STATION_NUMBER]; //Заполняем ячейку с номером
                importDataTable.Rows[i].Cells[Constants.STATION_TIME].Value = importData[i][Constants.STATION_TIME]; //Заполняем ячейку с временем
                importDataTable.Rows[i].Cells[Constants.STATION_VALUE].Value = importData[i][Constants.STATION_VALUE]; //Заполняем ячейку со значением
            }
        }

        private void analyzeMenuButton_Click(object sender, EventArgs e) //Код метода кнопки анализ
        {
            if (importData == null) //Если данные еще не импортированы
            {
                //Уведомляем об этом пользователя
                MessageBox.Show("Входные данные пусты, для начала импортируйте файл!");
                //Прекращаем дальнейшую работу метода
                return;
            }
            ClearResultDataTable(); //Очищаем таблицы с результатом от предыдущих значений

            List<Statistic> resultAnalyzeData = analyzeController.Analyze(importData); //Выполняем анализ входных данных и записываем результат в resultAnalyzeData

            if (resultAnalyzeData == null) //Если усреднённые данные не получилось получить (может возникнуть при некорректных входных данных)
            {
                //Уведомляем об этом пользователя
                MessageBox.Show("При анализе входных данных произошла непредвиденная ошибка", "Ошибка...");
                //Прекращаем дальнейшую работу метода
                return;
            }

            for (int i = 0; i < resultAnalyzeData.Count; i++) //Проходимся по результирующим данным и заполняем таблицу
            {
                resultDataTable.Rows.Add();
                resultDataTable.Rows[i].Cells[Constants.STATION_NUMBER].Value = resultAnalyzeData[i].Num; //Номер
                resultDataTable.Rows[i].Cells[Constants.STATION_TIME].Value = resultAnalyzeData[i].Time; //Время
                resultDataTable.Rows[i].Cells[Constants.STATION_VALUE].Value = resultAnalyzeData[i].Value; //Значение
                resultDataTable.Rows[i].Cells[Constants.STATION_RESULT].Value = resultAnalyzeData[i].Result; //Результат

                //Окрашиваем значение в зависимости от того, выходит оно за диапазон или нет
                //Коротко объясняю эту строку: Цвет ячейки со значением = Если IsHigh == true (значение превышено) окрашиваем в красный, иначе в зелёный
                resultDataTable.Rows[i].Cells[Constants.STATION_VALUE].Style.BackColor = resultAnalyzeData[i].IsHigh ? Color.Red : Color.Green;
            }

            //Выполняем анализ входных данных и записываем усреднённый результат в resultAverageAnalyzeData
            List<Statistic> resultAverageAnalyzeData = analyzeController.AverageAnalyze(importData);
            //Выполняем аналогичные выше действия
            if (resultAnalyzeData == null)
            {
                MessageBox.Show("При анализе усреднённых данных произошла непредвиденная ошибка", "Ошибка...");
                return;
            }

            for (int i = 0; i < resultAverageAnalyzeData.Count; i++)
            {
                averageResultDataTable.Rows.Add();
                averageResultDataTable.Rows[i].Cells[0].Value = resultAverageAnalyzeData[i].Num;
                averageResultDataTable.Rows[i].Cells[1].Value = resultAverageAnalyzeData[i].Value;
                averageResultDataTable.Rows[i].Cells[2].Value = resultAverageAnalyzeData[i].Result;

                averageResultDataTable.Rows[i].Cells[1].Style.BackColor = resultAverageAnalyzeData[i].IsHigh ? Color.Red : Color.Green;
            }

            //Заполняем график
            //Задаём ему зветовую палитру для красоты
            chart.Palette = ChartColorPalette.SeaGreen;
            //Проходимся по усреднённым значениям и заполняем график
            for (int i = 0; i < resultAverageAnalyzeData.Count; i++)
            {
                Series series = this.chart.Series.Add("Станция " + resultAverageAnalyzeData[i].Num);
                series.Points.Add(resultAverageAnalyzeData[i].Value);
            }
        }

        private void faqMenuButton_Click(object sender, EventArgs e)
        {
            string faqInformation = "Выполнила работу" + Environment.NewLine;
            faqInformation += "ст. гр. БАБ-21-21" + Environment.NewLine;
            faqInformation += "Галкина Виктория Владимировна";
            MessageBox.Show(faqInformation, "Информация о разрботчике"); //Выводим информацию о разработчике
        }
    }

    internal class FileReader //Класс для чтения файла
    {
        public string Path { get; set; } //Сюда записывается название файла
        public List<string> ContentList; //Сюда будеем записывать список строк файла. По сути это массив строк файла, но динамический

        public FileReader(string _path) //Иницилизация класса
        {
            this.Path = _path; //Указываем название файла
            this.LoadFile(); //Загружаем данные
        }

        private void LoadFile() //Метод загрузки файлов 
        {
            try
            {
                this.ContentList = new List<string>();

                StreamReader f = new StreamReader(this.Path); //Проходимся по каждой строке файла
                while (!f.EndOfStream)
                {
                    string textLine = f.ReadLine();
                    ContentList.Add(textLine); //и записываем в список
                }
                f.Close(); //Завершаем работу с файлом
            }
            catch
            {
                this.ContentList = null; //В случае какой либо ошибки возвращаем пустое значение
            }
        }

        public bool isLoadSuccess() //Метод для проверки что загрузка прошла успешно
        {
            return this.ContentList != null;
        }
    }

    internal class FileController //Контроллер для работы с файлами
    {
        public string inputFilePath = "InputFile.txt"; //Название фаайла, из которого считываем данные
        public FileController() { } //Инициализируем класс


        public List<string[]> ImportInputFile() //Метод для импорта файла
        {
            try
            {
                FileReader fileReader = new FileReader(inputFilePath); //Импортируем файл
                if (!fileReader.isLoadSuccess()) return null; //Если всё успешно, то продолжаем, иначе обрываем работу и возвращаем пустоее значение
                return this.TransformInputData(fileReader.ContentList); //в случае если всё успешно возвращаем результат метод обработки входных данныъ
            }
            catch
            {
                return null;
            }
        }

        private List<string[]> TransformInputData(List<string> _dataList) //Метод обрааботки входных данных
        {
            List<string[]> inputData = new List<string[]>(); //Создаем список, который будем возвращать

            foreach (string _dataItem in _dataList) //Проходимся по всем строчкам полученных импортированных данных и превращаем их в полноценный массив
            {//с помощью разделения строки на отдельные элементы через пробел
                inputData.Add(_dataItem.Split(' '));
            }

            return inputData;
        }
    }

    internal class Constants //Константы для работы
    {
        public const int STATION_NUMBER = 0; //Индекс номера станции
        public const int STATION_TIME = 1; //Индекс времени станции
        public const int STATION_VALUE = 2; //Индекс значения станции в указанное время

        public const int STATION_RESULT = 3; //Для результирующего списка. Индекс с результатом

        public const int INPUT_DATA_LIST_COUNT = 3; //Количество элементов списка во входных данных
        public const int RESULT_DATA_LIST_COUNT = 4; //Количество элементов списка в результирующих данных
        public const int RESULT_AVERAGE_DATA_LIST_COUNT = 3; //Количество элементов списка в усреднённых результирующих данных

        public const int DEFAULT_MIN_VALUE = 15; //Минимальное значение показателя выбросов (можно менять по желанию)
        public const int DEFAULT_MAX_VALUE = 20; //Максимальное значение показателя выбросов (можно менять по желанию)

        //Возможные результаты
        public const string RESULT_NORMAL = "Результат в пределах нормы или ниже";
        public const string RESULT_HIGH = "Результат является очень высоким. Требуется провести дополнительную проверку станции.";
    }
    internal class AnalyzeController //Контроллер для выполнения анализа
    {
        public AnalyzeController() { }

        public List<Statistic> Analyze(List<string[]> _inputDataList)  //Метод анализа, который возвращает список элементов статистики
        {
            try
            {
                List<Statistic> resultDataList = new List<Statistic>();

                foreach (var inputData in _inputDataList) //Проходимся по входным данным
                {
                    Statistic result = new Statistic(); //Создаём элемент класса статистики

                    result.Num = Convert.ToInt32(inputData[Constants.STATION_NUMBER]); //Записываем номер станции
                    result.Time = inputData[Constants.STATION_TIME];  //Записываем время фиксации
                    result.Value = Convert.ToDouble(inputData[Constants.STATION_VALUE]); //Записываем значение

                    double stationValue = Convert.ToDouble(inputData[Constants.STATION_VALUE]); //Проверяем значение станции на то, входит ли оно в диапазон нормального значения
                    bool isStationValueNormal = (stationValue <= Constants.DEFAULT_MIN_VALUE) ||
                                                (stationValue >= Constants.DEFAULT_MIN_VALUE && stationValue <= Constants.DEFAULT_MAX_VALUE);

                    result.IsHigh = !isStationValueNormal; //Записываем сюда
                    result.Result = isStationValueNormal ? Constants.RESULT_NORMAL : Constants.RESULT_HIGH; //В зависимости от параметра isStationValueNormal записываем нужный результат (смотрите константы выше)

                    resultDataList.Add(result); //Добавляем элемент класса статистики в результирующий список
                }
                return resultDataList; //Возвращаем результирующий список
            }
            catch //В случае ошибки возвращаем пустое значение
            {
                return null;
            }
        }

        public List<Statistic> AverageAnalyze(List<string[]> _inputDataList) //Метод усреднённого анализа, который возвращает список элементов статистики
        {
            try
            {
                List<string[]> averageInputDataList = new List<string[]>();

                List<string> uniqueList = new List<string>(); //Получаем все номера станций, которые были во входных данных
                foreach (var data in _inputDataList) uniqueList.Add(data[Constants.STATION_NUMBER]);

                HashSet<string> myUnique = new HashSet<string>(uniqueList.ToArray()); //И записываем в uniqueList только уникальные значения без повторений
                uniqueList = myUnique.ToArray().ToList<string>();

                for (int i = 0; i < uniqueList.Count; i++) //Проходимся по списку станций
                {
                    string[] averageData = new string[3];
                    int stationValueLength = 0;

                    foreach (var inputData in _inputDataList) //Проходимся по всем показаателям
                    {
                        if (uniqueList[i] == inputData[Constants.STATION_NUMBER])
                        {
                            //Записываем номер станции
                            averageData[Constants.STATION_NUMBER] = inputData[Constants.STATION_NUMBER];
                            averageData[Constants.STATION_TIME] = "00:00";
                            //Суммируем все показания одной станции
                            averageData[Constants.STATION_VALUE] = (Convert.ToDouble(averageData[Constants.STATION_VALUE]) + Convert.ToDouble(inputData[Constants.STATION_VALUE])).ToString();
                            stationValueLength++; //Считаем количество всех показаний у одной станции
                        }
                    }
                    //Получаем усреднённое значение станции
                    averageData[Constants.STATION_VALUE] = (Convert.ToDouble(averageData[Constants.STATION_VALUE]) / Convert.ToDouble(stationValueLength)).ToString();
                    averageInputDataList.Add(averageData); //Добавляем данные по станции в общий список
                }

                return Analyze(averageInputDataList); //Отправляем общие даанные по станции на анализ и возвращаем результат обратно
            }
            catch //В случае ошибки возвращаем пустое значение
            {
                return null;
            }
        }
    }

    public class Statistic //Класс для статистики
    {
        public int Num { get; set; } //Номер станции
        public string Time { get; set; } //Время фиксации значений
        public double Value { get; set; } //Значение выбросов в указанное время
        public string Result { get; set; } //Результат
        public bool IsHigh { get; set; } //Параметр, указывающий на то, превышено ли значение или нет

        public Statistic() { } //Инициализаторы класса
        public Statistic(int _num, string _time, int _value, string _result, bool _isHigh)
        {
            this.Num = _num;
            this.Time = _time;
            this.Value = _value;
            this.Result = _result;
            this.IsHigh = _isHigh;
        }
    }
}


