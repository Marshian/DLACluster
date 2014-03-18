using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cluster
{
  public partial class Cluster : Form
  {
    public Cluster()
    {
      InitializeComponent();

      walk = new DLA();
      box_x_line.Text = (display_panel.Width - 150).ToString();
      box_y_line.Text = (display_panel.Height - 50).ToString();
      combo_mode.Items.AddRange(Enum.GetNames(typeof(StepMode)));
      combo_mode.SelectedItem = Enum.GetName(typeof(StepMode), StepMode.ADVANCE_Y);

      walk.Initialize(display_panel.Width, display_panel.Height, 100000, Convert.ToUInt32(box_num_walkers.Text),
                      Convert.ToDouble(box_up_probability.Text), Convert.ToDouble(box_down_probability.Text), 
                      Convert.ToDouble(box_left_probability.Text), Convert.ToDouble(box_right_probability.Text), 
                      Convert.ToInt32(box_y_line.Text), Convert.ToInt32(box_x_line.Text), Convert.ToInt32(box_deposit_rate.Text));
      walk.SetMode(StepMode.ADVANCE_Y);
      ChangeState(ProgramState.READY);

      render_walkers = true;
    }


    private void button_go_Click(object sender, EventArgs e)
    {
      if (walk.GetState() == ProgramState.READY)
      {
        walk.Reset(Convert.ToUInt32(box_num_walkers.Text),
          Convert.ToDouble(box_up_probability.Text), Convert.ToDouble(box_down_probability.Text),
          Convert.ToDouble(box_left_probability.Text), Convert.ToDouble(box_right_probability.Text),
          Convert.ToInt32(box_y_line.Text), Convert.ToInt32(box_x_line.Text), Convert.ToInt32(box_deposit_rate.Text));
        display_panel.Image = new System.Drawing.Bitmap(display_panel.Width, display_panel.Height);
        black_brush = new System.Drawing.SolidBrush(Color.Black);
        white_brush = new System.Drawing.SolidBrush(Color.White);
        red_brush = new System.Drawing.SolidBrush(Color.Red);
        ChangeState(ProgramState.RUNNING);
        clock.Start();
      }
    }

    private void ChangeState(ProgramState new_state)
    {
      walk.SetState(new_state);
      label_state.Text = new_state.ToString();
    }

    private void Shutdown()
    {
      display_panel.Image.Dispose();
      black_brush.Dispose();
      white_brush.Dispose();
      red_brush.Dispose();
    }

    private void clock_Tick(object sender, EventArgs e)
    {
      switch (walk.GetState())
      {
        case ProgramState.DONE:
          {
            walk.Reset(Convert.ToUInt32(box_num_walkers.Text),
              Convert.ToDouble(box_up_probability.Text), Convert.ToDouble(box_down_probability.Text),
              Convert.ToDouble(box_left_probability.Text), Convert.ToDouble(box_right_probability.Text),
              Convert.ToInt32(box_y_line.Text), Convert.ToInt32(box_x_line.Text), Convert.ToInt32(box_deposit_rate.Text));
            ChangeState(ProgramState.STOPPED);
          } break;
        case ProgramState.PAUSED:
          {
          } break;
        case ProgramState.READY:
          {
          } break;
        case ProgramState.RUNNING:
          {
            if (walk.current_state == ProgramState.DONE)
            {
              ChangeState(ProgramState.DONE);
            }
            else
            {
              walk.Step();
              Render();
            }
          } break;
        case ProgramState.STOPPED:
          {
            Shutdown();
            clock.Stop();
            ChangeState(ProgramState.READY);
          } break;
      }
    }

    private void Render()
    {
      var cluster_plot = display_panel.Image;
      using (var graph = Graphics.FromImage(cluster_plot))
      {
        graph.Clear(Color.LightGray);
        for (int i = 0; i < display_panel.Height; i++)
        {
          for (int j = 0; j < display_panel.Width; j++)
          {
            if (walk.pixels[j, i] == true)
            {
              graph.FillRectangle(black_brush, new Rectangle(j, i, 1, 1));
            }
          }
        }
        if (render_walkers == true)
        {
          for (int i = 0; i < walk.number_of_walkers; i++)
          {
            if (walk.walkers[i].state == ParticleState.ALIVE)
            {
              int rx = walk.walkers[i].x;
              int ry = walk.walkers[i].y;
              graph.FillRectangle(white_brush, new Rectangle(rx, ry, 2, 2));
            }
          }
        }
      }

      display_panel.Invalidate();
    }

    private void button_pause_Click(object sender, EventArgs e)
    {
      if (walk.GetState() == ProgramState.PAUSED)
      {
        ChangeState(ProgramState.RUNNING);
      }
      else if (walk.GetState() == ProgramState.RUNNING)
      {
        ChangeState(ProgramState.PAUSED);
      }
    }

    private void button_stop_Click(object sender, EventArgs e)
    {
      ChangeState(ProgramState.DONE);
    }

    private void check_walkers_CheckedChanged(object sender, EventArgs e)
    {
      render_walkers = !render_walkers;
    }
    
    System.Drawing.Brush black_brush;
    System.Drawing.Brush white_brush;
    System.Drawing.Brush red_brush;

    bool render_walkers;

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      walk.SetMode((StepMode)Enum.Parse(typeof(StepMode), combo_mode.SelectedItem.ToString()));
    }

    private void button_save_Click(object sender, EventArgs e)
    {
      walk.SaveData();
    }

    DLA walk;
  }
}