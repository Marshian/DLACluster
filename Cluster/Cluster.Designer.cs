namespace Cluster
{
  partial class Cluster
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
      this.display_panel = new System.Windows.Forms.PictureBox();
      this.button_go = new System.Windows.Forms.Button();
      this.button_stop = new System.Windows.Forms.Button();
      this.button_pause = new System.Windows.Forms.Button();
      this.clock = new System.Windows.Forms.Timer(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.label_state = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.box_left_probability = new System.Windows.Forms.TextBox();
      this.box_up_probability = new System.Windows.Forms.TextBox();
      this.box_right_probability = new System.Windows.Forms.TextBox();
      this.box_down_probability = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.box_num_walkers = new System.Windows.Forms.TextBox();
      this.check_walkers = new System.Windows.Forms.CheckBox();
      this.combo_mode = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.box_x_line = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.box_y_line = new System.Windows.Forms.TextBox();
      this.box_deposit_rate = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.button_save = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.display_panel)).BeginInit();
      this.SuspendLayout();
      // 
      // display_panel
      // 
      this.display_panel.BackColor = System.Drawing.Color.LightGray;
      this.display_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.display_panel.Location = new System.Drawing.Point(12, 12);
      this.display_panel.Name = "display_panel";
      this.display_panel.Size = new System.Drawing.Size(800, 450);
      this.display_panel.TabIndex = 0;
      this.display_panel.TabStop = false;
      // 
      // button_go
      // 
      this.button_go.Location = new System.Drawing.Point(950, 372);
      this.button_go.Name = "button_go";
      this.button_go.Size = new System.Drawing.Size(93, 26);
      this.button_go.TabIndex = 1;
      this.button_go.Text = "Run";
      this.button_go.UseVisualStyleBackColor = true;
      this.button_go.Click += new System.EventHandler(this.button_go_Click);
      // 
      // button_stop
      // 
      this.button_stop.Location = new System.Drawing.Point(950, 436);
      this.button_stop.Name = "button_stop";
      this.button_stop.Size = new System.Drawing.Size(93, 26);
      this.button_stop.TabIndex = 2;
      this.button_stop.Text = "Stop";
      this.button_stop.UseVisualStyleBackColor = true;
      this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
      // 
      // button_pause
      // 
      this.button_pause.Location = new System.Drawing.Point(950, 404);
      this.button_pause.Name = "button_pause";
      this.button_pause.Size = new System.Drawing.Size(93, 26);
      this.button_pause.TabIndex = 3;
      this.button_pause.Text = "Pause";
      this.button_pause.UseVisualStyleBackColor = true;
      this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
      // 
      // clock
      // 
      this.clock.Interval = 1;
      this.clock.Tick += new System.EventHandler(this.clock_Tick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(818, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(92, 17);
      this.label1.TabIndex = 4;
      this.label1.Text = "Current State";
      // 
      // label_state
      // 
      this.label_state.AutoSize = true;
      this.label_state.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label_state.Location = new System.Drawing.Point(963, 15);
      this.label_state.MinimumSize = new System.Drawing.Size(80, 19);
      this.label_state.Name = "label_state";
      this.label_state.Size = new System.Drawing.Size(80, 19);
      this.label_state.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(818, 50);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(102, 17);
      this.label2.TabIndex = 6;
      this.label2.Text = "Left Probability";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(818, 78);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(111, 17);
      this.label3.TabIndex = 7;
      this.label3.Text = "Right Probability";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(818, 114);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(96, 17);
      this.label4.TabIndex = 8;
      this.label4.Text = "Up Probability";
      // 
      // box_left_probability
      // 
      this.box_left_probability.Location = new System.Drawing.Point(963, 47);
      this.box_left_probability.Name = "box_left_probability";
      this.box_left_probability.Size = new System.Drawing.Size(80, 22);
      this.box_left_probability.TabIndex = 9;
      this.box_left_probability.Text = "0.333";
      // 
      // box_up_probability
      // 
      this.box_up_probability.Location = new System.Drawing.Point(963, 111);
      this.box_up_probability.Name = "box_up_probability";
      this.box_up_probability.Size = new System.Drawing.Size(80, 22);
      this.box_up_probability.TabIndex = 10;
      this.box_up_probability.Text = "0.333";
      // 
      // box_right_probability
      // 
      this.box_right_probability.Location = new System.Drawing.Point(963, 75);
      this.box_right_probability.Name = "box_right_probability";
      this.box_right_probability.Size = new System.Drawing.Size(80, 22);
      this.box_right_probability.TabIndex = 11;
      this.box_right_probability.Text = "0.333";
      // 
      // box_down_probability
      // 
      this.box_down_probability.Location = new System.Drawing.Point(963, 139);
      this.box_down_probability.Name = "box_down_probability";
      this.box_down_probability.Size = new System.Drawing.Size(80, 22);
      this.box_down_probability.TabIndex = 11;
      this.box_down_probability.Text = "0.333";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(818, 142);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(113, 17);
      this.label5.TabIndex = 12;
      this.label5.Text = "Down Probability";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(818, 187);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(129, 17);
      this.label6.TabIndex = 13;
      this.label6.Text = "Number of Walkers";
      // 
      // box_num_walkers
      // 
      this.box_num_walkers.Location = new System.Drawing.Point(963, 181);
      this.box_num_walkers.Name = "box_num_walkers";
      this.box_num_walkers.Size = new System.Drawing.Size(80, 22);
      this.box_num_walkers.TabIndex = 14;
      this.box_num_walkers.Text = "1000";
      // 
      // check_walkers
      // 
      this.check_walkers.AutoSize = true;
      this.check_walkers.Checked = true;
      this.check_walkers.CheckState = System.Windows.Forms.CheckState.Checked;
      this.check_walkers.Location = new System.Drawing.Point(821, 440);
      this.check_walkers.Name = "check_walkers";
      this.check_walkers.Size = new System.Drawing.Size(117, 21);
      this.check_walkers.TabIndex = 15;
      this.check_walkers.Text = "Draw Walkers";
      this.check_walkers.UseVisualStyleBackColor = true;
      this.check_walkers.CheckedChanged += new System.EventHandler(this.check_walkers_CheckedChanged);
      // 
      // combo_mode
      // 
      this.combo_mode.FormattingEnabled = true;
      this.combo_mode.Location = new System.Drawing.Point(871, 342);
      this.combo_mode.Name = "combo_mode";
      this.combo_mode.Size = new System.Drawing.Size(172, 24);
      this.combo_mode.TabIndex = 16;
      this.combo_mode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(818, 345);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(47, 17);
      this.label7.TabIndex = 17;
      this.label7.Text = "Mode:";
      // 
      // box_x_line
      // 
      this.box_x_line.Location = new System.Drawing.Point(963, 211);
      this.box_x_line.Name = "box_x_line";
      this.box_x_line.Size = new System.Drawing.Size(80, 22);
      this.box_x_line.TabIndex = 18;
      this.box_x_line.Text = "400";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(818, 214);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(48, 17);
      this.label8.TabIndex = 19;
      this.label8.Text = "X Line";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(821, 246);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(48, 17);
      this.label9.TabIndex = 20;
      this.label9.Text = "Y Line";
      // 
      // box_y_line
      // 
      this.box_y_line.Location = new System.Drawing.Point(963, 246);
      this.box_y_line.Name = "box_y_line";
      this.box_y_line.Size = new System.Drawing.Size(79, 22);
      this.box_y_line.TabIndex = 21;
      this.box_y_line.Text = "650";
      // 
      // box_deposit_rate
      // 
      this.box_deposit_rate.Location = new System.Drawing.Point(963, 275);
      this.box_deposit_rate.Name = "box_deposit_rate";
      this.box_deposit_rate.Size = new System.Drawing.Size(80, 22);
      this.box_deposit_rate.TabIndex = 22;
      this.box_deposit_rate.Text = "10";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(824, 279);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(90, 17);
      this.label10.TabIndex = 23;
      this.label10.Text = "Deposit Rate";
      // 
      // button_save
      // 
      this.button_save.Location = new System.Drawing.Point(827, 372);
      this.button_save.Name = "button_save";
      this.button_save.Size = new System.Drawing.Size(93, 26);
      this.button_save.TabIndex = 24;
      this.button_save.Text = "Save Data";
      this.button_save.UseVisualStyleBackColor = true;
      this.button_save.Click += new System.EventHandler(this.button_save_Click);
      // 
      // Cluster
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1055, 476);
      this.Controls.Add(this.button_save);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.box_deposit_rate);
      this.Controls.Add(this.box_y_line);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.box_x_line);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.combo_mode);
      this.Controls.Add(this.check_walkers);
      this.Controls.Add(this.box_num_walkers);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.box_down_probability);
      this.Controls.Add(this.box_right_probability);
      this.Controls.Add(this.box_up_probability);
      this.Controls.Add(this.box_left_probability);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label_state);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button_pause);
      this.Controls.Add(this.button_stop);
      this.Controls.Add(this.button_go);
      this.Controls.Add(this.display_panel);
      this.Name = "Cluster";
      this.Text = "Clusters";
      ((System.ComponentModel.ISupportInitialize)(this.display_panel)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox display_panel;
    private System.Windows.Forms.Button button_go;
    private System.Windows.Forms.Button button_stop;
    private System.Windows.Forms.Button button_pause;
    private System.Windows.Forms.Timer clock;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label_state;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox box_left_probability;
    private System.Windows.Forms.TextBox box_up_probability;
    private System.Windows.Forms.TextBox box_right_probability;
    private System.Windows.Forms.TextBox box_down_probability;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox box_num_walkers;
    private System.Windows.Forms.CheckBox check_walkers;
    private System.Windows.Forms.ComboBox combo_mode;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox box_x_line;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox box_y_line;
    private System.Windows.Forms.TextBox box_deposit_rate;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button button_save;
  }
}

