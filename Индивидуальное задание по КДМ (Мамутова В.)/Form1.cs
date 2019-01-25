using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Индивидуальное_задание_по_КДМ__Мамутова_В._
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClearImage();
            InitColors();

            IsColorDialogOpen = false;
            GraphHasColoring = false;
            IsLoadingFromFile = true;

            GraphType.SelectedIndex = 0;
            IsLoadingFromFile = false;
        }
        List<Color> colorList; // Список цветов.
        private int[] vertexesColor; // Массив цветов для окрашивания вершин.

        Thread drawVertexesThread;
        Thread fillTableThread;

        private bool IsColorDialogOpen; // Открыт диалог для выбора цвета.
        private bool GraphHasColoring; // Для текущего графа уже найдена правильная раскраска.
        private bool IsLoadingFromFile; // Происходит загрузка из файла.

        // Создание и инициализация списка цветов по умолчанию.
        void InitColors()
        {
            colorList = new List<Color>();

            // Чтение наименований цветов из файла.
            string colorName;
            try
            {
                FileStream file = new FileStream(Application.StartupPath + "\\Colors.txt", FileMode.Open);
                StreamReader streamReader = new StreamReader(file, Encoding.UTF8);
                while (streamReader.EndOfStream != true)
                {
                    colorName = streamReader.ReadLine();
                    colorList.Add(Color.FromName(colorName));

                    // Если цвет в файле был указан в RGB, то значение colorList стало равно
                    if (colorList[colorList.Count - 1].A == 0)
                        colorList[colorList.Count - 1] = Color.FromArgb(255, Convert.ToInt32(colorName.Substring(0, 3)), Convert.ToInt32(colorName.Substring(4, 3)), Convert.ToInt32(colorName.Substring(8, 3)));
                }
                streamReader.Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка при инициализации списка цветов!\nПричина: " + ex.Message + "\nПроверьте наличие и формат файла \"Colors.txt\""); }

            // Выводим цвета в таблицу.
            ColorGrid.RowCount = colorList.Count;

            for (int i = 0; i < ColorGrid.RowCount; i++)
            {
                // Ставим порядковый номер цвета.
                ColorGrid.Rows[i].Cells[0].Value = (i + 1).ToString();
                ColorGrid.Rows[i].Height = 40;

                // Окрашиваем ячейки в цвета списка.
                ColorGrid.Rows[i].Cells[1].Style.BackColor = colorList[i];
                ColorGrid.Rows[i].Cells[1].Style.SelectionBackColor = colorList[i];
                ColorGrid.Rows[i].Cells[0].ToolTipText = colorList[i].Name.ToString();
                ColorGrid.Rows[i].Cells[1].Style.SelectionForeColor = Color.Black;
            }
        }

        // Смена цвета пользователем.
        private void ColorGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                // Открываем диалоговое окно для выбора цвета.
                IsColorDialogOpen = true;
                colorDialog.FullOpen = true;
                colorDialog.Color = colorList[e.RowIndex];
                colorDialog.ShowDialog();
                
                colorList[e.RowIndex] = colorDialog.Color; // Меняем цвет в списке.

                // Окрашиваем ячейку в выбранный цвет.
                ColorGrid.Rows[e.RowIndex].Cells[1].Style.BackColor = colorDialog.Color;
                ColorGrid.Rows[e.RowIndex].Cells[1].Style.SelectionBackColor = colorDialog.Color;
                ColorGrid.Rows[e.RowIndex].Cells[0].ToolTipText = colorDialog.Color.Name.ToString();
                
                IsColorDialogOpen = false;
            }
        }

        // Очистка холста для графа, заливка его белым цветом.
        void ClearImage()
        {
            Bitmap graphBitmap = new Bitmap(GraphImage.Width, GraphImage.Height);
            Graphics g = Graphics.FromImage(graphBitmap);
            g.Clear(Color.White);
            GraphImage.Image = graphBitmap;
        }

        // Добавление на холст вершин графа.
        void DrawVertexes(Image image, bool slowDown = false) {
            if(slowDown) Thread.Sleep(500);
            Bitmap graphBitmap = new Bitmap(image);
            Graphics g = Graphics.FromImage(graphBitmap);

            int count = Convert.ToInt32(VertexCount.Text);
            float radius = GraphImage.Width / 2 - 26; // Радиус большого круга, на окружности которого будут располагаться вершины.
            float angleDelta = 360F / count; // Угол, на который будет изменяться положение на окружности каждой новой рисуемой вершины.
            float x = 0, y = 0; // Координаты центра вершины.
            float angle = 135; // Угол, под которым расположена первая вершина.

            for (int i = 0; i < count; i++) {
                if (i != 0)
                    angle -= angleDelta;

                x = radius * (float)Math.Cos(angle * 3.14 / 180) + GraphImage.Width / 2;
                y = -radius * (float)Math.Sin(angle * 3.14 / 180) + GraphImage.Height / 2;

                // Опреляем цвет кисти в зависимости от того, была ли получена раскаска для текущего графа.
                Brush brush = new SolidBrush(GraphHasColoring ? colorList[vertexesColor[i]] : Color.LightPink);

                g.FillEllipse(brush, x - 13, y - 13, 26, 26);
                g.DrawString((i + 1).ToString(), DefaultFont, Brushes.Black, x - 7, y - 7);

                Invoke((MethodInvoker) delegate () { GraphImage.Image = graphBitmap; });
                
                if(slowDown)
                    Thread.Sleep(100);
            }
        }
        
        // Добавление ребра на холст.
        void DrawEdge(int vertex1, int vertex2, Graphics g)
        {
            float angleDelta = 360F / AdjacencyMatrix.RowCount;
            float x1 = 0, x2 = 0, y1 = 0, y2 = 0; // Координаты начала и конца отрезка ребра.
            float angle = 135; // Угол, под которым расположена первая вершина.
            float radius = GraphImage.Width / 2 - 26; // Радиус большого круга, на окружности которого будут располагаться вершины.

            // Находим угол, под котором расположена первая вершина.
            for (int k = 0; k < vertex1; k++)
                angle -= angleDelta;

            float cos = (float)Math.Cos(angle * 3.14 / 180);
            float sin = (float)Math.Sin(angle * 3.14 / 180);

            // Вычисляем координаты первой вершины.
            x1 = radius * cos + GraphImage.Width / 2 - 13 * cos;
            y1 = -radius * sin + GraphImage.Height / 2 + 13 * sin;

            // Находим угол, под которым расположена вторая вершина.
            if (vertex1 < vertex2)
                for (int k = vertex1; k < vertex2; k++)
                    angle -= angleDelta;
            else
                for (int k = vertex1; k > vertex2; k--)
                    angle += angleDelta;

            cos = (float)Math.Cos(angle * 3.14 / 180);
            sin = (float)Math.Sin(angle * 3.14 / 180);
            
            // Вычисляем коорднитаты второй вершины.
            x2 = radius * cos + GraphImage.Width / 2 - 13 * cos;
            y2 = -radius * sin + GraphImage.Height / 2 + 13 * sin;
            
            g.DrawLine(Pens.Black, x1, y1, x2, y2);

            // Рисуем стрелочку для орграфов.
            if (GraphType.SelectedIndex == 1)
            {
                x2 = (((x1 + x2) / 2) + x2) / 2;
                y2 = (((y1 + y2) / 2) + y2) / 2;

                float exAngle = (float)(180 * Math.Atan2(y2 - y1, x2 - x1) / 3.14);

                Point p1 = new Point((int)(x2 + (10 * Math.Cos(3.14 * (exAngle + 150) / 180))), (int)(y2 + (10 * Math.Sin(3.14 * (exAngle + 150) / 180))));
                Point p2 = new Point((int)(x2 + (10 * Math.Cos(3.14 * (exAngle - 150) / 180))), (int)(y2 + (10 * Math.Sin(3.14 * (exAngle - 150) / 180))));
                g.DrawLine(Pens.Black, x2, y2, p1.X, p1.Y);
                g.DrawLine(Pens.Black, x2, y2, p2.X, p2.Y);
            }
        }

        // Добавление рёбер для графа.
        void DrawEdges(bool slowDown = false)
        {
            Bitmap graphBitmap = new Bitmap(GraphImage.Image);
            Graphics g = Graphics.FromImage(graphBitmap);

            bool edgeWasPainted = false;
            for (int i = 0; i < AdjacencyMatrix.RowCount; i++)
                for (int j = 0; j < AdjacencyMatrix.ColumnCount; j++)
                {
                    // Для неорграфов достаточно пройти только по одной части матрицы
                    // для проведения ребёр (выше главной диагонали),
                    // для орграфов проверяем таблицу полноситью, так как она не симметрична.
                    Invoke((MethodInvoker)delegate ()
                    {
                        if ((GraphType.SelectedIndex == 0 && i < j) || (GraphType.SelectedIndex == 1))

                            if (AdjacencyMatrix.Rows[i].Cells[j].Value.ToString() != "0")
                            {
                                DrawEdge(i, j, g);

                                GraphImage.Image = graphBitmap;
                                edgeWasPainted = true;
                            }
                            else edgeWasPainted = false;
                        else edgeWasPainted = false;
                    });

                    if(slowDown && edgeWasPainted) Thread.Sleep(50);
                }

        }

        void AddRowsAndColumns(int count, int startIndex)
        {
            Invoke((MethodInvoker) delegate ()
            {
                // Добавляем необходимое количество колонок и строк таблицы c начального индекса.
                for (int i = startIndex; i < count; i++)
                {
                    AdjacencyMatrix.Columns.Add("Vertex" + i.ToString(), (i + 1).ToString());
                    AdjacencyMatrix.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                for (int i = startIndex; i < count; i++)
                {
                    AdjacencyMatrix.Rows.Add();
                    AdjacencyMatrix.Rows[i].HeaderCell.Value = (i + 1).ToString();

                    // Значения ячеек по главной диагонали матрицы смежности всегда равны нулю, их нельзя изменять.
                    AdjacencyMatrix.Rows[i].Cells[i].ReadOnly = true;
                }
            } );
        }

        // Создание таблицы со значениями по умолчанию и построение пустого графа.
        void CreateGraph()
        {
            ClearImage();
            GraphHasColoring = false;
            Cursor = Cursors.WaitCursor;

            drawVertexesThread = new Thread(() => { DrawVertexes(GraphImage.Image, true); });
            drawVertexesThread.Start();
            
            // Очищаем таблицу.
            AdjacencyMatrix.Rows.Clear();
            AdjacencyMatrix.Columns.Clear();

            int size = Convert.ToInt32(VertexCount.Text);
            if (size != 0)
            {
                // Добаляем строки и столбцы в пустую таблицу.
                AddRowsAndColumns(size, 0);

                fillTableThread = new Thread(() =>
                {
                    // Заполняем ячейки добавленных строк нулями.
                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                            AdjacencyMatrix.Rows[i].Cells[j].Value = 0.ToString();
                    Invoke((MethodInvoker)delegate { Cursor = Cursors.Arrow; });
                });
                fillTableThread.Start();
            }
            else Cursor = Cursors.Arrow;
        }

        // Изменение таблицы смежности с сохранением всех ранее введённых данных и обновлением рисунка графа.
        void RefreshGraph(int delta)
        {
            ClearImage();

            int prevSize = AdjacencyMatrix.RowCount; // Предыдущий размер таблицы.

            if (delta == -1)
            {
                AdjacencyMatrix.Rows.RemoveAt(prevSize - 1);
                AdjacencyMatrix.Columns.RemoveAt(prevSize - 1);
            }
            else
            {
                // Добавляем одну строку и один стобец в конец таблицы.
                AddRowsAndColumns(1 + prevSize, prevSize);

                // Заполняем ячейки добавленных строк нулями.
                for (int i = 0; i < AdjacencyMatrix.RowCount; i++)
                    AdjacencyMatrix.Rows[i].Cells[prevSize].Value =
                    AdjacencyMatrix.Rows[prevSize].Cells[i].Value = 0.ToString();
            }
            GraphHasColoring = false;
            DrawVertexes(GraphImage.Image);
            DrawEdges();
        }

        int GetColor(int i, int[] vertexesColor)
        {
            // Получение цвета вершины.
            List<int> colorList = new List<int>(); // Список цветов вершин, смежных с рассматриваемой.
            int j;

            FileStream file = new FileStream(Application.StartupPath + "\\Алгоритмы правильной раскраcки\\" + "Правильная раскраска " + (GraphType.SelectedIndex == 0 ? "нео" : "ор") + "графа на " + AdjacencyMatrix.RowCount + " вершин.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(file);
            try
            {
                // Добавляем в список порядковые номера цветов, в которые окрашены смежные вершины.
                for (j = 0; j < i; j++)
                {
                    if (AdjacencyMatrix.Rows[j].Cells[i].Value.ToString() != "0")
                    {
                        colorList.Add(vertexesColor[j]);
                        streamWriter.WriteLine((j + 1).ToString() + " (цвет " + (vertexesColor[j] + 1) + ") ");
                    }
                    // Для орграфов проверяем дополнительно симметричную позицию.
                    else if (GraphType.SelectedIndex == 1 && AdjacencyMatrix.Rows[i].Cells[j].Value.ToString() != "0")
                    {
                        colorList.Add(vertexesColor[j]);
                        streamWriter.WriteLine((j + 1).ToString() + " (цвет " + (vertexesColor[j] + 1) + ") ");
                    }
                }
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Обнаружена ошибка при записи шагов алгоритма в файл!\n" + ex.StackTrace + "\n\nПричина: " + ex.Message, "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            j = -1;

            // Находимый минимальный допустимый цвет.
            do
                j++;
            while (colorList.FindIndex(x => x.Equals(j)) != -1);
            return j;
        }

        private void GetGraphСoloring_Click(object sender, EventArgs e)
        {
            vertexesColor = new int[AdjacencyMatrix.RowCount]; // Массив цветов для вершин.
            
            // Инициализируем массив цветов для вершин.
            for (int i = 0; i < vertexesColor.Length; i++)
                vertexesColor[i] = -1;

            try
            {
                FileStream file = new FileStream(Application.StartupPath + "\\Алгоритмы правильной раскраcки\\" + "Правильная раскраска " + (GraphType.SelectedIndex == 0 ? "нео" : "ор") + "графа на " + AdjacencyMatrix.RowCount + " вершин.txt", FileMode.Create, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(file);
                streamWriter.WriteLine("Нахождение правильной раскраски для " + (GraphType.SelectedIndex == 0 ? "нео" : "ор") + "графа на " + AdjacencyMatrix.RowCount + " вершин");
                streamWriter.Close();
                for (int i = 0; i < AdjacencyMatrix.RowCount; i++)
                {
                    file = new FileStream(Application.StartupPath + "\\Алгоритмы правильной раскраcки\\" + "Правильная раскраска " + (GraphType.SelectedIndex == 0 ? "нео" : "ор") + "графа на " + AdjacencyMatrix.RowCount + " вершин.txt", FileMode.Append, FileAccess.Write);
                    streamWriter = new StreamWriter(file);
                    streamWriter.WriteLine();
                    streamWriter.WriteLine("Рассматриваем вершину " + (i + 1) + ":");
                    streamWriter.WriteLine("Список смежных, уже раскрашенных вершин: ");
                    streamWriter.Close();

                    // Для каждой вершины находим цвет.
                    vertexesColor[i] = GetColor(i, vertexesColor);

                    file = new FileStream(Application.StartupPath + "\\Алгоритмы правильной раскраcки\\" + "Правильная раскраска " + (GraphType.SelectedIndex == 0 ? "нео" : "ор") + "графа на " + AdjacencyMatrix.RowCount + " вершин.txt", FileMode.Append, FileAccess.Write);
                    streamWriter = new StreamWriter(file);
                    streamWriter.WriteLine("Минимальный допустимый цвет - " + (vertexesColor[i] + 1));
                    streamWriter.Close();
                }

                GraphHasColoring = true;
                DrawVertexes(GraphImage.Image);

                MessageBox.Show("Шаги алгоритма успешно записаны в файл по следующему пути:\n" + file.Name, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Обнаружена ошибка при записи шагов алгоритма в файл!\n" + ex.StackTrace + "\n\nПричина: " + ex.Message, "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }             
        }

        private void cellText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (AdjacencyMatrix.CurrentCell.RowIndex != AdjacencyMatrix.CurrentCell.ColumnIndex)
            {
                int rowIndex = AdjacencyMatrix.CurrentCell.RowIndex;
                int columnIndex = AdjacencyMatrix.CurrentCell.ColumnIndex;

                // Если нажаты не ноль, не единица, значение не меняем.
                if ((e.KeyChar == '1' || e.KeyChar == '0') && (fillTableThread == null || !fillTableThread.IsAlive))
                {
                    (sender as TextBox).SelectionStart = 0;
                    (sender as TextBox).SelectionLength = 1;
                    AdjacencyMatrix.Rows[rowIndex].Cells[columnIndex].Value = e.KeyChar;

                    if (GraphType.SelectedIndex == 0) // Для неорграфов матрица смежности симметрична.
                        AdjacencyMatrix.Rows[columnIndex].Cells[rowIndex].Value = e.KeyChar;

                    GraphHasColoring = false;

                    if (e.KeyChar == '1') // Если нажата единица, рисуем ребро (ребро).
                    {
                        DrawVertexes(GraphImage.Image);
                        Bitmap graphBitmap = new Bitmap(GraphImage.Image);
                        Graphics g = Graphics.FromImage(graphBitmap);
                        DrawEdge(rowIndex, columnIndex, g);
                        GraphImage.Image = graphBitmap;
                        GraphImage.Size = graphBitmap.Size;
                    }
                    else
                    {
                        ClearImage();
                        DrawVertexes(GraphImage.Image);
                        DrawEdges();
                    }
                }
                else e.Handled = true;
            }
        }

        private void AdjacencyMatrix_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox cellText = e.Control as TextBox;
            cellText.MaxLength = 1;
            cellText.KeyPress -= cellText_KeyPress;
            cellText.KeyPress += new KeyPressEventHandler(cellText_KeyPress);
        }

        private void statusStrip_MouseHover(object sender, EventArgs e)
        {
            ColorGrid.Show();
        }

        private void ColorGrid_MouseLeave(object sender, EventArgs e)
        {
            if(!IsColorDialogOpen)
                ColorGrid.Hide();
        }

        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            openFileDialog.InitialDirectory = Application.StartupPath + "\\Графы";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    try
                    {
                        using (myStream) // Блок using гарантирует освобождение потока, связанный с чтением файла.
                        {
                            StreamReader streamReader = new StreamReader(myStream);
                            IsLoadingFromFile = true;

                            string Line; // Строка текстового файла.
                            char separator = ' '; // Разедлитель значений матрицы смежности.
                            int matrixSize = 0; // Размер матрицы (количество вершин в графе).
                            string[] cellValues; // Массив ячеек строки таблицы.
                            int lineCount = 0; // Порядковый номер считываемой строки.

                            if (streamReader.EndOfStream != true)
                            {
                                matrixSize = Convert.ToInt16(streamReader.ReadLine());

                                VertexCount.Text = matrixSize.ToString();

                                // Очищаем таблицу.
                                AdjacencyMatrix.Rows.Clear();
                                AdjacencyMatrix.Columns.Clear();

                                // Создаём новую таблицу.
                                AddRowsAndColumns(matrixSize, 0);
                            }

                            int[][] matrix = new int[matrixSize][]; // Создаём временную матрицу для занесения значений из файла.

                            while (streamReader.EndOfStream != true)
                            {
                                Line = streamReader.ReadLine(); // Считываем строку матрицы.
                                cellValues = Line.Split(separator); // Разбиваем на ячейки.

                                if (matrixSize == cellValues.Length && lineCount < matrixSize)
                                {
                                    matrix[lineCount] = new int[matrixSize];
                                    for (int i = 0; i < cellValues.Length; i++)
                                    {
                                        if (cellValues[i] != "0" && cellValues[i] != "1")
                                            throw new Exception("Элементы матрицы смежности должны быть равны либо 0, либо 1!");

                                        if (i == lineCount && cellValues[i] != "0")
                                            throw new Exception("Элементы матрицы смежности по главной диагонали должны быть равны нулю!");

                                        matrix[lineCount][i] = Convert.ToInt16(cellValues[i]);
                                    }
                                }
                                else throw new Exception("Неверно указан размер матрицы!");

                                lineCount++;
                            }
                            streamReader.Close();

                            // Определяем вид графа в зависимости от симметричности матрицы смежности.
                            int selectedType = 0;
                            for (int i = 0; i < matrixSize && selectedType == 0; i++)
                                for (int j = 0; j < matrixSize && selectedType == 0; j++)
                                    if (matrix[i][j] != matrix[j][i])
                                        selectedType = 1;

                            GraphType.SelectedIndex = selectedType;

                            GraphHasColoring = false;

                            Cursor = Cursors.WaitCursor;
                            ClearImage();

                            drawVertexesThread = new Thread(() => { DrawVertexes(GraphImage.Image, true); });
                            drawVertexesThread.Start();

                            fillTableThread = new Thread(() =>
                                {
                                    // Заполняем ячейки добавленных строк нулями.
                                    for (int i = 0; i < matrixSize; i++)
                                        for (int j = 0; j < matrixSize; j++)
                                            AdjacencyMatrix.Rows[i].Cells[j].Value = matrix[i][j].ToString();
                                    while (drawVertexesThread.IsAlive) { }
                                    DrawEdges(true);
                                    Invoke((MethodInvoker)delegate () { Cursor = Cursors.Arrow; });
                                });
                            fillTableThread.Start();
                            
                            IsLoadingFromFile = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (drawVertexesThread != null && drawVertexesThread.IsAlive) drawVertexesThread.Abort();
                        if (fillTableThread != null && fillTableThread.IsAlive) fillTableThread.Abort();
                        ClearImage();
                        AdjacencyMatrix.Rows.Clear();
                        AdjacencyMatrix.Columns.Clear();
                        MessageBox.Show("Невозможно считать данные матрицы смежности из файла!\nПричина: " +
                            ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        VertexCount.Text = 0.ToString();
                    }
                }
            }
        }

        private void SaveToFile_Click(object sender, EventArgs e)
        {
            Stream myStream;
            saveFileDialog.InitialDirectory = Application.StartupPath + "\\Графы";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = (GraphType.SelectedIndex == 0 ? "Нео" : "Ор") + "граф на " + AdjacencyMatrix.RowCount + " вершин.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    try
                    {
                        using (myStream) // Блок using гарантирует освобождение потока, связанный с чтением файла.
                        {
                            StreamWriter streamWriter = new StreamWriter(myStream);

                            streamWriter.WriteLine(AdjacencyMatrix.RowCount.ToString());
                            for (int i = 0; i < AdjacencyMatrix.RowCount; i++)
                            {
                                for (int j = 0; j < AdjacencyMatrix.ColumnCount; j++)
                                {
                                    streamWriter.Write(AdjacencyMatrix.Rows[i].Cells[j].Value.ToString());
                                    streamWriter.Write(j == AdjacencyMatrix.ColumnCount - 1 ? "" : " ");
                                }
                                streamWriter.WriteLine();
                            }
                            streamWriter.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при записи данных в файл!\nПричина: " +
                            ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void layoutPanel_SizeChanged(object sender, EventArgs e)
        {
            ClearImage();
            DrawVertexes(GraphImage.Image);
            DrawEdges();
            GraphImage.Refresh();
        }

        void TransformToUndirectedGraph()
        {
            for (int i = 0; i < AdjacencyMatrix.RowCount; i++)
                for (int j = i + 1; j < AdjacencyMatrix.ColumnCount; j++)
                    if (AdjacencyMatrix.Rows[i].Cells[j].Value.ToString() != AdjacencyMatrix.Rows[j].Cells[i].Value.ToString())
                        AdjacencyMatrix.Rows[i].Cells[j].Value = AdjacencyMatrix.Rows[j].Cells[i].Value = "1";
        }
        private void GraphType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoadingFromFile)
            {
                if (GraphType.SelectedIndex == 0)
                    TransformToUndirectedGraph();

                ClearImage();
                GraphHasColoring = false;
                DrawVertexes(GraphImage.Image);
                DrawEdges();
            }
        }

        private void VertexCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up && VertexCount.Text != "75")
                AddVertex_Click(sender, e);
            else if (e.KeyData == Keys.Down && VertexCount.Text != "0")
                RemoveVertex_Click(sender, e);
        }

        private void VertexCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && VertexCount.Text != "")
            {
                CreateGraph();
            }
            else if ((e.KeyChar < 46 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
            else if (e.KeyChar != 8 && Convert.ToInt16(VertexCount.Text + e.KeyChar) > 75)
                e.Handled = true;
            else
            {
                if (GetGraphСoloring.Enabled == true) GetGraphСoloring.Enabled = false;
                if (SaveToFile.Enabled == true) SaveToFile.Enabled = false;
            }
        }

        private void AddVertex_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(VertexCount.Text) + 1 <= 75)
            {
                VertexCount.Text = (Convert.ToInt16(VertexCount.Text) + 1).ToString();
                if (GetGraphСoloring.Enabled == false) GetGraphСoloring.Enabled = true;
                if (SaveToFile.Enabled == false) SaveToFile.Enabled = true;
                RefreshGraph(1);
            }
        }

        private void RemoveVertex_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(VertexCount.Text) - 1 >= 0)
            {
                VertexCount.Text = (Convert.ToInt16(VertexCount.Text) - 1).ToString();
                if (VertexCount.Text == "0")
                {
                    GetGraphСoloring.Enabled = false;
                    SaveToFile.Enabled = false;
                }
                RefreshGraph(-1);
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            CreateGraph();
            if (VertexCount.Text == "" || VertexCount.Text == "0")
            {
                GetGraphСoloring.Enabled = false;
                SaveToFile.Enabled = false;
            }
            else
            {
                GetGraphСoloring.Enabled = true;
                SaveToFile.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (drawVertexesThread != null && drawVertexesThread.IsAlive) drawVertexesThread.Abort();
            if (fillTableThread != null && fillTableThread.IsAlive) fillTableThread.Abort();
        }

        private void ChangeCursors(bool enabled)
        {
            MaximizeBox = enabled;
            MinimizeBox = enabled;
            VertexCount.Enabled = enabled;
            AddVertex.Enabled = enabled;
            RemoveVertex.Enabled = enabled;
            Create.Enabled = enabled;
            GraphType.Enabled = enabled;
            SaveToFile.Enabled = enabled;
            LoadFromFile.Enabled = enabled;
            GetGraphСoloring.Enabled = enabled;
        }
        private void Form1_CursorChanged(object sender, EventArgs e)
        {
            // При изменении курсора окна формы изменяем курсора
            // каждого элемента формы и изменяем доступность кнопок.

            if (Cursor == Cursors.WaitCursor)
            {
                ChangeCursors(false);
                AdjacencyMatrix.Cursor = Cursors.WaitCursor;
            }
            else { ChangeCursors(true); AdjacencyMatrix.Cursor = Cursors.Arrow; }
            
        }
    }
}
