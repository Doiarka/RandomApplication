using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using RandomApplications;
using RandomApplications.Models;

namespace RandomApplications.Forms
{
    public partial class Form1 : Form
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=randomapp;Integrated Security=True";
        DataContext db = new DataContext(connectionString);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateAllLists();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var table = db.GetTable<BaseApplication>();
            var app = new BaseApplication
            {
                Title = titleTextBox.Text,
                Description = descriptionTextBox.Text,
                Status = Status.Open
            };
            table.InsertOnSubmit(app);
            db.SubmitChanges();
            titleTextBox.Clear();
            descriptionTextBox.Clear();
            CreateStatusHistory(app);
            UpdateAllLists();
        }

        private void UpdateOpenApps()
        {
            openListBox.Items.Clear();
            var apps = db.GetTable<BaseApplication>();
            var openApps = apps.Where(x => x.StatusId == 0 || x.StatusId == 2).ToList();
            foreach (var app in openApps)
                openListBox.Items.Add(app.Title);
        }

        private void UpdateReadyApps()
        {
            readyListBox.Items.Clear();
            var apps = db.GetTable<BaseApplication>();
            var readyApps = apps.Where(x => x.StatusId == 1).ToList();
            foreach (var app in readyApps)
                readyListBox.Items.Add(app.Title);
        }

        private void UpdateCloseApps()
        {
            closeListBox.Items.Clear();
            var apps = db.GetTable<BaseApplication>();
            var closeApps = apps.Where(x => x.StatusId == 3).ToList();
            foreach (var app in closeApps)
                closeListBox.Items.Add(app.Title);
        }

        private void UpdateAllApps(long? statusId = null)
        {
            appsListBox.Items.Clear();
            var apps = db.GetTable<BaseApplication>();
            var closeApps = statusId == null ? apps.ToList() : apps.Where(x => x.StatusId == statusId).ToList();
            foreach (var app in closeApps)
                appsListBox.Items.Add(app.Title);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var selectedApp = openListBox.Text;
            if (String.IsNullOrEmpty(selectedApp))
            {
                MessageBox.Show("Необходимо выбрать открытую заявку");
                return;
            }
            var apps = db.GetTable<BaseApplication>();
            var app = apps.Single(x => x.Title == selectedApp);
            app.Status = Status.Ready;
            
            db.SubmitChanges();
            CreateStatusHistory(app, Status.Open);
            UpdateAllLists();
        }

        private void UpdateAllLists()
        {
            filterComboBox.SelectedItem = null;
            UpdateOpenApps();
            UpdateReadyApps();
            UpdateCloseApps();
            UpdateAllApps();
            UpdateStatusList();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            var selectedApp = readyListBox.Text;
            if (String.IsNullOrEmpty(selectedApp))
            {
                MessageBox.Show("Необходимо выбрать заявку в работе");
                return;
            }
            var apps = db.GetTable<BaseApplication>();
            var app = apps.Single(x => x.Title == selectedApp);
            app.Status = Status.Return;

            db.SubmitChanges();
            CreateStatusHistory(app, Status.Ready);
            UpdateAllLists();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            var selectedApp = readyListBox.Text;
            if (String.IsNullOrEmpty(selectedApp))
            {
                MessageBox.Show("Необходимо выбрать открытую заявку в работе");
                return;
            }
            var apps = db.GetTable<BaseApplication>();
            var app = apps.Single(x => x.Title == selectedApp);
            app.Status = Status.Close;

            db.SubmitChanges();
            CreateStatusHistory(app, Status.Ready);
            UpdateAllLists();
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAllApps(filterComboBox.SelectedIndex);
        }

        private void deleteAppButton_Click(object sender, EventArgs e)
        {
            var selectedApp = closeListBox.Text;
            if (String.IsNullOrEmpty(selectedApp))
            {
                MessageBox.Show("Необходимо выбрать закрытую заявку");
                return;
            }
            var apps = db.GetTable<BaseApplication>();
            var app = apps.Single(x => x.Title == selectedApp);
            apps.DeleteOnSubmit(app);
            db.SubmitChanges();
            UpdateAllLists();
        }

        private void CreateStatusHistory(BaseApplication app, Status? old = null)
        {
            var histories = db.GetTable<BaseHistory>();
            var history = new BaseHistory
            {
                AppId = app.Id,
                StatusOld = old,
                StatusNew = app.Status,
                DateModify = DateTime.Now,

            };
            histories.InsertOnSubmit(history);
            db.SubmitChanges();
        }

        private void UpdateStatusList()
        {
            historyListBox.Items.Clear();
            var histories = db.GetTable<BaseHistory>();
            var historiesList = histories.ToList();
            foreach (var history in historiesList)
                historyListBox.Items.Add("Заявка #" + history.AppId + ": " + history.StatusOld + " -> " + history.StatusNew + ": " + 
                                        history.DateModify.ToShortDateString() + " " + history.DateModify.Hour + ":" + history.DateModify.Minute);
        }
    }
}
