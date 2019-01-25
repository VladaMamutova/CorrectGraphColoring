namespace Индивидуальное_задание_по_КДМ__Мамутова_В._
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GraphImage = new System.Windows.Forms.PictureBox();
            this.ColorGrid = new System.Windows.Forms.DataGridView();
            this.ColorNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExampleColor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GetGraphСoloring = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.ShowColors = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AdjacencyMatrix = new System.Windows.Forms.DataGridView();
            this.GraphCreationPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LoadFromFile = new System.Windows.Forms.Button();
            this.SaveToFile = new System.Windows.Forms.Button();
            this.Create = new System.Windows.Forms.Button();
            this.RemoveVertex = new System.Windows.Forms.Button();
            this.AddVertex = new System.Windows.Forms.Button();
            this.VertexCount = new System.Windows.Forms.TextBox();
            this.TVertexCount = new System.Windows.Forms.Label();
            this.TGraphType = new System.Windows.Forms.Label();
            this.GraphType = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.GraphImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorGrid)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.layoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdjacencyMatrix)).BeginInit();
            this.GraphCreationPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GraphImage
            // 
            this.GraphImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphImage.Location = new System.Drawing.Point(3, 3);
            this.GraphImage.Name = "GraphImage";
            this.layoutPanel.SetRowSpan(this.GraphImage, 2);
            this.GraphImage.Size = new System.Drawing.Size(477, 488);
            this.GraphImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GraphImage.TabIndex = 0;
            this.GraphImage.TabStop = false;
            // 
            // ColorGrid
            // 
            this.ColorGrid.AllowUserToAddRows = false;
            this.ColorGrid.AllowUserToDeleteRows = false;
            this.ColorGrid.AllowUserToResizeColumns = false;
            this.ColorGrid.AllowUserToResizeRows = false;
            this.ColorGrid.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.ColorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColorGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColorNumber,
            this.ExampleColor});
            this.ColorGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColorGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColorGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.ColorGrid.GridColor = System.Drawing.SystemColors.WindowFrame;
            this.ColorGrid.Location = new System.Drawing.Point(786, 0);
            this.ColorGrid.Name = "ColorGrid";
            this.ColorGrid.RowHeadersVisible = false;
            this.ColorGrid.Size = new System.Drawing.Size(106, 518);
            this.ColorGrid.TabIndex = 10;
            this.ColorGrid.Visible = false;
            this.ColorGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ColorGrid_CellContentClick);
            this.ColorGrid.MouseLeave += new System.EventHandler(this.ColorGrid_MouseLeave);
            // 
            // ColorNumber
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ColorNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColorNumber.HeaderText = "№";
            this.ColorNumber.Name = "ColorNumber";
            this.ColorNumber.ReadOnly = true;
            this.ColorNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColorNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColorNumber.Width = 35;
            // 
            // ExampleColor
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            this.ExampleColor.DefaultCellStyle = dataGridViewCellStyle5;
            this.ExampleColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExampleColor.HeaderText = "Цвет";
            this.ExampleColor.Name = "ExampleColor";
            this.ExampleColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExampleColor.Width = 50;
            // 
            // GetGraphСoloring
            // 
            this.GetGraphСoloring.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GetGraphСoloring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GetGraphСoloring.Enabled = false;
            this.GetGraphСoloring.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GetGraphСoloring.Location = new System.Drawing.Point(0, 102);
            this.GetGraphСoloring.Name = "GetGraphСoloring";
            this.GetGraphСoloring.Size = new System.Drawing.Size(360, 40);
            this.GetGraphСoloring.TabIndex = 5;
            this.GetGraphСoloring.Text = "Получить правильную раскраску";
            this.GetGraphСoloring.UseVisualStyleBackColor = true;
            this.GetGraphСoloring.Click += new System.EventHandler(this.GetGraphСoloring_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.LightSeaGreen;
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowColors});
            this.statusStrip.Location = new System.Drawing.Point(766, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(20, 518);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.MouseHover += new System.EventHandler(this.statusStrip_MouseHover);
            // 
            // ShowColors
            // 
            this.ShowColors.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ShowColors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ShowColors.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowColors.Name = "ShowColors";
            this.ShowColors.Size = new System.Drawing.Size(18, 488);
            this.ShowColors.Spring = true;
            this.ShowColors.Text = "Просмотр цветов";
            this.ShowColors.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // layoutPanel
            // 
            this.layoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutPanel.ColumnCount = 2;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.layoutPanel.Controls.Add(this.GraphImage, 0, 0);
            this.layoutPanel.Controls.Add(this.AdjacencyMatrix, 1, 1);
            this.layoutPanel.Controls.Add(this.GraphCreationPanel, 1, 0);
            this.layoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutPanel.Location = new System.Drawing.Point(12, 12);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 2;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.layoutPanel.Size = new System.Drawing.Size(849, 494);
            this.layoutPanel.TabIndex = 8;
            this.layoutPanel.SizeChanged += new System.EventHandler(this.layoutPanel_SizeChanged);
            // 
            // AdjacencyMatrix
            // 
            this.AdjacencyMatrix.AllowUserToAddRows = false;
            this.AdjacencyMatrix.AllowUserToDeleteRows = false;
            this.AdjacencyMatrix.AllowUserToResizeColumns = false;
            this.AdjacencyMatrix.AllowUserToResizeRows = false;
            this.AdjacencyMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.AdjacencyMatrix.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AdjacencyMatrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AdjacencyMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AdjacencyMatrix.DefaultCellStyle = dataGridViewCellStyle2;
            this.AdjacencyMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdjacencyMatrix.Location = new System.Drawing.Point(486, 151);
            this.AdjacencyMatrix.MultiSelect = false;
            this.AdjacencyMatrix.Name = "AdjacencyMatrix";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AdjacencyMatrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AdjacencyMatrix.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.AdjacencyMatrix.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.AdjacencyMatrix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.AdjacencyMatrix.ShowEditingIcon = false;
            this.AdjacencyMatrix.Size = new System.Drawing.Size(360, 340);
            this.AdjacencyMatrix.TabIndex = 1;
            this.AdjacencyMatrix.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.AdjacencyMatrix_EditingControlShowing);
            // 
            // GraphCreationPanel
            // 
            this.GraphCreationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphCreationPanel.Controls.Add(this.tableLayoutPanel1);
            this.GraphCreationPanel.Controls.Add(this.Create);
            this.GraphCreationPanel.Controls.Add(this.RemoveVertex);
            this.GraphCreationPanel.Controls.Add(this.AddVertex);
            this.GraphCreationPanel.Controls.Add(this.VertexCount);
            this.GraphCreationPanel.Controls.Add(this.TVertexCount);
            this.GraphCreationPanel.Controls.Add(this.TGraphType);
            this.GraphCreationPanel.Controls.Add(this.GraphType);
            this.GraphCreationPanel.Controls.Add(this.GetGraphСoloring);
            this.GraphCreationPanel.Location = new System.Drawing.Point(486, 3);
            this.GraphCreationPanel.Name = "GraphCreationPanel";
            this.GraphCreationPanel.Size = new System.Drawing.Size(360, 142);
            this.GraphCreationPanel.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LoadFromFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SaveToFile, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 38);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // LoadFromFile
            // 
            this.LoadFromFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadFromFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadFromFile.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadFromFile.Location = new System.Drawing.Point(0, 3);
            this.LoadFromFile.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.LoadFromFile.MaximumSize = new System.Drawing.Size(300, 32);
            this.LoadFromFile.Name = "LoadFromFile";
            this.LoadFromFile.Size = new System.Drawing.Size(177, 32);
            this.LoadFromFile.TabIndex = 10;
            this.LoadFromFile.Text = "Загрузить из файла";
            this.LoadFromFile.UseVisualStyleBackColor = true;
            this.LoadFromFile.Click += new System.EventHandler(this.LoadFromFile_Click);
            // 
            // SaveToFile
            // 
            this.SaveToFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveToFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveToFile.Enabled = false;
            this.SaveToFile.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveToFile.Location = new System.Drawing.Point(183, 3);
            this.SaveToFile.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.SaveToFile.MaximumSize = new System.Drawing.Size(300, 32);
            this.SaveToFile.Name = "SaveToFile";
            this.SaveToFile.Size = new System.Drawing.Size(177, 32);
            this.SaveToFile.TabIndex = 11;
            this.SaveToFile.Text = "Сохранить в файл";
            this.SaveToFile.UseVisualStyleBackColor = true;
            this.SaveToFile.Click += new System.EventHandler(this.SaveToFile_Click);
            // 
            // Create
            // 
            this.Create.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Create.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Create.Image = ((System.Drawing.Image)(resources.GetObject("Create.Image")));
            this.Create.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Create.Location = new System.Drawing.Point(249, 4);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(108, 27);
            this.Create.TabIndex = 15;
            this.Create.Text = "Создать";
            this.Create.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Create.UseVisualStyleBackColor = false;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // RemoveVertex
            // 
            this.RemoveVertex.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RemoveVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveVertex.Image = ((System.Drawing.Image)(resources.GetObject("RemoveVertex.Image")));
            this.RemoveVertex.Location = new System.Drawing.Point(218, 17);
            this.RemoveVertex.Name = "RemoveVertex";
            this.RemoveVertex.Size = new System.Drawing.Size(25, 14);
            this.RemoveVertex.TabIndex = 14;
            this.RemoveVertex.UseVisualStyleBackColor = true;
            this.RemoveVertex.Click += new System.EventHandler(this.RemoveVertex_Click);
            // 
            // AddVertex
            // 
            this.AddVertex.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AddVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddVertex.Image = ((System.Drawing.Image)(resources.GetObject("AddVertex.Image")));
            this.AddVertex.Location = new System.Drawing.Point(218, 4);
            this.AddVertex.Name = "AddVertex";
            this.AddVertex.Size = new System.Drawing.Size(25, 14);
            this.AddVertex.TabIndex = 13;
            this.AddVertex.UseVisualStyleBackColor = true;
            this.AddVertex.Click += new System.EventHandler(this.AddVertex_Click);
            // 
            // VertexCount
            // 
            this.VertexCount.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VertexCount.Location = new System.Drawing.Point(165, 5);
            this.VertexCount.Name = "VertexCount";
            this.VertexCount.Size = new System.Drawing.Size(45, 26);
            this.VertexCount.TabIndex = 12;
            this.VertexCount.Text = "0";
            this.VertexCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VertexCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VertexCount_KeyDown);
            this.VertexCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VertexCount_KeyPress);
            // 
            // TVertexCount
            // 
            this.TVertexCount.AutoSize = true;
            this.TVertexCount.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TVertexCount.Location = new System.Drawing.Point(3, 7);
            this.TVertexCount.Name = "TVertexCount";
            this.TVertexCount.Size = new System.Drawing.Size(152, 18);
            this.TVertexCount.TabIndex = 8;
            this.TVertexCount.Text = "Количество вершин";
            // 
            // TGraphType
            // 
            this.TGraphType.AutoSize = true;
            this.TGraphType.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TGraphType.Location = new System.Drawing.Point(3, 39);
            this.TGraphType.Name = "TGraphType";
            this.TGraphType.Size = new System.Drawing.Size(84, 18);
            this.TGraphType.TabIndex = 7;
            this.TGraphType.Text = "Вид графа";
            // 
            // GraphType
            // 
            this.GraphType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GraphType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GraphType.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GraphType.FormattingEnabled = true;
            this.GraphType.Items.AddRange(new object[] {
            "Неориентированный",
            "Ориентированный"});
            this.GraphType.Location = new System.Drawing.Point(93, 36);
            this.GraphType.Name = "GraphType";
            this.GraphType.Size = new System.Drawing.Size(267, 26);
            this.GraphType.TabIndex = 6;
            this.GraphType.SelectedIndexChanged += new System.EventHandler(this.GraphType_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(892, 518);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ColorGrid);
            this.Controls.Add(this.layoutPanel);
            this.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Правильная раскраска";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.CursorChanged += new System.EventHandler(this.Form1_CursorChanged);
            ((System.ComponentModel.ISupportInitialize)(this.GraphImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorGrid)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdjacencyMatrix)).EndInit();
            this.GraphCreationPanel.ResumeLayout(false);
            this.GraphCreationPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GraphImage;
        private System.Windows.Forms.DataGridView ColorGrid;
        private System.Windows.Forms.Button GetGraphСoloring;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ShowColors;
        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private System.Windows.Forms.DataGridView AdjacencyMatrix;
        private System.Windows.Forms.Panel GraphCreationPanel;
        private System.Windows.Forms.Label TVertexCount;
        private System.Windows.Forms.Label TGraphType;
        private System.Windows.Forms.ComboBox GraphType;
        private System.Windows.Forms.Button SaveToFile;
        private System.Windows.Forms.Button LoadFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox VertexCount;
        private System.Windows.Forms.Button RemoveVertex;
        private System.Windows.Forms.Button AddVertex;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorNumber;
        private System.Windows.Forms.DataGridViewButtonColumn ExampleColor;
    }
}

