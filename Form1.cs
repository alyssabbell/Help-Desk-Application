/*
 * Author: Alyssa Bell
 * Date: 4/21/18
 * Filename: SunyADKHelpDesk
 * 
 * Purpose/Description: This program allows the user to submit repair tickets into the help desk,
 *  as well as update the status or technician of the tickets. It also allows the user to retreive
 *  tickets based on the status (open/in-progress/closed).
 * 
 * Error Checking: - try/catch/finally combo if connection to database is successful or not
 *  - error message/unable to submit ticket if a room number < 1 or room number is > 398
 *  - if any ticket input fields do not contain information, the user will be prompted to enter info
 *  - a ticketID must be entered in order to update the status or technician
 *  - checks if a table already exists in the database, and if not it's created
 * 
 * Assumptions: The user will only enter numeric types into the Room Number field,
 *  and full names with letter characters only will be submitted into the Submitted By text field
 * 
 * Summary of Methods: 
 *  - DisplayTable() - displays all records that exist in the Ticket table
 *  - DisplaySubmitControls() - Displays the labels, comboboxes, and buttons associated with the Submit Ticket option
 *  - DeleteTables() - this is for testing purposes, all tables are dropped when Exit button is clicked (currently disabled)
 *  - FillUsersComboBox() - pulls the user names stored in the Users table and displays into combobox
 *      to allow user to view the tickets submitted by selected user
 *  - ResetControls() - resets all of the dropdowns.SelectedIndex in the Submit Ticket feature to -1
 *  - CreateTables() - creates the tables in Bella database (Location, Repairs, RepairTimes, Status
 *         Technicians, Tickets, TicketType, Urgency, Users)
 * 
 * Input: Bella database - tables (Location, Repairs, RepairTimes, Status, Technicians, Tickets,
 *  TicketType, Urgency, and Users)
 * 
 * Output: Results are displayed in GUI based on content of tables
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SunyADKHelpDesk
{
    public partial class HelpDesk : Form
    {
        // establish connection with database Bella
        SqlConnection conn = new SqlConnection("Data Source = 23.253.57.248; Initial Catalog = Bella; User ID = bella; Password = 1xWMzH3#GpBA");
        SqlDataAdapter da;
        SqlCommand myCommand;
        SqlCommand tableChck;
        SqlCommand nameCheck;
        DataSet ds = new DataSet();

        int roomNum = 0;

        public HelpDesk()
        {
            InitializeComponent();
        }

        private void HelpDesk_Load(object sender, EventArgs e)
        {
            // hide all controls upon formload
            grpBxSubmit.Visible = false;
            rdBtnSubmit.Visible = true;
            rdBtnSubmit.Checked = false;
            rdBtnUpdate.Visible = true;
            rdBtnUpdate.Checked = false;
            rdBtnRetreive.Visible = true;
            rdBtnRetreive.Checked = false;
            cmbBxVwByUsers.Visible = false;
            btnRtrvTicks.Visible = false;
            rdBtnVwBySts.Visible = false;
            rdBtnVwByTech.Visible = false;
            rdBtnVwByUser.Visible = false;
            cmbBxVwBySts.Visible = false;
            cmbBxVwByTech.Visible = false;
            cmbBxVwByUsers.Visible = false;
            btnResetSelc.Visible = false;
            btnRtrvTicks.Visible = false;
            cmbBxChgSts.Visible = false;
            cmbBxChgTech.Visible = false;
            btnSbmtUpdts.Visible = false;

            // creates all tables associated with tickets
            CreateTables();

            // displays the existing tickets
            DisplayTable();


        }



        //........................... PART A .............................................
        // allows user to submit a new ticket into the database
        private void rdBtnSubmit_CheckedChanged(object sender, EventArgs e)
        {
            // clear controls after ticket is submitted
            ResetControls();

            //unhides Submit controls, hides rest
            DisplaySubmitControls();

            // displaying all records in Tickets
            DisplayTable();
        }


        private void cmbBxTicType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if Faculty/Staff is selected
            if (cmbBxTicType.SelectedIndex == 0)
            {
                cmbBxOffcRpr.Visible = true;
                cmbBxClssRmRpr.Visible = false;
                cmbBxDrmRpr.Visible = false;
                cmbBxBldg.Enabled = true;
                cmbBxBldg.Text = "";
                cmbBxUrgency.Enabled = true;
                cmbBxUrgency.Text = "";
                cmbBxStatus.Enabled = false;
                cmbBxStatus.Text = "Open";
                cmbBxTech.Enabled = false;
                cmbBxTech.Text = "Unassigned";

            }

            // if Classroom/Labs is selected
            if (cmbBxTicType.SelectedIndex == 1)
            {
                cmbBxOffcRpr.Visible = false;
                cmbBxClssRmRpr.Visible = true;
                cmbBxDrmRpr.Visible = false;
                cmbBxBldg.Enabled = true;
                cmbBxBldg.Text = "";
                cmbBxUrgency.Enabled = false;
                cmbBxUrgency.Text = "High";
                cmbBxStatus.Enabled = false;
                cmbBxStatus.Text = "Open";
                cmbBxTech.Enabled = false;
                cmbBxTech.Text = "Unassigned";
            }

            // if Dorms is selected
            if (cmbBxTicType.SelectedIndex == 2)
            {
                cmbBxOffcRpr.Visible = false;
                cmbBxClssRmRpr.Visible = false;
                cmbBxDrmRpr.Visible = true;
                cmbBxUrgency.Enabled = false;
                cmbBxUrgency.Text = "Low";
                cmbBxStatus.Enabled = false;
                cmbBxStatus.Text = "Open";
                cmbBxTech.Enabled = false;
                cmbBxTech.Text = "Unassigned";
                cmbBxBldg.Enabled = false;
                cmbBxBldg.Text = "Dorms";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // clears all Submit Ticket controls
            ResetControls();
        }


        // - - - - - - - - - - - - - -  Handling Submit Tickets Feature - - - - - - - - - - - -
        private void btnSbmt_Click(object sender, EventArgs e)
        {
            // attempt connection to Bella database
            try
            {
                conn.Open();

                ds = new DataSet();

                // - - - - - - - - - - -  Check if user already exists in User table
                nameCheck = new SqlCommand("if exists (Select Username from Users where Username='" + txtSubBy.Text + "') " +
                    "SELECT 1 ELSE SELECT 0", conn);

                int x = Convert.ToInt32(nameCheck.ExecuteScalar());

                if (x == 1)
                {
                    //MessageBox.Show("Username already exists");
                }
                else
                {
                    myCommand = new SqlCommand("Insert into Users(UserName) values('" + txtSubBy.Text + "')", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();
                }
                // End checking if username already exists


                ds = new DataSet();

                // - - - - - - - - - - insert into tickets if office selected (Windows/Mac/Linux)(computer/printer/other)
                if (cmbBxTicType.SelectedIndex == 0)
                {
                    if (cmbBxTicType.Text == "" || cmbBxBldg.Text == "" || txtRoomNum.Text == "" || cmbBxUrgency.Text == ""
                || cmbBxOffcRpr.Text == "" || cmbBxRprTime.Text == "" || txtSubBy.Text == "")
                    {
                        MessageBox.Show("You must enter information for all fields before submitting the ticket.");
                        cmbBxTicType.Focus();
                    }

                    else
                    {
                        // if txtRoomNum has a value in it
                        roomNum = Convert.ToInt32(txtRoomNum.Text);
                        if (roomNum < 1 || roomNum > 398)
                        {
                            MessageBox.Show("You must enter a room number between 0 and 399");
                            txtRoomNum.Focus();

                            roomNum = Convert.ToInt32(txtRoomNum.Text);
                        }

                        else // if room num is between 0 and 399 then save ticket info
                        {
                            myCommand = new SqlCommand("Insert into Tickets(Date, RepairTime, RoomType, Repair, UrgencyLevel, Technician, " +
                                     "Building, RoomNum, Status, SubmittedBy) values('" + dtpDate.Text.ToString() + "', " +
                                 "(Select TimeID from RepairTimes where TimeRange='" + cmbBxRprTime.SelectedItem.ToString() + "'), " +
                            "(Select RoomID from TicketType where RoomType='" + cmbBxTicType.SelectedItem.ToString() + "'), " +
                            "(Select RepairID from Repairs where RepairType='" + cmbBxOffcRpr.SelectedItem.ToString() + "'), " +
                            "(Select UrgencyID from Urgency where Description='" + cmbBxUrgency.SelectedItem.ToString() + "'), " +
                                 "'U', (Select BuildID from Location where BuildName='" + cmbBxBldg.SelectedItem.ToString() + "'), " +
                                 "'" + txtRoomNum.Text + "', 'O', (Select UserID from Users where UserName='" + txtSubBy.Text + "'))", conn);

                            MessageBox.Show("Your ticket has been submitted.");
                        }

                    }
                } // End of if Office selected

                // - - - - - - - - - - insert into tickets if Classroom selected (computer/monitor/network/printer/projector/other)
                if (cmbBxTicType.SelectedIndex == 1)
                {
                    if (cmbBxTicType.Text == "" || cmbBxBldg.Text == "" || txtRoomNum.Text == "" ||
                 cmbBxClssRmRpr.Text == "" || cmbBxRprTime.Text == "" || cmbBxStatus.Text == "" || txtSubBy.Text == "")
                    {
                        MessageBox.Show("You must enter information for all fields before submitting the ticket.");
                    }

                    else
                    {
                        // if txtRoomNum has a value in it
                        roomNum = Convert.ToInt32(txtRoomNum.Text);
                        if (roomNum < 1 || roomNum > 398)
                        {
                            MessageBox.Show("You must enter a room number between 0 and 399");
                            txtRoomNum.Focus();

                            roomNum = Convert.ToInt32(txtRoomNum.Text);
                        }
                        else
                        {
                            myCommand = new SqlCommand("Insert into Tickets(Date, RepairTime, RoomType, Repair, UrgencyLevel, Technician, " +
                                     "Building, RoomNum, Status, SubmittedBy) values('" + dtpDate.Text.ToString() + "', " +
                                 "(Select TimeID from RepairTimes where TimeRange='" + cmbBxRprTime.SelectedItem.ToString() + "'), " +
                            "(Select RoomID from TicketType where RoomType='" + cmbBxTicType.SelectedItem.ToString() + "'), " +
                            "(Select RepairID from Repairs where RepairType='" + cmbBxClssRmRpr.SelectedItem.ToString() + "'), " +
                            "'L3', 'U', (Select BuildID from Location where BuildName='" + cmbBxBldg.SelectedItem.ToString() + "'), " +
                                 "'" + txtRoomNum.Text + "', 'O', (Select UserID from Users where UserName='" + txtSubBy.Text + "'))", conn);

                            MessageBox.Show("Your ticket has been submitted.");

                        }
                    }

                } // - - - - - - - - - - End of if Classroom Selected


                // - - - - - - - - - - insert into tickets if dorm selected (Windows/Mac/Linux)
                if (cmbBxTicType.SelectedIndex == 2)
                {
                    if (cmbBxTicType.Text == "" || cmbBxBldg.Text == "" || txtRoomNum.Text == ""
                || cmbBxDrmRpr.Text == "" || cmbBxRprTime.Text == "" || cmbBxTech.Text == "" || txtSubBy.Text == "")
                    {
                        MessageBox.Show("You must enter information for all fields before submitting the ticket.");
                    }

                    else
                    {
                        // if txtRoomNum has a value in it
                        roomNum = Convert.ToInt32(txtRoomNum.Text);
                        if (roomNum < 1 || roomNum > 398)
                        {
                            MessageBox.Show("You must enter a room number between 0 and 399");
                            txtRoomNum.Focus();

                            roomNum = Convert.ToInt32(txtRoomNum.Text);
                        }
                        else
                        {
                            myCommand = new SqlCommand("Insert into Tickets(Date, RepairTime, RoomType, Repair, UrgencyLevel, Technician, " +
                                         "Building, RoomNum, Status, SubmittedBy) values('" + dtpDate.Text.ToString() + "', " +
                                     "(Select TimeID from RepairTimes where TimeRange='" + cmbBxRprTime.SelectedItem.ToString() + "'), " +
                                "(Select RoomID from TicketType where RoomType='" + cmbBxTicType.SelectedItem.ToString() + "'), " +
                                "(Select RepairID from Repairs where RepairType='" + cmbBxDrmRpr.SelectedItem.ToString() + "'), " +
                                "'L1', 'U', 'B4', '" + txtRoomNum.Text + "', 'O', (Select UserID from Users where UserName='" + txtSubBy.Text + "'))", conn);

                            MessageBox.Show("Your ticket has been submitted.");

                        }
                    }

                } // - - - - - - - - -  End of if Dorm selected


                da = new SqlDataAdapter(myCommand);

                da.SelectCommand.ExecuteNonQuery();


            }
            // if connection fails, display error message
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // close connection to Bella database
            finally
            {
                conn.Close();
            }

            DisplayTable();
        }
        ///........................... END PART A .............................................



        //........................... PART B .............................................

        // User selects option to update existing tickets
        // can change tech assigned to ticket or change status from open to in-progress or closed
        private void rdBtnUpdate_CheckedChanged(object sender, EventArgs e)
        {
            // reset controls so when user switches back to Submit a ticket, there's no data entered
            ResetControls();

            cmbBxChgTech.Visible = true;
            cmbBxChgSts.Visible = true;
            rdBtnVwBySts.Visible = false;
            rdBtnVwByTech.Visible = false;
            rdBtnVwByUser.Visible = false;
            cmbBxVwBySts.Visible = false;
            cmbBxVwByTech.Visible = false;
            cmbBxVwByUsers.Visible = false;
            btnResetSelc.Visible = false;
            btnRtrvTicks.Visible = false;
            btnSbmtUpdts.Visible = true;
            grpBxSubmit.Visible = true;
            rdBtnStatus.Visible = true;
            rdBtnTech.Visible = true;
            lblEnterTckID.Visible = true;
            txtEnterTickID.Visible = true;
            btnRtrvTicks.Visible = false;
            cmbBxTicType.Visible = false;
            lblTicType.Visible = false;
            cmbBxBldg.Visible = false;
            lblBldg.Visible = false;
            txtRoomNum.Visible = false;
            lblRoomNum.Visible = false;
            cmbBxUrgency.Visible = false;
            lblUrgency.Visible = false;
            cmbBxOffcRpr.Visible = false;
            lblRprType.Visible = false;
            cmbBxClssRmRpr.Visible = false;
            cmbBxDrmRpr.Visible = false;
            cmbBxRprTime.Visible = false;
            lblRprTime.Visible = false;
            cmbBxTech.Visible = false;
            lblSelTech.Visible = false;
            dtpDate.Visible = false;
            lblDate.Visible = false;
            txtSubBy.Visible = false;
            lblSubBy.Visible = false;
            btnSbmt.Visible = false;
            btnReset.Visible = false;
            cmbBxStatus.Visible = false;
            lblStatus.Visible = false;

            DisplayTable();

        }

        // controls if user selects radio button to update the ticket status
        private void rdBtnStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbBxChgSts.Enabled = true;
            txtEnterTickID.Text = "";
            cmbBxChgTech.Text = "";
            cmbBxChgTech.Enabled = false;
            cmbBxTicType.Enabled = false;
            cmbBxBldg.Enabled = false;
            txtRoomNum.Enabled = false;
            cmbBxUrgency.Enabled = false;
            cmbBxOffcRpr.Enabled = false;
            cmbBxClssRmRpr.Enabled = false;
            cmbBxDrmRpr.Enabled = false;
            cmbBxRprTime.Enabled = false;
            cmbBxTech.Enabled = false;
            dtpDate.Enabled = false;
            txtSubBy.Enabled = false;
            btnSbmt.Visible = false;
            btnReset.Visible = false;

        }

        // submit button to update the ticket status or the technician
        private void btnSbmtUpdts_Click(object sender, EventArgs e)
        {
            // updating the status
            if (rdBtnStatus.Checked == true)
            {
                // attempt connection to Update the status of a ticket
                try
                {
                    conn.Open();

                    ds = new DataSet();
                    if (txtEnterTickID.Text == "")
                    {
                        MessageBox.Show("Please enter a ticket ID to update");
                        txtEnterTickID.Focus();
                    }
                    else
                    {
                        myCommand = new SqlCommand("Update Tickets Set Status=s.StatusID from Tickets t, Status s " +
                        "where s.CurrentStatus='" + cmbBxChgSts.SelectedItem.ToString() + "' And t.TicketID='" + Convert.ToInt32(txtEnterTickID.Text) + "'", conn);

                        da = new SqlDataAdapter(myCommand);

                        da.SelectCommand.ExecuteNonQuery();

                        MessageBox.Show("The status has been updated.");

                    }
                }

                // if connection fails, display error message
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // close connection to Bella database
                finally
                {
                    conn.Close();
                }

            }

            // updating the technician
            if (rdBtnTech.Checked == true)
            {
                // attempt connection with database to Update the technician
                try
                {
                    conn.Open();

                    ds = new DataSet();
                    if (txtEnterTickID.Text == "")
                    {
                        MessageBox.Show("Please enter a ticket ID to update");
                    }
                    else
                    {
                        myCommand = new SqlCommand("Update Tickets Set Technician=tc.TechID from Tickets t, Technicians tc " +
                       "where tc.Name='" + cmbBxChgTech.SelectedItem.ToString() + "' And t.TicketID='" + Convert.ToInt32(txtEnterTickID.Text) + "'", conn);

                        da = new SqlDataAdapter(myCommand);

                        da.SelectCommand.ExecuteNonQuery();

                        MessageBox.Show("The technician has been updated.");
                    }
                }

                // if connection fails, display error message
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // close connection to Bella database
                finally
                {
                    conn.Close();
                }
            }

            cmbBxChgTech.SelectedIndex = -1;
            cmbBxChgSts.SelectedIndex = -1;
            txtEnterTickID.Text = "";

            DisplayTable();
        }

        //..............................  END PART B .............................................



        //................................... PART C .............................................

        // selected to view the tickets submitted by user
        private void rdBtnVwByUser_CheckedChanged(object sender, EventArgs e)
        {
            FillUsersComboBox();
            cmbBxVwByTech.SelectedIndex = -1;
            cmbBxVwBySts.SelectedIndex = -1;
            cmbBxVwByUsers.Enabled = true;
            cmbBxVwByTech.Enabled = false;
            cmbBxVwBySts.Enabled = false;
        }

        // selected to view the tickets by technician
        private void rdBtnVwByTech_CheckedChanged(object sender, EventArgs e)
        {
            cmbBxVwBySts.SelectedIndex = -1;
            cmbBxVwByUsers.SelectedIndex = -1;
            cmbBxVwByTech.Enabled = true;
            cmbBxVwByUsers.Enabled = false;
            cmbBxVwBySts.Enabled = false;
        }

        // selected to view the tickets based on status
        private void rdBtnVwBySts_CheckedChanged(object sender, EventArgs e)
        {
            cmbBxVwByTech.SelectedIndex = -1;
            cmbBxVwByUsers.SelectedIndex = -1;
            cmbBxVwBySts.Enabled = true;
            cmbBxVwByTech.Enabled = false;
            cmbBxVwByUsers.Enabled = false;
        }

        private void btnResetSelc_Click(object sender, EventArgs e)
        {
            rdBtnVwByUser.Enabled = true;
            rdBtnVwByUser.Checked = false;
            cmbBxVwByUsers.Enabled = false;
            rdBtnVwByTech.Enabled = true;
            rdBtnVwByTech.Checked = false;
            cmbBxVwByTech.Enabled = false;
            rdBtnVwBySts.Enabled = true;
            rdBtnVwBySts.Checked = false;
            cmbBxVwBySts.Enabled = false;
            cmbBxVwBySts.SelectedIndex = -1;
            cmbBxChgTech.SelectedIndex = -1;
            cmbBxVwByTech.SelectedIndex = -1;
            cmbBxVwByUsers.SelectedIndex = -1;

            DisplayTable();
        }


        private void btnRtrvTicks_Click(object sender, EventArgs e)
        {
            // attempt connection with Bella database
            try
            {
                conn.Open();

                // view tickets entered by the chosen user
                if (rdBtnVwByUser.Checked == true)
                {
                    ds = new DataSet();

                    myCommand = new SqlCommand("Select t.TicketID, t.Date as Submission_Date, " +
               "rt.TimeRange as Repair_Time, tt.RoomType as Room_Type, r.RepairType as Repair_Type, " +
               "u.Description as Priority, tc.Name as Techn_Name, l.BuildName as Building, " +
               "t.RoomNum as Room_Num, s.CurrentStatus as Current_Status, us.Username as Submitted_By from " +
               "Tickets t " +
           "Inner Join RepairTimes rt On t.RepairTime = rt.TimeID " +
           "Inner Join TicketType tt On t.RoomType = tt.RoomID " +
           "Inner Join Repairs r On t.Repair = r.RepairID " +
           "Inner Join Urgency u On t.UrgencyLevel = u.UrgencyID " +
           "Inner Join Technicians tc On t.Technician = tc.TechID " +
           "Inner Join Location l On t.Building = l.BuildID " +
           "Inner Join Status s On t.Status = s.StatusID " +
           "Inner Join Users us On t.SubmittedBy = us.UserID " +
           "where us.Username='" + cmbBxVwByUsers.SelectedItem.ToString() + "' order by t.TicketID", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();


                }

                // view tickets by selected technician
                if (rdBtnVwByTech.Checked == true)
                {
                    ds = new DataSet();

                    myCommand = new SqlCommand("Select t.TicketID, t.Date as Submission_Date, " +
                "rt.TimeRange as Repair_Time, tt.RoomType as Room_Type, r.RepairType as Repair_Type, " +
                "u.Description as Priority, tc.Name as Techn_Name, l.BuildName as Building, " +
                "t.RoomNum as Room_Num, s.CurrentStatus as Current_Status, us.Username as Submitted_By from " +
                "Tickets t " +
            "Inner Join RepairTimes rt On t.RepairTime = rt.TimeID " +
            "Inner Join TicketType tt On t.RoomType = tt.RoomID " +
            "Inner Join Repairs r On t.Repair = r.RepairID " +
            "Inner Join Urgency u On t.UrgencyLevel = u.UrgencyID " +
            "Inner Join Technicians tc On t.Technician = tc.TechID " +
            "Inner Join Location l On t.Building = l.BuildID " +
            "Inner Join Status s On t.Status = s.StatusID " +
            "Inner Join Users us On t.SubmittedBy = us.UserID " +
            "where tc.Name='" + cmbBxVwByTech.SelectedItem.ToString() + "' And " +
            "t.Status In('O', 'P') order by t.TicketID", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();
                }

                // view tickets by selected status
                if (rdBtnVwBySts.Checked == true)
                {
                    ds = new DataSet();

                    myCommand = new SqlCommand("Select t.TicketID, t.Date as Submission_Date, " +
                "rt.TimeRange as Repair_Time, tt.RoomType as Room_Type, r.RepairType as Repair_Type, " +
                "u.Description as Priority, tc.Name as Techn_Name, l.BuildName as Building, " +
                "t.RoomNum as Room_Num, s.CurrentStatus as Current_Status, us.Username as Submitted_By from " +
                "Tickets t " +
            "Inner Join RepairTimes rt On t.RepairTime = rt.TimeID " +
            "Inner Join TicketType tt On t.RoomType = tt.RoomID " +
            "Inner Join Repairs r On t.Repair = r.RepairID " +
            "Inner Join Urgency u On t.UrgencyLevel = u.UrgencyID " +
            "Inner Join Technicians tc On t.Technician = tc.TechID " +
            "Inner Join Location l On t.Building = l.BuildID " +
            "Inner Join Status s On t.Status = s.StatusID " +
            "Inner Join Users us On t.SubmittedBy = us.UserID " +
            "where s.CurrentStatus='" + cmbBxVwBySts.SelectedItem.ToString() + "' order by t.TicketID", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();
                }


                using (da = new SqlDataAdapter(myCommand))
                {
                    da.Fill(ds, "t1");
                }

                dgDisplay.DataSource = ds.Tables[0];

            }

            // if connection fails, display error message
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // close connection to Bella database
            finally
            {
                conn.Close();
            }
        }


        // User retreives submitted tickets
        // Retreive all tickets, open/in-progress tickets, 
        // or allow IT admin to retreive a list of all open tickets, in-progress tickets, or all closed tickets
        private void rdBtnRetreive_CheckedChanged(object sender, EventArgs e)
        {
            //display controls for Retreive Tickets
            rdBtnVwBySts.Visible = true;
            rdBtnVwByTech.Visible = true;
            rdBtnVwByUser.Visible = true;
            cmbBxVwBySts.Visible = true;
            cmbBxVwByTech.Visible = true;
            cmbBxVwByUsers.Visible = true;
            btnResetSelc.Visible = true;
            btnRtrvTicks.Visible = true;
            grpBxSubmit.Visible = false;
            cmbBxVwByUsers.Visible = true;
            btnRtrvTicks.Visible = true;
            cmbBxChgSts.Visible = false;
            cmbBxVwByUsers.Enabled = false;
            cmbBxVwBySts.Enabled = false;
            cmbBxVwByTech.Enabled = false;
            cmbBxChgTech.Visible = false;
            lblEnterTckID.Visible = false;
            txtEnterTickID.Visible = false;
            btnSbmtUpdts.Visible = false;
        }

        // Controls if change technician is selected
        private void rdBtnTech_CheckedChanged(object sender, EventArgs e)
        {
            cmbBxChgTech.Enabled = true;
            cmbBxTech.Enabled = true;
            txtEnterTickID.Text = "";
            cmbBxChgSts.Text = "";
            cmbBxChgSts.Enabled = false;
            cmbBxTicType.Enabled = false;
            cmbBxBldg.Enabled = false;
            txtRoomNum.Enabled = false;
            cmbBxUrgency.Enabled = false;
            cmbBxOffcRpr.Enabled = false;
            cmbBxClssRmRpr.Enabled = false;
            cmbBxDrmRpr.Enabled = false;
            cmbBxRprTime.Enabled = false;
            cmbBxStatus.Enabled = false;
            dtpDate.Enabled = false;
            txtSubBy.Enabled = false;
            btnSbmt.Visible = false;
            btnReset.Visible = false;
        }
        //.................................. END PART C .............................................

        private void btnExit_Click(object sender, EventArgs e)
        {
            //DeleteTables();
            this.Close();

        }



        // = = = = = = = = = = = = = = = = = = = = Start Helper Methods = = = = = = = = = = = = = = = = =
        /*
         * Pre: There are no tables saved on the server, tables need to be created
         * post: Tables Technicians, Tickets, now exist on the server
         * purpose: To create all tables - skip if already created
         */
        public void CreateTables()
        {

            try
            {
                // - - - - - - - - - - - - - Build Tables - - - - - - - - - - - - -

                // - - - - - - - - - - - - - -  Technicians - - - - - - - - - - - - 
                conn.Open();

                DataSet ds = new DataSet();

                tableChck = new SqlCommand("if exists (select * from INFORMATION_SCHEMA.TABLES " +
                      "WHERE TABLE_NAME = 'Technicians') SELECT 1 ELSE SELECT 0", conn);

                int x = Convert.ToInt32(tableChck.ExecuteScalar());

                if (x == 1)
                {
                    //MessageBox.Show("Technician table already exists");
                }
                else
                {
                    myCommand = new SqlCommand("Create table Technicians(TechID char(3) Not Null Primary Key, " +
                    "Name char(60))", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("The Technicians table has been created.");

                    ds = new DataSet();

                    // fill Technicians 
                    myCommand = new SqlCommand("Insert into Technicians(TechID, Name) values('Em1', 'Matt Fernicola')," +
                    " ('Em2', 'Justin Thyme'), ('Em3', 'Ike Cannelpu'), ('Em4', 'Matt Hull'), ('U', 'Unassigned')", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();
                }



                // - - - - - - - - - - - - - -  Status - - - - - - - - - - - -
                // Status
                ds = new DataSet();

                tableChck = new SqlCommand("if exists (select * from INFORMATION_SCHEMA.TABLES " +
                      "WHERE TABLE_NAME = 'Status') SELECT 1 ELSE SELECT 0", conn);

                x = Convert.ToInt32(tableChck.ExecuteScalar());

                if (x == 1)
                {
                    //MessageBox.Show("Status table already exists");
                }
                else
                {
                    myCommand = new SqlCommand("Create table Status(StatusID char(1) Not Null Primary Key, " +
                       "CurrentStatus char(13))", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("The Status table has been created.");

                    // fill Status
                    ds = new DataSet();

                    myCommand = new SqlCommand("Insert into Status(StatusID, CurrentStatus)" +
                    " values('O', 'Open'), ('P', 'In-Progress'), ('C', 'Closed')", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                }



                // - - - - - - - - - - - - Urgency - - - - - - - - - - - - - - 
                ds = new DataSet();

                tableChck = new SqlCommand("if exists (select * from INFORMATION_SCHEMA.TABLES " +
                      "WHERE TABLE_NAME = 'Urgency') SELECT 1 ELSE SELECT 0", conn);

                x = Convert.ToInt32(tableChck.ExecuteScalar());

                if (x == 1)
                {
                    //MessageBox.Show("Urgency table already exists");
                }

                else
                {
                    myCommand = new SqlCommand("Create table Urgency(UrgencyID char(2) Not Null Primary Key, " +
                "Description char(7))", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("The Urgency table has been created.");

                    // fill Urgency
                    ds = new DataSet();

                    myCommand = new SqlCommand("Insert into Urgency(UrgencyID, Description)" +
                        " values('L1', 'Low'), ('L2', 'Medium'), ('L3', 'High')", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();
                }



                // - - - - - - - - - - - - Ticket Type - - - - - - - - - - - - - 
                ds = new DataSet();

                tableChck = new SqlCommand("if exists (select * from INFORMATION_SCHEMA.TABLES " +
                     "WHERE TABLE_NAME = 'TicketType') SELECT 1 ELSE SELECT 0", conn);

                x = Convert.ToInt32(tableChck.ExecuteScalar());

                if (x == 1)
                {
                    //MessageBox.Show("TicketType table already exists");
                }

                else
                {
                    myCommand = new SqlCommand("Create table TicketType(RoomID char(2) Not Null Primary Key, " +
                        "RoomType char(11))", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("The TicketType table has been created.");

                    // fill TicketType
                    ds = new DataSet();

                    myCommand = new SqlCommand("Insert into TicketType(RoomID, RoomType)" +
                        " values('R1', 'Office'), ('R2', 'Classroom'), ('R3', 'Dorm')", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                }



                // - - - - - - - - - - - - Ticket Location - - - - - - - - - - - - - 
                ds = new DataSet();

                tableChck = new SqlCommand("if exists (select * from INFORMATION_SCHEMA.TABLES " +
                     "WHERE TABLE_NAME = 'Location') SELECT 1 ELSE SELECT 0", conn);

                x = Convert.ToInt32(tableChck.ExecuteScalar());

                if (x == 1)
                {
                    //MessageBox.Show("Location table already exists");
                }

                else
                {
                    myCommand = new SqlCommand("Create table Location(BuildID char(2) Not Null Primary Key, " +
                        "BuildName char(12))", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("The Location table has been created.");

                    // fill Location
                    ds = new DataSet();

                    myCommand = new SqlCommand("Insert into Location(BuildID, BuildName)" +
                        " values('B1', 'Scoville'), ('B2', 'Dearlove'), ('B3', 'Warren Hall'), ('B4', 'Dorms')", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();
                }



                // - - - - - - - - - - - - - - - Repair Type - - - - - - - - - - 
                ds = new DataSet();

                tableChck = new SqlCommand("if exists (select * from INFORMATION_SCHEMA.TABLES " +
                     "WHERE TABLE_NAME = 'Repairs') SELECT 1 ELSE SELECT 0", conn);

                x = Convert.ToInt32(tableChck.ExecuteScalar());

                if (x == 1)
                {
                    //MessageBox.Show("Repairs table already exists");
                }

                else
                {
                    myCommand = new SqlCommand("Create table Repairs(RepairID char(2) Not Null Primary Key, " +
                        "RepairType char(13))", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("The Repairs table has been created.");

                    // fill Repairs
                    ds = new DataSet();

                    myCommand = new SqlCommand("Insert into Repairs(RepairID, RepairType)" +
                        " values('D1', 'Computer'), ('D2', 'Monitor'), ('D3', 'Printer'), ('D4', 'Network')," +
                    " ('D5', 'Projector'), ('D6', 'Windows'), ('D7', 'Mac'), ('D8', 'Linux'), ('D9', 'Other')", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();
                }



                // - - - - - - - - - - - - - Tickets - - - - - - - - - - - - - - 
                // all entered tickets are saved into this table
                ds = new DataSet();

                tableChck = new SqlCommand("if exists (select * from INFORMATION_SCHEMA.TABLES " +
                     "WHERE TABLE_NAME = 'Tickets') SELECT 1 ELSE SELECT 0", conn);

                x = Convert.ToInt32(tableChck.ExecuteScalar());

                if (x == 1)
                {
                    //MessageBox.Show("Tickets table already exists");
                }

                else
                {
                    myCommand = new SqlCommand("Create table Tickets(TicketID int Not Null Identity Primary Key," +
                " Date char(55), RepairTime char(20), RoomType char(23), Repair char(14), UrgencyLevel char(10), Technician char(60)," +
                " Building char(13), RoomNum char(4), Status char(12), SubmittedBy varchar(4))", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("The Tickets table has been created.");

                }

                // - - - - - - - - - - - - Users - - - - - - - - - - - - - - 
                // anyone that submits a ticket is stored into this table
                ds = new DataSet();

                tableChck = new SqlCommand("if exists (select * from INFORMATION_SCHEMA.TABLES " +
                      "WHERE TABLE_NAME = 'Users') SELECT 1 ELSE SELECT 0", conn);

                x = Convert.ToInt32(tableChck.ExecuteScalar());

                if (x == 1)
                {
                    //MessageBox.Show("Users table already exists");
                }

                else
                {
                    myCommand = new SqlCommand("Create table Users(UserID int Not Null Identity Primary Key, " +
                "UserName char(50))", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("The Users table has been created.");

                }

                // - - - - - - - - - - - - Repair Times - - - - - - - - - - - - - - 
                ds = new DataSet();

                tableChck = new SqlCommand("if exists (select * from INFORMATION_SCHEMA.TABLES " +
                      "WHERE TABLE_NAME = 'RepairTimes') SELECT 1 ELSE SELECT 0", conn);

                x = Convert.ToInt32(tableChck.ExecuteScalar());

                if (x == 1)
                {
                    // MessageBox.Show("RepairTimes table already exists");
                }

                else
                {
                    myCommand = new SqlCommand("Create table RepairTimes(TimeID varchar(2) Not Null Primary Key, " +
                "TimeRange char(19))", conn);

                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("The RepairTimes table has been created.");

                    ds = new DataSet();

                    myCommand = new SqlCommand("Insert into RepairTimes(TimeID, TimeRange)" +
                        " values('T1', '9:00am-11:00am'), ('T2', '11:00am-1:00pm'), ('T3', '1:00pm-3:00pm'), ('T4', '3:00pm-5:00pm')", conn);


                    da = new SqlDataAdapter(myCommand);

                    da.SelectCommand.ExecuteNonQuery();

                }
            }

            // if connection fails, display error message
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // close connection to Bella database
            finally
            {
                conn.Close();
            }
        }
        // - - - - - - - - - - - - - -  End of Table Creation - - - - - - - - 


        /*
         * Pre: The Tickets table has been filled with data/
         * updated but the new changes have not been displayed in dgDisplay
         * post: Current data in Tickets is displayed
         * purpose: To display the Tickets table
         */
        public void DisplayTable()
        {
            try
            {
                conn.Open();
                ds = new DataSet();

                myCommand = new SqlCommand("Select t.TicketID, t.Date as Submission_Date, " +
                    "rt.TimeRange as Repair_Time, tt.RoomType as Room_Type, r.RepairType as Repair_Type, " +
                    "u.Description as Priority, tc.Name as Techn_Name, l.BuildName as Building, " +
                    "t.RoomNum as Room_Num, s.CurrentStatus as Current_Status, us.Username as Submitted_By from " +
                    "Tickets t " +
                "Inner Join RepairTimes rt On t.RepairTime = rt.TimeID " +
                "Inner Join TicketType tt On t.RoomType = tt.RoomID " +
                "Inner Join Repairs r On t.Repair = r.RepairID " +
                "Inner Join Urgency u On t.UrgencyLevel = u.UrgencyID " +
                "Inner Join Technicians tc On t.Technician = tc.TechID " +
                "Inner Join Location l On t.Building = l.BuildID " +
                "Inner Join Status s On t.Status = s.StatusID " +
                "Inner Join Users us On t.SubmittedBy = us.UserID order by t.TicketID", conn);


                da = new SqlDataAdapter(myCommand);

                da.SelectCommand.ExecuteNonQuery();

                using (da = new SqlDataAdapter(myCommand))
                {
                    da.Fill(ds, "t1");
                }

                dgDisplay.DataSource = ds.Tables[0];
            }

            // if connection fails, display error message
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // close connection to Bella database
            finally
            {
                conn.Close();
            }
        }

        /*
         * Pre: A ticket is submitted and the user wants to reset the controls to submit a ticket
         * post: the ticket input fields are cleared
         * purpose: To clear all of the input fields after a ticket is submitted
         */
        public void ResetControls()
        {
            dtpDate.ResetText();
            cmbBxRprTime.SelectedIndex = -1;
            cmbBxTicType.ResetText();
            cmbBxTicType.SelectedIndex = -1;
            cmbBxOffcRpr.SelectedIndex = -1;
            cmbBxClssRmRpr.SelectedIndex = -1;
            cmbBxDrmRpr.SelectedIndex = -1;
            cmbBxUrgency.SelectedIndex = -1;
            cmbBxUrgency.Enabled = true;
            cmbBxTech.ResetText();
            cmbBxBldg.SelectedIndex = -1;
            cmbBxBldg.Enabled = true;
            txtRoomNum.Clear();
            cmbBxStatus.ResetText();
            txtSubBy.Clear();
        }

        /*
         * Pre: The user has decided to retrieve submitted tickets
         * post: The names of all users that have submitted tickets are now displayed in cmbBxUsers
         * purpose: To fill the cmbBxUsers with the UserNames stored in Users table
         */
        public void FillUsersComboBox()
        {
            // read data from Users table
            SqlDataReader sr;

            ds = new DataSet();
            // attempt to read Users table from Bella database
            try
            {
                conn.Open();

                cmbBxVwByUsers.Items.Clear();

                string query = "Select Username from Users";

                SqlCommand getUsers = new SqlCommand(query, conn);

                da = new SqlDataAdapter(getUsers);

                da.SelectCommand.ExecuteNonQuery();

                sr = getUsers.ExecuteReader();

                // read each user in the Users table
                while (sr.Read())
                {
                    cmbBxVwByUsers.Items.Add(sr[0].ToString().Trim());
                }

                sr.Close();

            }

            // if connection fails, display error message
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // close connection to Bella database
            finally
            {
                conn.Close();
            }
        }


        /*
         * pre: The user selects the radio button to submit a new ticket
         * post: The displays to submit a ticket are visible
         * purpose: To display the controls that allow user to submit a new ticket
         * */
        public void DisplaySubmitControls()
        {
            // controls associated with the Submit Ticket feature
            cmbBxTicType.Enabled = true;
            lblTicType.Visible = true;
            cmbBxTicType.Visible = true;
            cmbBxBldg.Enabled = true;
            cmbBxBldg.Visible = true;
            lblBldg.Visible = true;
            cmbBxClssRmRpr.Enabled = true;
            cmbBxClssRmRpr.Visible = true;
            lblRprType.Visible = true;
            cmbBxDrmRpr.Enabled = true;
            cmbBxDrmRpr.Visible = true;
            cmbBxOffcRpr.Enabled = true;
            cmbBxOffcRpr.Visible = true;
            cmbBxRprTime.Enabled = true;
            cmbBxRprTime.Visible = true;
            lblRprTime.Visible = true;
            dtpDate.Enabled = true;
            dtpDate.Visible = true;
            lblDate.Visible = true;
            txtRoomNum.Enabled = true;
            txtRoomNum.Visible = true;
            lblRoomNum.Visible = true;
            txtSubBy.Enabled = true;
            txtSubBy.Visible = true;
            lblSubBy.Visible = true;
            cmbBxStatus.Enabled = true;
            cmbBxStatus.Visible = true;
            lblStatus.Visible = true;
            cmbBxUrgency.Enabled = true;
            cmbBxUrgency.Visible = true;
            lblUrgency.Visible = true;
            cmbBxTech.Visible = true;
            lblSelTech.Visible = true;
            btnSbmt.Visible = true;
            btnReset.Visible = true;


            // hide all other controls
            cmbBxChgSts.Visible = false;
            cmbBxChgTech.Visible = false;
            grpBxSubmit.Visible = true;
            grpBxSubmit.Enabled = true;
            cmbBxStatus.Enabled = false;
            cmbBxTech.Enabled = false;
            rdBtnStatus.Visible = false;
            rdBtnTech.Visible = false;
            lblEnterTckID.Visible = false;
            txtEnterTickID.Visible = false;
            btnSbmtUpdts.Visible = false;
            btnRtrvTicks.Visible = false;
            rdBtnVwBySts.Visible = false;
            rdBtnVwByTech.Visible = false;
            rdBtnVwByUser.Visible = false;
            cmbBxVwBySts.Visible = false;
            cmbBxVwByTech.Visible = false;
            cmbBxVwByUsers.Visible = false;
            btnResetSelc.Visible = false;
            btnRtrvTicks.Visible = false;
        }


        //public void DeleteTables()
        //{

        //    try
        //    {
        //        conn.Open();

        //        // drop Technicians
        //        ds = new DataSet();

        //        myCommand = new SqlCommand("Drop table Technicians Drop table Status " +
        //            "Drop table Urgency Drop table TicketType Drop table Location " +
        //        "Drop table Repairs Drop table Tickets Drop table Users Drop table RepairTimes", conn);

        //        da = new SqlDataAdapter(myCommand);

        //        da.SelectCommand.ExecuteNonQuery();

        //    }

        //   // if connection failed, display error message
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    // disconnect from database
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}


        // * * * * * * * * * * * *    End of Helper Methods * * * * * * * * * * * * *

    }
}
