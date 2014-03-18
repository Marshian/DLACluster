using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cluster
{
  // The different running states of the application
  // These are the basis of the very basic state system
  // implemented in this program
  enum ProgramState
  {
    RUNNING,
    PAUSED,
    DONE,
    READY,
    STOPPED
  };

  // The different methods of creating the random walkers
  // for the DLA algorithm.
  enum StepMode
  {
    RANDOM_BOX,
    RANDOM_X_LINE,
    RANDOM_Y_LINE,
    ADVANCE_X,
    ADVANCE_Y
  };

  // States of a random walker, used to tell the program
  // whether or not to apply a particle to the DLA structure
  // and whether or not to re-initialize the walker
  enum ParticleState
  {
    ALIVE,
    DEAD,
    COMPLETE
  };

  // Basic walker, public class members used because of short
  // deadline
  class Walker
  {
    public Walker(int set_x, int set_y)
    {
      x = set_x;
      y = set_y;

      state = ParticleState.ALIVE;
    }

    public int x;
    public int y;
    public ParticleState state;
  };

  //
  //  DLA simulation class (bulk of the program lives here)
  //
  class DLA
  {
    //
    // Initialization function for a given simulation
    // parameters will be passed from the UI
    //
    public void Initialize(int width, int height, uint set_steps, uint set_num_walkers,
                           double set_up_prob, double set_down_prob, double set_left_prob,
                           double set_right_prob, int set_y_line, int set_x_line, int set_deposition_rate)
    {
      // Initializes the DLA grid. This is the same size as the display panel,
      // which is all we care about for the simulation.
      pixels = new bool[width, height];

      // This initializes the list of random walkers
      //  A list is used because we want to be able to delete a random walker
      //  when it travels too far from the simulation, or attaches to the DLA
      //  cluster (at which point we add a new one, so we could use an array,
      //  but this seemed appropriate, since we never do random access.)
      walkers = new List<Walker>();

      // Initialize the random number generator
      // (should move this into the constructor)
      rnd = new Random();

      // parameters will be passed from the application UI
      panel_height = height;
      panel_width = width;
      number_of_steps = set_steps;

      // Set the current cluster state
      cluster_state = ParticleState.ALIVE;

      // Reset function handles the walker and other initialization
      Reset(set_num_walkers, set_up_prob, set_down_prob, set_left_prob, set_right_prob, set_y_line, set_x_line, set_deposition_rate);
    }

    // Simple function to set the current DLA cluster growth method
    public void SetMode(StepMode set_mode)
    {
      step_method = set_mode;
    }

    //
    // Reset simply adjusts all the parameters, it will be called passing
    // the current UI values to the class.
    //
    public void Reset(uint num_particles, double set_up_prob, double set_down_prob, double set_left_prob,
                      double set_right_prob, int set_y_line, int set_x_line, int set_deposition_rate)
    {
      // Up/Down and Left/Right have independant probability spaces.
      //    Any undefined region of probability will cause the particle
      //    to not move along that axis (which gives us 8 possible 
      //    nearest-neighbor sites.)
      up_probability = set_up_prob;
      down_probability = 1.0f - set_down_prob;
      left_probability = set_left_prob;
      right_probability =  1.0f - set_right_prob;

      // Pass parameters to the class
      walkers.Clear();
      number_of_walkers = num_particles;

      generate_x = set_x_line;
      generate_y = set_y_line;
      
      last_deposit_x = set_x_line;
      last_deposit_y = set_y_line;
      deposit_y = 500;
      deposit_x = 900;

      // Initialize the walkers
      for(int i = 0; i < number_of_walkers; i++)
      {
        Walker nwalk = new Walker(0,0);
        InitializeWalker(nwalk);
        walkers.Add(nwalk);
      }

      // Setup the initial cluster state
      //    Note, the cluster could also be setup as a
      //    list, which may lead to performance/memory
      //    improvements. However, coding time was 
      //    a significt consideration, and it seemed
      //    easier/faster to impliment it this way.
      for (int i = 0; i < panel_height; i++)
      {
        for (int j = 0; j < panel_width; j++)
        {
          if (i == (panel_height - 50))
          {
            pixels[j, i] = true;
          }
          else
          {
            pixels[j, i] = false;
          }
        }
      }

      deposit_rate = set_deposition_rate;
      deposit_count = 0;

      current_step = 0;
    }

    // Step function is called every timer tic
    //    This function moves each walker randomly according
    //    to the probabilities specified by the UI, if a
    //    walker "bumps into" the DLA cluster that has
    //    already been grown, that cell on the DLA cluser
    //    becomes activated, and the walker is reinitialized
    public void Step()
    {
      // Test if the cluster method has returned as done,
      // and if so, tell the program the simulation is done
      if (cluster_state == ParticleState.COMPLETE)
      {
        current_state = ProgramState.DONE;
      }
      else
      {
        bool deposit = false;

        // If we haven't advanced far enough (according to whatever
        // ruleset we are using), then perform a standard walker step
        if (deposit_count < deposit_rate)
        {
          deposit = StepRandom();
        }
        // Otherwise we need to update according to some ruleset
        else
        {          
          deposit_count = 0;
          // This ruleset moves the genrating line upward once a certain
          // particle height has been achieved.
          if (step_method == StepMode.ADVANCE_Y)
          {
            generate_y -= 10;
            // If we've reached the top of the simulation, the cluster is done.
            if (generate_y < 50)
            {
              cluster_state = ParticleState.COMPLETE;
              SaveData();
            }
            // Otherwise, move the walkers upwards
            else
            {
              for (int i = 0; i < number_of_walkers; i++)
              {
                InitializeWalker(walkers[i]);
              }
            }
          }
          // This ruleset moves the walkers on a vertical line from the right end
          // of the simulated region to the left
          else if (step_method == StepMode.ADVANCE_X)
          {
            generate_x -= 10;
            // if we're at the left edge, then the simulation is done
            if (generate_x < 50)
            {
              cluster_state = ParticleState.COMPLETE;
              SaveData();
            }
            // otherwise, move left
            else
            {
              for (int i = 0; i < number_of_walkers; i++)
              {
                InitializeWalker(walkers[i]);
              }
            }
          }
        }

        // This boolean is true if the last step deposited a
        // particle onto the DLA cluster. Each ruleset has a
        // specific way of updating accordingly.
        if (deposit)
        {
          // If we're doing a horizontal line advancement, then
          // any deposition counts towards the total.
          if (step_method == StepMode.ADVANCE_X)
          {
            deposit_count++;
            last_deposit_x = deposit_x;
          }
          // If we're doing a vertical line advancement, then
          // we only update the deposition count if we achieve
          // a new maximum height.
          else if(step_method == StepMode.ADVANCE_Y)
          {
            if(deposit_y < last_deposit_y)
            {
              deposit_count++;
              last_deposit_y = deposit_y;
            }
          }
          // If we're depositing a horizontal line, then we're
          // done when the DLA cluster reaches the line (otherwise
          // we will end up with a solid line
          else if (step_method == StepMode.RANDOM_X_LINE)
          {
            if (deposit_y == (generate_y))
            {
              cluster_state = ParticleState.COMPLETE;
              SaveData();
            }
          }
        }
      }
    }

    //
    // Random step for the walkers, this is the heart of the simulation
    //
    private bool StepRandom()
    {
      bool deposit = false;

      // iterate through all of the active walkers
      for (int i = 0; i < number_of_walkers; i++)
      {
        // if the walker is active, then move it to one of 
        // it's nearest neighboring positions, determined by
        // the probabilities given
        if (walkers[i].state == ParticleState.ALIVE)
        {
          int newx = walkers[i].x;           
          int newy = walkers[i].y;

          double movex = (double)(rnd.Next(1, 10000) / (10000.0f));
          double movey = (double)(rnd.Next(1, 10000) / (10000.0f));

          if (movex < left_probability)
          {
            newx--;
          }
          else if (movex > right_probability)
          {
            newx++;
          }

          if (movey < up_probability)
          {
            newy--;
          }
          else if (movey > down_probability)
          {
            newy++;
          }

          // If the particle is outside of the simulation region then
          // it needs to be reinitialized
          if (newy <= 50)
          {
            walkers[i].state = ParticleState.DEAD;
          }

          if (newx <= 50)
          {
            walkers[i].state = ParticleState.DEAD;
          }

          if (newx >= (panel_width - 50))
          {
            walkers[i].state = ParticleState.DEAD;
          }

          // If the particle lands next to any active point in the cluster, then it's
          // position is added to the cluster.
          if ((pixels[newx, newy + 1] == true) || (pixels[newx, newy - 1] == true) ||
             (pixels[newx + 1, newy] == true) || (pixels[newx - 1, newy] == true))
          {
            pixels[newx, newy] = true;
            deposit = true;

            // Keep track of the left-most deposited particle, and the upper-most
            // deposited particle (for the advancing deposition methods.)
            if (newx < last_deposit_x)
            {
              deposit_x = newx;
            }
            if (newy < deposit_y)
            {
              deposit_y = newy;
            }

            // and we're done with that walker, so reinitialize it to the source
            // region
            InitializeWalker(walkers[i]);
          }
          else
          {
            walkers[i].x = newx;
            walkers[i].y = newy;
          }
        }
        // If the particle was outside the region, it needs to be reinitialized
        else if (walkers[i].state == ParticleState.DEAD)
        {
          InitializeWalker(walkers[i]);
        }
        current_step++;
      }

      return deposit;
    }

    //
    //  Basic method to initialize the walkers to the source region defined
    //  by whatever ruleset is specified.
    //
    private void InitializeWalker(Walker new_walker)
    {
      int rndx = 100;
      int rndy = 100;

      switch(step_method)
      {
        default:
          { } break;
        // Random box is a box from the upper left corner (inset by 10x10) to 
        // the lower left corner defined by the parameters in the UI. walkers
        // will randomly initialize anywhere in this region
        case StepMode.RANDOM_BOX:
          {
            rndx = rnd.Next(10, generate_x);
            rndy = rnd.Next(10, generate_y);
          } break;
        // Random horizontal line, walkers will initialize on a line at
        // generate_y, along the simulation region with a buffer of 50 pixels
        // on each side
        case StepMode.RANDOM_X_LINE:
          {
            rndx = rnd.Next(50, panel_width - 50);
            rndy = generate_y; 
          } break;
        // Similar to RANDOM_X_LINE except a vertical line.
        case StepMode.RANDOM_Y_LINE:
          {
            rndx = generate_x;
            rndy = rnd.Next(50, panel_height - 50);
          } break;
        // ADVANCE_Y, starts a horizontal block of walkers, but moves up as
        // the simulation progresses. Initially I tried a horizontal line,
        // but it was slower and had issues, the box seems to work a lot better.
        case StepMode.ADVANCE_Y:
          {
            rndx = rnd.Next(50, panel_width - 50);
            rndy = rnd.Next(generate_y - 20, generate_y);
          } break;
        // ADVANCE_X is similar to ADVANCE_Y. It's tricky to get the parameters
        // right for this not to turn into a filled up source region. Remember to
        // keep the deposition rate low enough, and the number of particles right.
        case StepMode.ADVANCE_X:
          {
            rndx = rnd.Next(generate_x - 20, generate_x);
            rndy = rnd.Next(50, panel_height - 50);
          } break;
      }
      
      // Initialize the walker. 
      new_walker.x = rndx;
      new_walker.y = rndy;
      new_walker.state = ParticleState.ALIVE;
    }

    //
    // This sets up the horizontal source line
    //
    private void InitializePoints()
    {
      int rndx = rnd.Next(1, (panel_width - 200));
      pixels[100 + rndx, 100] = true;
    }

    //
    // current_state member accessor
    //
    public ProgramState GetState()
    {
      return current_state;
    }

    //
    // current_state member assignor
    //
    public void SetState(ProgramState set_state)
    {
      current_state = set_state;
    }

    //
    // Basic method to open a save dialog and save the DLA cluster data
    //
    public void SaveData()
    {
      // Basic dialog parameters (saving .dat files due to GnuPlot script I wrote
      // but looking back, these are really .csv files and should really be
      // named appropriately)
      SaveFileDialog save_file = new SaveFileDialog();
      save_file.Filter = "Data File|*.dat";
      save_file.Title = "Save Grid Data";
      save_file.ShowDialog();

      // As long as we get a valid filename, write out the active pixel coordinates
      // to the data file
      if (save_file.FileName != "")
      {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(save_file.FileName))
        {
          for (int i = 0; i < panel_height; i++)
          {
            for (int j = 0; j < panel_width; j++)
            {
              if (pixels[j, i] == true)
              {
                file.WriteLine((panel_width - j) + "," + (panel_height - i));
              }
            }
          }
        }
      }
      save_file.Dispose();
    }

    // Simulation state (cludgey state management system)
    public ProgramState current_state;

    // DLA cluster data (true is in the cluster, false is not)
    public bool[,] pixels;

    // simulation size (same size as display panel
    int panel_width;
    int panel_height;

    // random walkers
    public List<Walker> walkers;
    public uint number_of_walkers;

    // keep track of the steps
    public uint current_step;

    // this was going to be used as a stopping point, but I never
    // got around to implementing it
    private uint number_of_steps;

    // movement probabilities
    double left_probability;
    double right_probability;
    double up_probability;
    double down_probability;

    // line boundaries (different useage for different rules)
    int generate_y;
    int generate_x;

    // State of the DLA cluster (eg, done or not)
    ParticleState cluster_state;

    // current generation method
    public StepMode step_method;

    // deposition parameters (used primarily in the advancing rule-sets)
    public int deposit_count;
    int deposit_rate;
    int last_deposit_x;
    public int last_deposit_y;
    int deposit_x;
    public int deposit_y;

    // Random number generator
    Random rnd;
  }
}
