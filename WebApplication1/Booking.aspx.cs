using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DayPilot.Utils;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadResources();

                DayPilotScheduler1.StartDate = new DateTime(DateTime.Today.Year, 1, 1);
                DayPilotScheduler1.Days = Year.Days(DateTime.Today.Year);
                DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);
                DayPilotScheduler1.DataBind();

                DayPilotScheduler1.SetScrollX(DateTime.Today);
            }
        }
        private void LoadResources()
        {
            DayPilotScheduler1.Resources.Clear();

            SqlDataAdapter da = new SqlDataAdapter("SELECT [id], [name] FROM [resource]", ConfigurationManager.ConnectionStrings["DayPilot"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow r in dt.Rows)
            {
                string name = (string)r["name"];
                string id = Convert.ToString(r["id"]);

                DayPilotScheduler1.Resources.Add(name, id);
            }
        }
        protected void DayPilotScheduler1_EventMove(object sender, DayPilot.Web.Ui.Events.EventMoveEventArgs e)
        {
            string id = e.Value;
            DateTime start = e.NewStart;
            DateTime end = e.NewEnd;
            string resource = e.NewResource;

            DbUpdateEvent(id, start, end, resource);

            DayPilotScheduler1.DataSource = DbGetEvents(DayPilotScheduler1.StartDate, DayPilotScheduler1.Days);
            DayPilotScheduler1.DataBind();
            DayPilotScheduler1.Update();
        }
        private DataTable DbGetEvents(DateTime start, int days)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT [id], [name], [eventstart], [eventend], [resource_id] FROM [event] WHERE NOT (([eventend] <= @start) OR ([eventstart] >= @end))", ConfigurationManager.ConnectionStrings["DayPilot"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("start", start);
            da.SelectCommand.Parameters.AddWithValue("end", start.AddDays(days));
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void DbUpdateEvent(string id, DateTime start, DateTime end, string resource)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DayPilot"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [event] SET eventstart = @start, eventend = @end, resource_id = @resource WHERE id = @id", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("start", start);
                cmd.Parameters.AddWithValue("end", end);
                cmd.Parameters.AddWithValue("resource", resource);
                cmd.ExecuteNonQuery();
            }
        }
    }
}