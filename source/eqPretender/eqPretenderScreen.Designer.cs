
namespace eqPretender
{
    partial class eqPretenderScreen
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eqPretenderScreen));
            this.comboBox_serial_comname = new System.Windows.Forms.ComboBox();
            this.button_run = new System.Windows.Forms.Button();
            this.serialPortMount = new System.IO.Ports.SerialPort(this.components);
            this.serialPortApp = new System.IO.Ports.SerialPort(this.components);
            this.radio_network = new System.Windows.Forms.RadioButton();
            this.radio_serial = new System.Windows.Forms.RadioButton();
            this.comboBox_network_ip = new System.Windows.Forms.ComboBox();
            this.label_running_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_serial_comname
            // 
            this.comboBox_serial_comname.BackColor = System.Drawing.Color.Black;
            this.comboBox_serial_comname.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox_serial_comname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.comboBox_serial_comname.FormattingEnabled = true;
            this.comboBox_serial_comname.Location = new System.Drawing.Point(114, 44);
            this.comboBox_serial_comname.Name = "comboBox_serial_comname";
            this.comboBox_serial_comname.Size = new System.Drawing.Size(156, 29);
            this.comboBox_serial_comname.TabIndex = 0;
            this.comboBox_serial_comname.Visible = false;
            // 
            // button_run
            // 
            this.button_run.BackColor = System.Drawing.Color.DarkGray;
            this.button_run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_run.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_run.ForeColor = System.Drawing.Color.Red;
            this.button_run.Location = new System.Drawing.Point(12, 79);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(170, 29);
            this.button_run.TabIndex = 3;
            this.button_run.Text = "Run";
            this.button_run.UseVisualStyleBackColor = false;
            this.button_run.Click += new System.EventHandler(this.runButton_Click);
            // 
            // radio_network
            // 
            this.radio_network.AutoSize = true;
            this.radio_network.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radio_network.ForeColor = System.Drawing.Color.Red;
            this.radio_network.Location = new System.Drawing.Point(12, 12);
            this.radio_network.Name = "radio_network";
            this.radio_network.Size = new System.Drawing.Size(101, 25);
            this.radio_network.TabIndex = 18;
            this.radio_network.TabStop = true;
            this.radio_network.Text = "Network";
            this.radio_network.UseVisualStyleBackColor = true;
            this.radio_network.Click += new System.EventHandler(this.radios_Click);
            // 
            // radio_serial
            // 
            this.radio_serial.AutoSize = true;
            this.radio_serial.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radio_serial.ForeColor = System.Drawing.Color.Red;
            this.radio_serial.Location = new System.Drawing.Point(12, 43);
            this.radio_serial.Name = "radio_serial";
            this.radio_serial.Size = new System.Drawing.Size(77, 25);
            this.radio_serial.TabIndex = 18;
            this.radio_serial.TabStop = true;
            this.radio_serial.Text = "Serial";
            this.radio_serial.UseVisualStyleBackColor = true;
            this.radio_serial.Click += new System.EventHandler(this.radios_Click);
            // 
            // comboBox_network_ip
            // 
            this.comboBox_network_ip.BackColor = System.Drawing.Color.Black;
            this.comboBox_network_ip.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox_network_ip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.comboBox_network_ip.FormattingEnabled = true;
            this.comboBox_network_ip.Location = new System.Drawing.Point(114, 11);
            this.comboBox_network_ip.Name = "comboBox_network_ip";
            this.comboBox_network_ip.Size = new System.Drawing.Size(156, 29);
            this.comboBox_network_ip.TabIndex = 0;
            this.comboBox_network_ip.Text = "192.168.4.1";
            this.comboBox_network_ip.Visible = false;
            // 
            // label_running_status
            // 
            this.label_running_status.AutoSize = true;
            this.label_running_status.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_running_status.ForeColor = System.Drawing.Color.Red;
            this.label_running_status.Location = new System.Drawing.Point(188, 83);
            this.label_running_status.Name = "label_running_status";
            this.label_running_status.Size = new System.Drawing.Size(82, 21);
            this.label_running_status.TabIndex = 19;
            this.label_running_status.Text = "Stopped";
            this.label_running_status.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // eqPretenderScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(279, 116);
            this.Controls.Add(this.label_running_status);
            this.Controls.Add(this.comboBox_network_ip);
            this.Controls.Add(this.comboBox_serial_comname);
            this.Controls.Add(this.radio_serial);
            this.Controls.Add(this.radio_network);
            this.Controls.Add(this.button_run);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(295, 155);
            this.MinimumSize = new System.Drawing.Size(295, 155);
            this.Name = "eqPretenderScreen";
            this.Text = "EQ Pretender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox_serial_comname;
        private System.Windows.Forms.Button button_run;
        private System.IO.Ports.SerialPort serialPortMount;
        private System.IO.Ports.SerialPort serialPortApp;
        private System.Windows.Forms.RadioButton radio_network;
        private System.Windows.Forms.RadioButton radio_serial;
        private System.Windows.Forms.ComboBox comboBox_network_ip;
        private System.Windows.Forms.Label label_running_status;
    }
}

