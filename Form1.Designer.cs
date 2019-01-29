namespace SunyADKHelpDesk
{
    partial class HelpDesk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblIntro = new System.Windows.Forms.Label();
            this.rdBtnSubmit = new System.Windows.Forms.RadioButton();
            this.rdBtnUpdate = new System.Windows.Forms.RadioButton();
            this.rdBtnRetreive = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbBxTicType = new System.Windows.Forms.ComboBox();
            this.lblTicType = new System.Windows.Forms.Label();
            this.lblBldg = new System.Windows.Forms.Label();
            this.cmbBxBldg = new System.Windows.Forms.ComboBox();
            this.txtRoomNum = new System.Windows.Forms.TextBox();
            this.lblRoomNum = new System.Windows.Forms.Label();
            this.cmbBxRprTime = new System.Windows.Forms.ComboBox();
            this.lblRprTime = new System.Windows.Forms.Label();
            this.cmbBxUrgency = new System.Windows.Forms.ComboBox();
            this.lblUrgency = new System.Windows.Forms.Label();
            this.lblRprType = new System.Windows.Forms.Label();
            this.cmbBxOffcRpr = new System.Windows.Forms.ComboBox();
            this.cmbBxClssRmRpr = new System.Windows.Forms.ComboBox();
            this.cmbBxDrmRpr = new System.Windows.Forms.ComboBox();
            this.btnSbmt = new System.Windows.Forms.Button();
            this.grpBxSubmit = new System.Windows.Forms.GroupBox();
            this.lblEnterTckID = new System.Windows.Forms.Label();
            this.rdBtnTech = new System.Windows.Forms.RadioButton();
            this.rdBtnStatus = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSubBy = new System.Windows.Forms.Label();
            this.txtSubBy = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbBxStatus = new System.Windows.Forms.ComboBox();
            this.lblSelTech = new System.Windows.Forms.Label();
            this.cmbBxTech = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtEnterTickID = new System.Windows.Forms.TextBox();
            this.btnSbmtUpdts = new System.Windows.Forms.Button();
            this.dgDisplay = new System.Windows.Forms.DataGridView();
            this.cmbBxVwByUsers = new System.Windows.Forms.ComboBox();
            this.bellaDataSet = new SunyADKHelpDesk.bellaDataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new SunyADKHelpDesk.bellaDataSetTableAdapters.UsersTableAdapter();
            this.btnRtrvTicks = new System.Windows.Forms.Button();
            this.cmbBxVwByTech = new System.Windows.Forms.ComboBox();
            this.cmbBxVwBySts = new System.Windows.Forms.ComboBox();
            this.rdBtnVwByUser = new System.Windows.Forms.RadioButton();
            this.rdBtnVwByTech = new System.Windows.Forms.RadioButton();
            this.rdBtnVwBySts = new System.Windows.Forms.RadioButton();
            this.btnResetSelc = new System.Windows.Forms.Button();
            this.cmbBxChgSts = new System.Windows.Forms.ComboBox();
            this.cmbBxChgTech = new System.Windows.Forms.ComboBox();
            this.grpBxSubmit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bellaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Font = new System.Drawing.Font("Century", 24.75F);
            this.lblIntro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblIntro.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblIntro.Location = new System.Drawing.Point(175, 31);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(470, 39);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "SUNY Adirondack Help Desk";
            // 
            // rdBtnSubmit
            // 
            this.rdBtnSubmit.AutoSize = true;
            this.rdBtnSubmit.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnSubmit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdBtnSubmit.Location = new System.Drawing.Point(57, 109);
            this.rdBtnSubmit.Name = "rdBtnSubmit";
            this.rdBtnSubmit.Size = new System.Drawing.Size(160, 21);
            this.rdBtnSubmit.TabIndex = 0;
            this.rdBtnSubmit.Text = "Submit a new ticket";
            this.rdBtnSubmit.UseVisualStyleBackColor = true;
            this.rdBtnSubmit.Visible = false;
            this.rdBtnSubmit.CheckedChanged += new System.EventHandler(this.rdBtnSubmit_CheckedChanged);
            // 
            // rdBtnUpdate
            // 
            this.rdBtnUpdate.AutoSize = true;
            this.rdBtnUpdate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdBtnUpdate.Location = new System.Drawing.Point(309, 109);
            this.rdBtnUpdate.Name = "rdBtnUpdate";
            this.rdBtnUpdate.Size = new System.Drawing.Size(175, 21);
            this.rdBtnUpdate.TabIndex = 1;
            this.rdBtnUpdate.Text = "Update existing ticket";
            this.rdBtnUpdate.UseVisualStyleBackColor = true;
            this.rdBtnUpdate.Visible = false;
            this.rdBtnUpdate.CheckedChanged += new System.EventHandler(this.rdBtnUpdate_CheckedChanged);
            // 
            // rdBtnRetreive
            // 
            this.rdBtnRetreive.AutoSize = true;
            this.rdBtnRetreive.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnRetreive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdBtnRetreive.Location = new System.Drawing.Point(563, 109);
            this.rdBtnRetreive.Name = "rdBtnRetreive";
            this.rdBtnRetreive.Size = new System.Drawing.Size(207, 21);
            this.rdBtnRetreive.TabIndex = 2;
            this.rdBtnRetreive.Text = "Retreive submitted tickets";
            this.rdBtnRetreive.UseVisualStyleBackColor = true;
            this.rdBtnRetreive.Visible = false;
            this.rdBtnRetreive.CheckedChanged += new System.EventHandler(this.rdBtnRetreive_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(321, 538);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(186, 40);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbBxTicType
            // 
            this.cmbBxTicType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxTicType.FormattingEnabled = true;
            this.cmbBxTicType.Items.AddRange(new object[] {
            "Office",
            "Classroom",
            "Dorm"});
            this.cmbBxTicType.Location = new System.Drawing.Point(9, 38);
            this.cmbBxTicType.Name = "cmbBxTicType";
            this.cmbBxTicType.Size = new System.Drawing.Size(121, 27);
            this.cmbBxTicType.TabIndex = 3;
            this.cmbBxTicType.SelectedIndexChanged += new System.EventHandler(this.cmbBxTicType_SelectedIndexChanged);
            // 
            // lblTicType
            // 
            this.lblTicType.AutoSize = true;
            this.lblTicType.Location = new System.Drawing.Point(5, 15);
            this.lblTicType.Name = "lblTicType";
            this.lblTicType.Size = new System.Drawing.Size(126, 19);
            this.lblTicType.TabIndex = 1;
            this.lblTicType.Text = "Choose ticket type:";
            // 
            // lblBldg
            // 
            this.lblBldg.AutoSize = true;
            this.lblBldg.Location = new System.Drawing.Point(133, 15);
            this.lblBldg.Name = "lblBldg";
            this.lblBldg.Size = new System.Drawing.Size(99, 19);
            this.lblBldg.TabIndex = 2;
            this.lblBldg.Text = "Ticket location:";
            // 
            // cmbBxBldg
            // 
            this.cmbBxBldg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxBldg.FormattingEnabled = true;
            this.cmbBxBldg.Items.AddRange(new object[] {
            "Scoville",
            "Dearlove",
            "Warren Hall",
            "Dorms"});
            this.cmbBxBldg.Location = new System.Drawing.Point(136, 38);
            this.cmbBxBldg.Name = "cmbBxBldg";
            this.cmbBxBldg.Size = new System.Drawing.Size(114, 27);
            this.cmbBxBldg.TabIndex = 4;
            // 
            // txtRoomNum
            // 
            this.txtRoomNum.Location = new System.Drawing.Point(255, 38);
            this.txtRoomNum.Name = "txtRoomNum";
            this.txtRoomNum.Size = new System.Drawing.Size(70, 26);
            this.txtRoomNum.TabIndex = 5;
            // 
            // lblRoomNum
            // 
            this.lblRoomNum.AutoSize = true;
            this.lblRoomNum.Location = new System.Drawing.Point(251, 15);
            this.lblRoomNum.Name = "lblRoomNum";
            this.lblRoomNum.Size = new System.Drawing.Size(56, 19);
            this.lblRoomNum.TabIndex = 5;
            this.lblRoomNum.Text = "Room#:";
            // 
            // cmbBxRprTime
            // 
            this.cmbBxRprTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxRprTime.FormattingEnabled = true;
            this.cmbBxRprTime.Items.AddRange(new object[] {
            "9:00am-11:00am",
            "11:00am-1:00pm",
            "1:00pm-3:00pm",
            "3:00pm-5:00pm"});
            this.cmbBxRprTime.Location = new System.Drawing.Point(532, 36);
            this.cmbBxRprTime.Name = "cmbBxRprTime";
            this.cmbBxRprTime.Size = new System.Drawing.Size(131, 27);
            this.cmbBxRprTime.TabIndex = 8;
            // 
            // lblRprTime
            // 
            this.lblRprTime.AutoSize = true;
            this.lblRprTime.Location = new System.Drawing.Point(528, 15);
            this.lblRprTime.Name = "lblRprTime";
            this.lblRprTime.Size = new System.Drawing.Size(117, 19);
            this.lblRprTime.TabIndex = 7;
            this.lblRprTime.Text = "Select repair time:";
            // 
            // cmbBxUrgency
            // 
            this.cmbBxUrgency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxUrgency.FormattingEnabled = true;
            this.cmbBxUrgency.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.cmbBxUrgency.Location = new System.Drawing.Point(331, 37);
            this.cmbBxUrgency.Name = "cmbBxUrgency";
            this.cmbBxUrgency.Size = new System.Drawing.Size(95, 27);
            this.cmbBxUrgency.TabIndex = 6;
            // 
            // lblUrgency
            // 
            this.lblUrgency.AutoSize = true;
            this.lblUrgency.Location = new System.Drawing.Point(327, 15);
            this.lblUrgency.Name = "lblUrgency";
            this.lblUrgency.Size = new System.Drawing.Size(95, 19);
            this.lblUrgency.TabIndex = 9;
            this.lblUrgency.Text = "Select priority:";
            // 
            // lblRprType
            // 
            this.lblRprType.AutoSize = true;
            this.lblRprType.Location = new System.Drawing.Point(429, 15);
            this.lblRprType.Name = "lblRprType";
            this.lblRprType.Size = new System.Drawing.Size(81, 19);
            this.lblRprType.TabIndex = 10;
            this.lblRprType.Text = "Repair type:";
            // 
            // cmbBxOffcRpr
            // 
            this.cmbBxOffcRpr.FormattingEnabled = true;
            this.cmbBxOffcRpr.Items.AddRange(new object[] {
            "Computer",
            "Printer",
            "Other"});
            this.cmbBxOffcRpr.Location = new System.Drawing.Point(433, 36);
            this.cmbBxOffcRpr.Name = "cmbBxOffcRpr";
            this.cmbBxOffcRpr.Size = new System.Drawing.Size(89, 27);
            this.cmbBxOffcRpr.TabIndex = 11;
            // 
            // cmbBxClssRmRpr
            // 
            this.cmbBxClssRmRpr.FormattingEnabled = true;
            this.cmbBxClssRmRpr.Items.AddRange(new object[] {
            "Computer",
            "Monitor",
            "Network",
            "Printer",
            "Projector",
            "Other"});
            this.cmbBxClssRmRpr.Location = new System.Drawing.Point(434, 37);
            this.cmbBxClssRmRpr.Name = "cmbBxClssRmRpr";
            this.cmbBxClssRmRpr.Size = new System.Drawing.Size(89, 27);
            this.cmbBxClssRmRpr.TabIndex = 12;
            // 
            // cmbBxDrmRpr
            // 
            this.cmbBxDrmRpr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxDrmRpr.FormattingEnabled = true;
            this.cmbBxDrmRpr.Items.AddRange(new object[] {
            "Windows",
            "Mac",
            "Linux"});
            this.cmbBxDrmRpr.Location = new System.Drawing.Point(433, 37);
            this.cmbBxDrmRpr.Name = "cmbBxDrmRpr";
            this.cmbBxDrmRpr.Size = new System.Drawing.Size(89, 27);
            this.cmbBxDrmRpr.TabIndex = 7;
            // 
            // btnSbmt
            // 
            this.btnSbmt.Location = new System.Drawing.Point(635, 84);
            this.btnSbmt.Name = "btnSbmt";
            this.btnSbmt.Size = new System.Drawing.Size(131, 34);
            this.btnSbmt.TabIndex = 13;
            this.btnSbmt.Text = "Submit Ticket";
            this.btnSbmt.UseVisualStyleBackColor = true;
            this.btnSbmt.Click += new System.EventHandler(this.btnSbmt_Click);
            // 
            // grpBxSubmit
            // 
            this.grpBxSubmit.Controls.Add(this.lblEnterTckID);
            this.grpBxSubmit.Controls.Add(this.rdBtnTech);
            this.grpBxSubmit.Controls.Add(this.rdBtnStatus);
            this.grpBxSubmit.Controls.Add(this.btnReset);
            this.grpBxSubmit.Controls.Add(this.lblDate);
            this.grpBxSubmit.Controls.Add(this.lblSubBy);
            this.grpBxSubmit.Controls.Add(this.txtSubBy);
            this.grpBxSubmit.Controls.Add(this.lblStatus);
            this.grpBxSubmit.Controls.Add(this.cmbBxStatus);
            this.grpBxSubmit.Controls.Add(this.lblSelTech);
            this.grpBxSubmit.Controls.Add(this.cmbBxTech);
            this.grpBxSubmit.Controls.Add(this.dtpDate);
            this.grpBxSubmit.Controls.Add(this.btnSbmt);
            this.grpBxSubmit.Controls.Add(this.cmbBxDrmRpr);
            this.grpBxSubmit.Controls.Add(this.cmbBxClssRmRpr);
            this.grpBxSubmit.Controls.Add(this.cmbBxOffcRpr);
            this.grpBxSubmit.Controls.Add(this.lblRprType);
            this.grpBxSubmit.Controls.Add(this.lblUrgency);
            this.grpBxSubmit.Controls.Add(this.cmbBxUrgency);
            this.grpBxSubmit.Controls.Add(this.lblRprTime);
            this.grpBxSubmit.Controls.Add(this.cmbBxRprTime);
            this.grpBxSubmit.Controls.Add(this.lblRoomNum);
            this.grpBxSubmit.Controls.Add(this.txtRoomNum);
            this.grpBxSubmit.Controls.Add(this.cmbBxBldg);
            this.grpBxSubmit.Controls.Add(this.lblBldg);
            this.grpBxSubmit.Controls.Add(this.lblTicType);
            this.grpBxSubmit.Controls.Add(this.cmbBxTicType);
            this.grpBxSubmit.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.grpBxSubmit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.grpBxSubmit.Location = new System.Drawing.Point(19, 134);
            this.grpBxSubmit.Name = "grpBxSubmit";
            this.grpBxSubmit.Size = new System.Drawing.Size(786, 163);
            this.grpBxSubmit.TabIndex = 8;
            this.grpBxSubmit.TabStop = false;
            // 
            // lblEnterTckID
            // 
            this.lblEnterTckID.AutoSize = true;
            this.lblEnterTckID.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.lblEnterTckID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblEnterTckID.Location = new System.Drawing.Point(308, 133);
            this.lblEnterTckID.Name = "lblEnterTckID";
            this.lblEnterTckID.Size = new System.Drawing.Size(125, 19);
            this.lblEnterTckID.TabIndex = 19;
            this.lblEnterTckID.Text = "TicketID to update:";
            this.lblEnterTckID.Visible = false;
            // 
            // rdBtnTech
            // 
            this.rdBtnTech.AutoSize = true;
            this.rdBtnTech.Location = new System.Drawing.Point(154, 131);
            this.rdBtnTech.Name = "rdBtnTech";
            this.rdBtnTech.Size = new System.Drawing.Size(141, 23);
            this.rdBtnTech.TabIndex = 17;
            this.rdBtnTech.TabStop = true;
            this.rdBtnTech.Text = "Change Technician";
            this.rdBtnTech.UseVisualStyleBackColor = true;
            this.rdBtnTech.CheckedChanged += new System.EventHandler(this.rdBtnTech_CheckedChanged);
            // 
            // rdBtnStatus
            // 
            this.rdBtnStatus.AutoSize = true;
            this.rdBtnStatus.Location = new System.Drawing.Point(16, 131);
            this.rdBtnStatus.Name = "rdBtnStatus";
            this.rdBtnStatus.Size = new System.Drawing.Size(116, 23);
            this.rdBtnStatus.TabIndex = 15;
            this.rdBtnStatus.TabStop = true;
            this.rdBtnStatus.Text = "Change Status";
            this.rdBtnStatus.UseVisualStyleBackColor = true;
            this.rdBtnStatus.CheckedChanged += new System.EventHandler(this.rdBtnStatus_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(488, 84);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(131, 34);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset Controls";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(155, 69);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(104, 19);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "Date submitted";
            // 
            // lblSubBy
            // 
            this.lblSubBy.AutoSize = true;
            this.lblSubBy.Location = new System.Drawing.Point(311, 70);
            this.lblSubBy.Name = "lblSubBy";
            this.lblSubBy.Size = new System.Drawing.Size(94, 19);
            this.lblSubBy.TabIndex = 21;
            this.lblSubBy.Text = "Submitted by:";
            // 
            // txtSubBy
            // 
            this.txtSubBy.Location = new System.Drawing.Point(312, 89);
            this.txtSubBy.Name = "txtSubBy";
            this.txtSubBy.Size = new System.Drawing.Size(156, 26);
            this.txtSubBy.TabIndex = 12;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(669, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 19);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status:";
            // 
            // cmbBxStatus
            // 
            this.cmbBxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxStatus.FormattingEnabled = true;
            this.cmbBxStatus.Items.AddRange(new object[] {
            "Closed",
            "Open",
            "In-Progress"});
            this.cmbBxStatus.Location = new System.Drawing.Point(669, 36);
            this.cmbBxStatus.Name = "cmbBxStatus";
            this.cmbBxStatus.Size = new System.Drawing.Size(90, 27);
            this.cmbBxStatus.TabIndex = 9;
            // 
            // lblSelTech
            // 
            this.lblSelTech.AutoSize = true;
            this.lblSelTech.Location = new System.Drawing.Point(6, 68);
            this.lblSelTech.Name = "lblSelTech";
            this.lblSelTech.Size = new System.Drawing.Size(114, 19);
            this.lblSelTech.TabIndex = 17;
            this.lblSelTech.Text = "Select Technician:";
            // 
            // cmbBxTech
            // 
            this.cmbBxTech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxTech.FormattingEnabled = true;
            this.cmbBxTech.Items.AddRange(new object[] {
            "Matt Fernicola",
            "Justin Thyme",
            "Ike Cannelpu",
            "Matt Hull",
            "Unassigned"});
            this.cmbBxTech.Location = new System.Drawing.Point(9, 89);
            this.cmbBxTech.Name = "cmbBxTech";
            this.cmbBxTech.Size = new System.Drawing.Size(143, 27);
            this.cmbBxTech.TabIndex = 10;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(158, 89);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(148, 26);
            this.dtpDate.TabIndex = 11;
            this.dtpDate.Value = new System.DateTime(2018, 4, 16, 21, 4, 7, 0);
            // 
            // txtEnterTickID
            // 
            this.txtEnterTickID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterTickID.Location = new System.Drawing.Point(331, 291);
            this.txtEnterTickID.Name = "txtEnterTickID";
            this.txtEnterTickID.Size = new System.Drawing.Size(121, 22);
            this.txtEnterTickID.TabIndex = 20;
            this.txtEnterTickID.Visible = false;
            // 
            // btnSbmtUpdts
            // 
            this.btnSbmtUpdts.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.btnSbmtUpdts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSbmtUpdts.Location = new System.Drawing.Point(654, 281);
            this.btnSbmtUpdts.Name = "btnSbmtUpdts";
            this.btnSbmtUpdts.Size = new System.Drawing.Size(132, 32);
            this.btnSbmtUpdts.TabIndex = 21;
            this.btnSbmtUpdts.Text = "Submit Changes";
            this.btnSbmtUpdts.UseVisualStyleBackColor = true;
            this.btnSbmtUpdts.Click += new System.EventHandler(this.btnSbmtUpdts_Click);
            // 
            // dgDisplay
            // 
            this.dgDisplay.AllowUserToAddRows = false;
            this.dgDisplay.AllowUserToDeleteRows = false;
            this.dgDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDisplay.Location = new System.Drawing.Point(19, 385);
            this.dgDisplay.Name = "dgDisplay";
            this.dgDisplay.ReadOnly = true;
            this.dgDisplay.Size = new System.Drawing.Size(786, 147);
            this.dgDisplay.TabIndex = 10;
            // 
            // cmbBxVwByUsers
            // 
            this.cmbBxVwByUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxVwByUsers.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBxVwByUsers.FormattingEnabled = true;
            this.cmbBxVwByUsers.Location = new System.Drawing.Point(32, 347);
            this.cmbBxVwByUsers.Name = "cmbBxVwByUsers";
            this.cmbBxVwByUsers.Size = new System.Drawing.Size(149, 21);
            this.cmbBxVwByUsers.TabIndex = 23;
            // 
            // bellaDataSet
            // 
            this.bellaDataSet.DataSetName = "bellaDataSet";
            this.bellaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.bellaDataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // btnRtrvTicks
            // 
            this.btnRtrvTicks.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.btnRtrvTicks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRtrvTicks.Location = new System.Drawing.Point(550, 335);
            this.btnRtrvTicks.Name = "btnRtrvTicks";
            this.btnRtrvTicks.Size = new System.Drawing.Size(114, 31);
            this.btnRtrvTicks.TabIndex = 28;
            this.btnRtrvTicks.Text = "View Tickets";
            this.btnRtrvTicks.UseVisualStyleBackColor = true;
            this.btnRtrvTicks.Click += new System.EventHandler(this.btnRtrvTicks_Click);
            // 
            // cmbBxVwByTech
            // 
            this.cmbBxVwByTech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxVwByTech.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBxVwByTech.FormattingEnabled = true;
            this.cmbBxVwByTech.Items.AddRange(new object[] {
            "Matt Fernicola",
            "Justin Thyme",
            "Ike Cannelpu",
            "Matt Hull"});
            this.cmbBxVwByTech.Location = new System.Drawing.Point(201, 346);
            this.cmbBxVwByTech.Name = "cmbBxVwByTech";
            this.cmbBxVwByTech.Size = new System.Drawing.Size(163, 21);
            this.cmbBxVwByTech.TabIndex = 25;
            // 
            // cmbBxVwBySts
            // 
            this.cmbBxVwBySts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxVwBySts.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBxVwBySts.FormattingEnabled = true;
            this.cmbBxVwBySts.Items.AddRange(new object[] {
            "Closed",
            "Open",
            "In-Progress"});
            this.cmbBxVwBySts.Location = new System.Drawing.Point(384, 345);
            this.cmbBxVwBySts.Name = "cmbBxVwBySts";
            this.cmbBxVwBySts.Size = new System.Drawing.Size(147, 21);
            this.cmbBxVwBySts.TabIndex = 27;
            // 
            // rdBtnVwByUser
            // 
            this.rdBtnVwByUser.AutoSize = true;
            this.rdBtnVwByUser.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.rdBtnVwByUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdBtnVwByUser.Location = new System.Drawing.Point(31, 324);
            this.rdBtnVwByUser.Name = "rdBtnVwByUser";
            this.rdBtnVwByUser.Size = new System.Drawing.Size(141, 23);
            this.rdBtnVwByUser.TabIndex = 22;
            this.rdBtnVwByUser.Text = "View user\'s tickets:";
            this.rdBtnVwByUser.UseVisualStyleBackColor = true;
            this.rdBtnVwByUser.CheckedChanged += new System.EventHandler(this.rdBtnVwByUser_CheckedChanged);
            // 
            // rdBtnVwByTech
            // 
            this.rdBtnVwByTech.AutoSize = true;
            this.rdBtnVwByTech.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.rdBtnVwByTech.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdBtnVwByTech.Location = new System.Drawing.Point(201, 322);
            this.rdBtnVwByTech.Name = "rdBtnVwByTech";
            this.rdBtnVwByTech.Size = new System.Drawing.Size(151, 23);
            this.rdBtnVwByTech.TabIndex = 24;
            this.rdBtnVwByTech.Text = "View tickets by tech:";
            this.rdBtnVwByTech.UseVisualStyleBackColor = true;
            this.rdBtnVwByTech.CheckedChanged += new System.EventHandler(this.rdBtnVwByTech_CheckedChanged);
            // 
            // rdBtnVwBySts
            // 
            this.rdBtnVwBySts.AutoSize = true;
            this.rdBtnVwBySts.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.rdBtnVwBySts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdBtnVwBySts.Location = new System.Drawing.Point(384, 320);
            this.rdBtnVwBySts.Name = "rdBtnVwBySts";
            this.rdBtnVwBySts.Size = new System.Drawing.Size(162, 23);
            this.rdBtnVwBySts.TabIndex = 26;
            this.rdBtnVwBySts.Text = "View tickets by status:";
            this.rdBtnVwBySts.UseVisualStyleBackColor = true;
            this.rdBtnVwBySts.CheckedChanged += new System.EventHandler(this.rdBtnVwBySts_CheckedChanged);
            // 
            // btnResetSelc
            // 
            this.btnResetSelc.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.btnResetSelc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnResetSelc.Location = new System.Drawing.Point(670, 335);
            this.btnResetSelc.Name = "btnResetSelc";
            this.btnResetSelc.Size = new System.Drawing.Size(115, 31);
            this.btnResetSelc.TabIndex = 29;
            this.btnResetSelc.Text = "Reset Selection";
            this.btnResetSelc.UseVisualStyleBackColor = true;
            this.btnResetSelc.Click += new System.EventHandler(this.btnResetSelc_Click);
            // 
            // cmbBxChgSts
            // 
            this.cmbBxChgSts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxChgSts.FormattingEnabled = true;
            this.cmbBxChgSts.ItemHeight = 13;
            this.cmbBxChgSts.Items.AddRange(new object[] {
            "Closed",
            "Open",
            "In-Progress"});
            this.cmbBxChgSts.Location = new System.Drawing.Point(30, 292);
            this.cmbBxChgSts.Name = "cmbBxChgSts";
            this.cmbBxChgSts.Size = new System.Drawing.Size(121, 21);
            this.cmbBxChgSts.TabIndex = 16;
            // 
            // cmbBxChgTech
            // 
            this.cmbBxChgTech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxChgTech.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBxChgTech.FormattingEnabled = true;
            this.cmbBxChgTech.Items.AddRange(new object[] {
            "Matt Fernicola",
            "Justin Thyme",
            "Ike Cannelpu",
            "Matt Hull"});
            this.cmbBxChgTech.Location = new System.Drawing.Point(177, 292);
            this.cmbBxChgTech.Name = "cmbBxChgTech";
            this.cmbBxChgTech.Size = new System.Drawing.Size(137, 21);
            this.cmbBxChgTech.TabIndex = 18;
            // 
            // HelpDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(826, 582);
            this.Controls.Add(this.cmbBxChgTech);
            this.Controls.Add(this.txtEnterTickID);
            this.Controls.Add(this.cmbBxChgSts);
            this.Controls.Add(this.btnResetSelc);
            this.Controls.Add(this.rdBtnVwBySts);
            this.Controls.Add(this.btnSbmtUpdts);
            this.Controls.Add(this.rdBtnVwByTech);
            this.Controls.Add(this.rdBtnVwByUser);
            this.Controls.Add(this.cmbBxVwBySts);
            this.Controls.Add(this.cmbBxVwByTech);
            this.Controls.Add(this.btnRtrvTicks);
            this.Controls.Add(this.cmbBxVwByUsers);
            this.Controls.Add(this.dgDisplay);
            this.Controls.Add(this.grpBxSubmit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rdBtnRetreive);
            this.Controls.Add(this.rdBtnUpdate);
            this.Controls.Add(this.rdBtnSubmit);
            this.Controls.Add(this.lblIntro);
            this.Name = "HelpDesk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help Desk";
            this.Load += new System.EventHandler(this.HelpDesk_Load);
            this.grpBxSubmit.ResumeLayout(false);
            this.grpBxSubmit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bellaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.RadioButton rdBtnSubmit;
        private System.Windows.Forms.RadioButton rdBtnUpdate;
        private System.Windows.Forms.RadioButton rdBtnRetreive;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbBxTicType;
        private System.Windows.Forms.Label lblTicType;
        private System.Windows.Forms.Label lblBldg;
        private System.Windows.Forms.ComboBox cmbBxBldg;
        private System.Windows.Forms.TextBox txtRoomNum;
        private System.Windows.Forms.Label lblRoomNum;
        private System.Windows.Forms.ComboBox cmbBxRprTime;
        private System.Windows.Forms.Label lblRprTime;
        private System.Windows.Forms.ComboBox cmbBxUrgency;
        private System.Windows.Forms.Label lblUrgency;
        private System.Windows.Forms.Label lblRprType;
        private System.Windows.Forms.ComboBox cmbBxOffcRpr;
        private System.Windows.Forms.ComboBox cmbBxClssRmRpr;
        private System.Windows.Forms.ComboBox cmbBxDrmRpr;
        private System.Windows.Forms.Button btnSbmt;
        private System.Windows.Forms.GroupBox grpBxSubmit;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DataGridView dgDisplay;
        private System.Windows.Forms.Label lblSelTech;
        private System.Windows.Forms.ComboBox cmbBxTech;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSubBy;
        private System.Windows.Forms.TextBox txtSubBy;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbBxStatus;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSbmtUpdts;
        private System.Windows.Forms.RadioButton rdBtnTech;
        private System.Windows.Forms.RadioButton rdBtnStatus;
        private System.Windows.Forms.Label lblEnterTckID;
        private System.Windows.Forms.TextBox txtEnterTickID;
        private System.Windows.Forms.ComboBox cmbBxVwByUsers;
        private bellaDataSet bellaDataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private bellaDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.Button btnRtrvTicks;
        private System.Windows.Forms.ComboBox cmbBxVwByTech;
        private System.Windows.Forms.ComboBox cmbBxVwBySts;
        private System.Windows.Forms.RadioButton rdBtnVwByUser;
        private System.Windows.Forms.RadioButton rdBtnVwByTech;
        private System.Windows.Forms.RadioButton rdBtnVwBySts;
        private System.Windows.Forms.Button btnResetSelc;
        private System.Windows.Forms.ComboBox cmbBxChgSts;
        private System.Windows.Forms.ComboBox cmbBxChgTech;
    }
}

